using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet_Northern_Lights_Hospital
{
    /// <summary>
    /// Logique d'interaction pour AjoutPatient.xaml
    /// </summary>
    public partial class AjoutPatient : Window
    {
        string nss;
        NorthernLightsHospitalEntities db;
        public AjoutPatient()
        {
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
            txtNss.Focus();
            cboAssurance.DataContext = db.Assurances.ToList();
            cboAssurance.DataContext = db.Assurances.ToList();
            cboAssurance.SelectedIndex = 4;
            btnFaireAdmission.IsEnabled = false;
        }
        //Ajout du patient
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //pour empecher de saisir un nss vide
            if (String.IsNullOrEmpty(txtNss.Text))
            {
                MessageBox.Show("Le NSS du Patient est requis !.",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //Le Nom, le prénom et la date de naissance sont requis
            else if ((String.IsNullOrEmpty(txtNom.Text))
                || (String.IsNullOrEmpty(txtPrenom.Text))
                || (String.IsNullOrEmpty(dpDateNaissance.Text)))
            {
                MessageBox.Show("Le Nom, le prénom et la date de naissance sont requis !.",
                    "Informations manquantes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //on recupere la saisie
          
            Patient pat = new Patient();
            pat.NSS = txtNss.Text;
            pat.dateNaissance = dpDateNaissance.SelectedDate;
            pat.nom = txtNom.Text;
            pat.prenom = txtPrenom.Text;
            pat.adresse = txtAdresse.Text;
            pat.ville = txtVille.Text;
            pat.province = txtProvince.Text;
            pat.codePostal = txtCodePostal.Text;
            pat.telephone = txtTelephone.Text;
            pat.IDAssurance = (cboAssurance.SelectedItem as Assurance).IDAssurance;

            db.Patients.Add(pat);
            
            try
            {
              //on enregistre
                db.SaveChanges();
                MessageBox.Show("Patient ajouté avec succes!");
                btnFaireAdmission.IsEnabled = true;

            }
            //dans le catch si le patient existe vous serez redirigé vers la page recherchePatient pour afficher ses infos et lui faire une admission
            catch (Exception )
            {
                patientExiste(txtNss.Text);
               
                this.Close();
             
            }
            }

        }

        //vider les zones de saisi
        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            clear();
            btnFaireAdmission.IsEnabled = false;

        }

        //rechercher l'existance d'un patient
        private bool patientExiste(string nss)
        {
            foreach (Patient p in db.Patients.ToList())
            {
                if (nss == p.NSS.Trim())
                {
                 
                    MessageBoxResult result = MessageBox.Show("Ce patient existe déja, si vous cliquez sur oui vous serez redirigé vers la page recherche patient pour afficher ses informations", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            RecherchePatient recherchePatient = new RecherchePatient(nss);
                            recherchePatient.ShowDialog();
                            break;
                        case MessageBoxResult.No:
                            AjoutPatient ajoutPatient = new AjoutPatient();
                            ajoutPatient.Show();
                            break;
                    }

                    return true;
                }

            }
           
            return false;
        }

        //pour aller vers la page admission
        private void btnFaireAdmission_Click(object sender, RoutedEventArgs e)
        {
            nss =txtNss.Text;
           
            AjoutAdmission ajoutAdmission = new AjoutAdmission(nss);
            ajoutAdmission.ShowDialog();
            this.Close();
        }

        //pour vider les champs de saisies
        private void clear()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtNss.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtVille.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtCodePostal.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            cboAssurance.Text = string.Empty;
            dpDateNaissance.Text = string.Empty;
        }
    }
}
