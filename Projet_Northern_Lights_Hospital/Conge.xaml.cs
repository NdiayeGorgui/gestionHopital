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
using System.Data.Entity;

namespace Projet_Northern_Lights_Hospital
{
    /// <summary>
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : Window
    {
        string nss;
        
        NorthernLightsHospitalEntities db;
        public Conge()
        {
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();

           
           
         //pour afficher uniquement dans le combobox les patients qui n'ont pas encore pris de congé 
            cboAdmission.DataContext = db.Admissions.Where(y => y.dateConge == null).ToList();
           
            dpDateConge.SelectedDate = DateTime.Today;
        }
        //cette methode permet de donner congé
        private void btnConge_Click(object sender, RoutedEventArgs e)
        {
            Admission admission = cboAdmission.SelectedItem as Admission;
            if (admission!=null)
            {
                admission.dateConge = dpDateConge.SelectedDate;
                admission.Lit.occupe = false;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Le tarif a payer pour le patient est de: " + tarification() + " $");
                    MessageBox.Show("Congé donné avec succes!");

                    //rafraichissement du combobox
                    cboAdmission.DataContext = db.Admissions.Where(y => y.dateConge == null).ToList();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
           

        }
        //cette methode permet d'afficher sur des labels les données de chaque patient selectionné a travers le numero de son admission
        //nous avons choisi le numero d'admission au lieu du numero du patient car le patient peut etre admis plusieurs fois a des dates
        //differentes d'ou le numero du patient ne sera pas pertinente
        private void cboAdmission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Admission admission = cboAdmission.SelectedItem as Admission;
            lblNSS.Content = admission.NSS;
            lblNom.Content = admission.Patient.nom;
            lblPrenom.Content = admission.Patient.prenom;
            lblTypelit.Content = admission.Lit.TypeLit.description;
            lblAssurance.Content = admission.Patient.Assurance.nomAssurance;
            if (admission.telephone == true)
            {
                lblTelephone.Content = "Oui";
            }
            else
            {
                lblTelephone.Content = "Non";
            }

            if (admission.televiseur == true)
            {
                lblTelevision.Content = "Oui";
            }
            else
            {
                lblTelevision.Content = "Non";
            }
        }
        //cette fonction permet de calculer la tarification selon les options selectionnées par le patient
        private double tarification()
        {
            double tarifSemiPrivee, tarifPrivee, tarifTelevision, tarifPhone;

            Admission admission = cboAdmission.SelectedItem as Admission;
           
            AjoutAdmission ajoutAdmission = new AjoutAdmission(nss);

            tarifSemiPrivee = 267;
            tarifPrivee = 571;
            tarifTelevision = 42.5;
            tarifPhone = 7.5;
            double valeur = 0.0;

            //si le patient a une  assurance privée
            if (!admission.Patient.IDAssurance.Equals("5") )
            {
                //si le patient choisit une chambre (lit) privée
                if (admission.Lit.IDType == 1)
                {

                    if (admission.telephone == true && admission.televiseur == true)
                    {
                        valeur = tarifPrivee + tarifPhone + tarifTelevision;
                    }
                    else if (admission.telephone == true && admission.televiseur == false)
                    {
                        valeur = tarifPrivee + tarifPhone;
                    }
                    else if (admission.telephone == false && admission.televiseur == true)
                    {
                        valeur = tarifPrivee + tarifTelevision;
                    }
                    else
                    {
                        valeur = tarifPrivee;

                    }

                }
            //si le patient choisit une chambre (lit) Semi-privée
                else if (admission.Lit.IDType == 2)
                {
                    if (admission.telephone == true && admission.televiseur == true)
                    {
                        valeur = tarifSemiPrivee + tarifPhone + tarifTelevision;
                    }
                    else if (admission.telephone == true && admission.televiseur == false)
                    {
                        valeur = tarifSemiPrivee + tarifPhone;
                    }
                    else if (admission.telephone == false && admission.televiseur == true)
                    {
                        valeur = tarifSemiPrivee + tarifTelevision;
                    }
                    else
                    {
                        valeur = tarifSemiPrivee;

                    }

                }
                //si le patient choisit une chambre (lit) Standard
                else
                {
                    if (admission.telephone == true && admission.televiseur == true)
                    {
                        valeur =  tarifPhone + tarifTelevision;
                    }
                    else if (admission.telephone == true && admission.televiseur == false)
                    {
                        valeur = tarifPhone;
                    }
                    else if (admission.telephone == false && admission.televiseur == true)
                    {
                        valeur =  tarifTelevision;
                    }
                   
                }
            }
            
            //si le patient n'a pas une  assurance privée
            else
            {
                //si un type de chambre standard était disponible au moment du choix de chambre privée ou semi-prvée
                //il paye des frais supplémentaires.

                if (ajoutAdmission.rechercheTypeChambre(admission.NumeroLit = 3))
                {
                    //si le patient choisit un chambre (lit) Privée
                    if (admission.Lit.IDType == 1)
                    {
                        if (admission.telephone == true && admission.televiseur == true)
                        {
                            valeur = tarifPhone + tarifTelevision+tarifPrivee;
                        }
                        else if (admission.telephone == true && admission.televiseur == false)
                        {
                            valeur = tarifPhone+tarifPrivee;
                        }
                        else if (admission.telephone == false && admission.televiseur == true)
                        {
                            valeur = tarifTelevision+tarifPrivee;
                        }
                    }

                    //si le patient choisit une chambre (lit) Semi-privée
                    else if (admission.Lit.IDType == 2)
                    {
                        if (admission.telephone == true && admission.televiseur == true)
                        {
                            valeur = tarifPhone + tarifTelevision + tarifSemiPrivee;
                        }
                        else if (admission.telephone == true && admission.televiseur == false)
                        {
                            valeur = tarifPhone + tarifSemiPrivee;
                        }
                        else if (admission.telephone == false && admission.televiseur == true)
                        {
                            valeur = tarifTelevision + tarifSemiPrivee;
                        }
                    }

                    //sinon si le patient choisit une chambre (lit) Standard
                }

                else
                {
                    if (admission.telephone == true && admission.televiseur == true)
                    {
                        valeur = tarifPhone + tarifTelevision;
                    }
                    else if (admission.telephone == true && admission.televiseur == false)
                    {
                        valeur = tarifPhone;
                    }
                    else if (admission.telephone == false && admission.televiseur == true)
                    {
                        valeur = tarifTelevision;
                    }
                }


            }

            return valeur;
        }
    }
}
