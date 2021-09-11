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
    /// Logique d'interaction pour AjoutAdmission.xaml
    /// </summary>
    public partial class AjoutAdmission : Window
    {
        string myNSS;
        NorthernLightsHospitalEntities db;
         

       

        public AjoutAdmission(string nssPatient)
        {
            //pour recuperer le nss du patient issu de la page ajoutPatient ou recherchePatient
            myNSS = nssPatient;
           
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();

            cboNSS.DataContext = db.Patients.Where(x=>x.NSS==myNSS).ToList();
            cboMedecin.DataContext = db.Medecins.ToList();
            cboDepartement.DataContext = db.Departements.ToList();
            dpAdmission.SelectedDate = DateTime.Today;
            cboTypeLit.DataContext = db.TypeLits.ToList();
            cboTypeLit.SelectedIndex = 2;
            
          
            //pour charger dans le combobox uniquement les lit disponibles,
            //on choisit d'afficher par défaut, au chargement de la page, les types de chambre standard
            cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 3).Where(x => x.occupe==false).ToList(); 
        }


        //cette methode permet de créer une admission
        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            Patient pat = (cboNSS.SelectedItem as Patient);
            Admission admission = new Admission();

            //si le patient n'est pas admis en ce moment on fait l'admission
            if (!admissionExiste(pat))
            {
                //on verrifie si les boutons radios sont cochés ou pas pour récupérer les valeurs
                if (rbChirurgieOui.IsChecked == true)
                {
                    admission.chirurgieProgramme = true;
                }

                else if (rbChirurgieNon.IsChecked == true)
                {

                    admission.chirurgieProgramme = false;

                }

                if (rbTeleviseurOui.IsChecked == true)
                {
                    admission.televiseur = true;
                }

                else if (rbTeleviseurNon.IsChecked == true)
                {
                    admission.televiseur = false;
                }

                if (rbTelephoneOui.IsChecked == true)
                {
                    admission.telephone = true;
                }

                else if (rbTelephoneNon.IsChecked == true)
                {
                    admission.telephone = false;
                }

                admission.dateAdmission = dpAdmission.SelectedDate;
                admission.dateChirurgie = dpChirurgie.SelectedDate;
                admission.NSS = cboNSS.Text;
                admission.IDMedecin = (cboMedecin.SelectedItem as Medecin).IDMedecin;


                if (cboNumLit.Text == "")
                {
                    //si ya plus de lit dans les chambres standards
                    if (cboTypeLit.Text.Trim() == "Standard")
                    {
                        //si le patient n'a pas une assurance privée on envoie un message pour choisir un type de lit semi-privée sans frais
                        if (txtAssurance.Text.Trim() == "RAMQ")
                        {
                            MessageBox.Show("Le Lit est requis pour faire une admission,Choisir une chambre semi-privée sans frais supplémentaire !",
                           "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        //sinon si le patient a une assurance privée on envoie un message de choisir un type de lit semi-privée
                        else
                        {
                            MessageBox.Show("Le Lit est requis pour faire une admission,Choisir une chambre semi-privée !",
                         "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    //si ya plus de lit dans les chambres semi-privée 
                    else if (cboTypeLit.Text.Trim() == "Semi-Privée")
                    {
                        // si le patient n'a pas une assurance privée on envoie un message pour choisir un type de lit privée sans frais
                        if (txtAssurance.Text.Trim() == "RAMQ")
                        {
                            MessageBox.Show("Le Lit est requis pour faire une admission,Choisir une chambre privée sans frais supplémentaire !",
                           "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        //sinon si le patient a une assurance privée on envoie un message de choisir un type de lit privée
                        else
                        {
                            MessageBox.Show("Le Lit est requis pour faire une admission,Choisir une chambre privée  !",
                         "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    //si ya plus de lit dans les chambres privées on envoie ce message car cela signifie ya plus de lit de ce type disponible
                    else if (cboTypeLit.Text.Trim() == "Privée")
                    {
                        MessageBox.Show("Désolé, il n y a plus de lit de ce type disponible !",
                          "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                else
                {
                    
                    //sinon si ya un lit disponible dans les chambres standards et
                    //le patient decide de choisir ce type de chambre
                    if ((cboTypeLit.Text.Trim() != "Standard") )
                    {
                        //si le patient n'a pas une assurance privée on lui indique les frais supplémentaires a payer.
                        //pour ceux qui ont une assurance privée on ne précise pas les frais supplémentaire a payer car on admet que ces frais seront 
                        // a la charge de l'assurance
                        if (txtAssurance.Text.Trim() == "RAMQ")
                        {
                            //on recherche si une chambre standard est disponible si oui et que le patient qui n'a pas d'assurance privée 
                            //decide de choisir ce type de lit, alors il paie des frais suplémentaires
                            rechercheTypeChambre(3);
                        }
                    }
                    admission.NumeroLit = int.Parse(cboNumLit.Text);


                    db.Admissions.Add(admission);

                    try
                    {
                        

                        //on rend le lit indisponible puis on enregistre le département et le type de chambre choisi
                        admission.Lit.occupe = true;
                        admission.Lit.IDDepartement = (cboDepartement.SelectedItem as Departement).IDDepartement;
                        admission.Lit.IDType = (cboTypeLit.SelectedItem as TypeLit).IDType;

                        db.SaveChanges();
                        MessageBox.Show("Dossier ajouté avec succes!");

                        //on rafraichit le combobox pour faire disparaitre le lit en question dans la liste de choix selon le type de lit choisi
                        if (admission.Lit.IDType == 3)
                        {
                            cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 3).Where(y => y.occupe == false).ToList();
                        }
                        else if (admission.Lit.IDType == 2)
                        {
                            cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 2).Where(y => y.occupe == false).ToList();
                        }
                        else
                        {
                            cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 1).Where(y => y.occupe == false).ToList();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }
            //sinon si le patient est admis et non encore libéré par le medecin
            else
            {

                MessageBox.Show("Ce patient est déja admis, et non encore libéré  !",
               "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }


}
        //pour charger le combobox des NSS, afficher l'assurance du patient dans une zone de texte
        //et appeler la fonction moinsDeSeizeAns() qui lui verifie l'age du patient pour l'affecter a la pediatrie si ya pas chirurgie

        private void cboNSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    Patient pat = (cboNSS.SelectedItem as Patient);
                    txtAssurance.Text = pat.Assurance.nomAssurance;
                    moinsDeSeizeAns();

           
                }

        //si l'option chirurgie n'est pas choisi, on desactive la date de chirurgie, on selectionne le premier departement par defaut
        //puis on reactive la liste de choix departement car il etait desactivé dans la fonction rbChirurgieOui_Checked()
        //quand on affectait automatiquement le patient au departement de chirurgie ou de pediatrie
        private void rbChirurgieNon_Checked(object sender, RoutedEventArgs e)
        { 
             dpChirurgie.IsEnabled = false;     
             cboDepartement.SelectedIndex = 0;
             cboDepartement.IsEnabled = true;

            moinsDeSeizeAns();
        }

        //si cette option est choisi, on active la date de chirurgie qui était desactivé
        //puis on selectionne automatiquement le departement de chirurgie et on le desactive pour empecher au user de le modifier
        //dans le but de garder la cohérence
        private void rbChirurgieOui_Checked(object sender, RoutedEventArgs e)
        {
            dpChirurgie.IsEnabled = true;
            cboDepartement.SelectedIndex = 6;
            cboDepartement.IsEnabled = false;

        }

        //cette methode permet d'afficher pour chaque type de chambre les lits disponibles     
        private void cboTypeLit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (cboTypeLit.SelectedIndex == 0)
            {
                cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 1).Where(x => x.occupe == false).ToList();
             
            }
            else if(cboTypeLit.SelectedIndex == 1)
            {
                cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 2).Where(x => x.occupe == false).ToList();
              
            }
            else
            {
                cboNumLit.DataContext = db.Lits.Where(x => x.IDType == 3).Where(x => x.occupe == false).ToList();
             
            }
        }

        
        //cette methode verifie l'age du patient, si c'est inferieur ou égal a 16 ans, il l'affecte automatiquement au 
        // departement de pediatrie et on desactive la liste de choix
        //sinon on choisi par defaut le premier departenement en le reactivant
        private void moinsDeSeizeAns()
        {
            Patient pat = (cboNSS.SelectedItem as Patient);
           

            TimeSpan ans = (DateTime.Today - (Convert.ToDateTime(pat.dateNaissance)));

            int differenceInDays = ans.Days;
            int seizeAns = 365 * 16;

            if (differenceInDays <= seizeAns)
            {
                cboDepartement.SelectedIndex = 8;
                cboDepartement.IsEnabled = false;
            }
            else
            {
                cboDepartement.SelectedIndex = 0;
                cboDepartement.IsEnabled = true;
            }
        }
        // cette fonction permet de verifier si le patient a une admission en cours(c'est a dire n'est pas encore libéré par le medecin)
        //c'est pour eviter de faire une admission d'un patient deja admis dont le medecin n'a pas encore donné congé
        private bool admissionExiste(Patient nss)
        {
            foreach (Admission a in db.Admissions.ToList())
            {
                if (a.dateConge == null && a.NSS==nss.NSS)
                {

                    return true;
                }
            }
            return false;
        }

        //cette methode permet de rechercher un typte de lit existant, le but est de l'utiliser quand le patient decide
        //de choisir un lit privé ou semi-privé alors qu'il reste encore des lits dans les chambre standards.
        public bool rechercheTypeChambre(int numeroLit)
        {
            foreach (Lit l in db.Lits.ToList())
            {
                if (l.IDType == numeroLit && l.occupe == false)
                {

                    MessageBox.Show("Le patient devra assumer des frais supplémentaires pour avoir choisi ce type de chambre " +
                        "alors qu'il reste encore de lits standard  !",
                "Attention", MessageBoxButton.OK, MessageBoxImage.Information);

                    return true;
                }
            }
            return false;
        }

       
    }
}
