using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet_Northern_Lights_Hospital
{
    /// <summary>
    /// Logique d'interaction pour RecherchePatient.xaml
    /// </summary>
    public partial class RecherchePatient : Window
    {
        string nss;
        NorthernLightsHospitalEntities db;
        public RecherchePatient(string nssPatient)
        {
            nss = nssPatient;
            InitializeComponent();
            txtNNS.Text = nss;
            txtNNS.Focus();
            db = new NorthernLightsHospitalEntities();
            //pour masquer les labels ou on doit afficher les données au chargement de la page
            //et désactiver le bouton faire une admission
            hideLabel();
            btnFaireAdmission.IsEnabled=false;
        }

        //pour faire une recherche d'un patient
        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNNS.Text))
            {
                hideLabel();
                btnFaireAdmission.IsEnabled = false;
                clearLabelData();
                MessageBox.Show("Veuillez saisir le NNS du patient !.",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            rechercherPatient(txtNNS.Text);

        }

        //cette methode parcourt toutes les donnees de la table patient pour rechercher un nss
        private bool rechercherPatient(string nss)
        {
            foreach (Patient p in db.Patients.ToList())
            {
                if (nss == p.NSS.Trim())
                {
                    lblNom.Content = p.nom;
                    lblPrenom.Content = p.prenom;
                    lblDateNaissance.Content = p.dateNaissance;
                    lblAdresse.Content = p.adresse;
                    lblVille.Content = p.ville;
                    lblProvince.Content = p.province;
                    lblCodePostal.Content = p.codePostal;
                    lblTelephone.Content = p.telephone;
                    lblAssurance.Content = p.Assurance.nomAssurance;
                    

                    showLabel();
                    btnFaireAdmission.IsEnabled = true;
                    return true;
                }
               
            }
            //sinon si le numero saisie n'existe pas
            if (!String.IsNullOrEmpty(txtNNS.Text))
            {
                //apres avoir afficher un patient existant on peut vouloir faire une autre recherche, alors il faut vider 
              //  les labels préremplis au paravant
                hideLabel();
                btnFaireAdmission.IsEnabled = false;
                clearLabelData();
                MessageBox.Show("Désolé, ce NSS de patient n'existe pas !",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }
               
            return false;
        }
        //pour masquer en quelque sorte les labels des titres
       private void hideLabel()
        {          
            assuranceLbl.Content=string.Empty;
            nomLbl.Content = string.Empty;
            prenomLbl.Content = string.Empty;
            datenaissLbl.Content = string.Empty;
            adresseLbl.Content = string.Empty;
            villeLbl.Content = string.Empty;
            provinceLbl.Content = string.Empty;
            codePostalLbl.Content = string.Empty;
            telephoneLbl.Content = string.Empty;
        }

        //pour afficher les labels des titres
        private void showLabel()
        {
            assuranceLbl.Content = "Assurance:";
            nomLbl.Content = "Nom:";
            prenomLbl.Content = "Prénom:";
            datenaissLbl.Content = "Date Naissance:";
            adresseLbl.Content = "Adresse:";
            villeLbl.Content = "Ville:";
            provinceLbl.Content = "Province:";
            codePostalLbl.Content = "Code Postal:";
            telephoneLbl.Content = "Téléphone:";
        }

        //pour masquer les labels  des données
        private void clearLabelData()
        {
            lblAssurance.Content = string.Empty;
            lblNom.Content = string.Empty;
            lblPrenom.Content = string.Empty;
            lblDateNaissance.Content = string.Empty;
            lblAdresse.Content = string.Empty;
            lblVille.Content = string.Empty;
            lblProvince.Content = string.Empty;
            lblCodePostal.Content = string.Empty;
            lblTelephone.Content = string.Empty;
        }

        //pour aller a la page admission et faire une admission du patient trouvé
        private void btnFaireAdmission_Click(object sender, RoutedEventArgs e)
        {
             nss= txtNNS.Text;
         
            AjoutAdmission ajoutAdmission = new AjoutAdmission(nss);

            ajoutAdmission.ShowDialog();
            this.Close();

        }

    }
}
