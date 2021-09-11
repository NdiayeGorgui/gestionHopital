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
    /// Logique d'interaction pour RemplacerMedecin.xaml
    /// </summary>
    public partial class RemplacerMedecin : Window
    {
        int myIdMed;
        NorthernLightsHospitalEntities db;
        public RemplacerMedecin(string idmed)
        {
            myIdMed = int.Parse(idmed);
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
            cboMedecinSup.DataContext = db.Medecins.Where(x=>x.IDMedecin==myIdMed).ToList();
            cboMedecinRemp.DataContext = db.Medecins.Where(x => x.IDMedecin != myIdMed).ToList();
        }

        //cette methode permet d'affecter les patients du medecin sélectionné à un autre medecin avant de supprimer le medecin en question
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Medecin smed = cboMedecinSup.SelectedItem as Medecin;
            Medecin rmed = cboMedecinRemp.SelectedItem as Medecin;

            // Requete pour le champ à modifier.
            var query =
                from a in db.Admissions
                where a.IDMedecin == smed.IDMedecin
                select a;
            
            // Execute la requete, et change la valeur de la colonne que l'on veut changer puis suprime le medecin changé
           
            foreach (Admission a in query)
            {
                a.IDMedecin = rmed.IDMedecin;
                db.Medecins.Remove(smed);
            }
                try
            {

                
              //appliquer les changements
                db.SaveChanges();
                MessageBox.Show("Le Medecin a été remplacé puis supprimé  avec succes!");
                SupprimMedecin supprimMedecin = new SupprimMedecin();
                supprimMedecin.Show();
                this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMedecinSup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin med = cboMedecinSup.SelectedItem as Medecin;
            cboMedecinSup.Text = med.IDMedecin.ToString();
            txtNom.Text = med.nomMedecin;
            txtPrenom.Text = med.prenomMedecin;
        }

        private void cboMedecinRemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin med = cboMedecinRemp.SelectedItem as Medecin;
            cboMedecinRemp.Text = med.IDMedecin.ToString();
            txtNomRemp.Text = med.nomMedecin;
            txtPrenomRemp.Text = med.prenomMedecin;
        }
    }
}
