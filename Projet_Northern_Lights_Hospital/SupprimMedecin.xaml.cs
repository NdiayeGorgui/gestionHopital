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
    /// Logique d'interaction pour SupprimMedecin.xaml
    /// </summary>
    public partial class SupprimMedecin : Window
    {
        string medId;
        NorthernLightsHospitalEntities db;
        public SupprimMedecin()
        {
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
            cboIDMedecin.DataContext = db.Medecins.ToList();
           
        }
      
        //cette methode permet de supprimer un medecin selon l'id selectionné mais aussi de verifier d'abord si le medecin choisi
        //n'est rattaché a aucun patient
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Medecin smed = cboIDMedecin.SelectedItem as Medecin;
            if (smed!=null)
            {
                smed.IDMedecin = (cboIDMedecin.SelectedItem as Medecin).IDMedecin;

                db.Medecins.Remove(smed);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Medecin supprimé avec succes!");
                    cboIDMedecin.SelectedIndex = 0;
                    
                    //rafraichiment du combobox
                    cboIDMedecin.DataContext = db.Medecins.ToList();

                }
                catch (Exception )
                {
                   
                    //si le medecin à supprimer est rattaché à un plusieurs patients, on se redirige vers une autre page pour affecter
                    //ses patients à un autre medecin avant la suppression du medecin en question
                    MessageBox.Show("Ce Médecin est déja rattaché à un ou plusieurs patients, Veuillez affecter ces Patients à un autre Médecin avant suppression !",
                  "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
                    medId = cboIDMedecin.Text;
                    RemplacerMedecin remp = new RemplacerMedecin(medId);
                    remp.ShowDialog();
                    this.Close();

                }
            }

           
        }
        //cette methode permet d'afficher sur les zones de texte les information du medecin avant suppression selon l'id du medecin selectionné
        private void cboIDMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin med = cboIDMedecin.SelectedItem as Medecin;
            cboIDMedecin.Text = med.IDMedecin.ToString();
            txtNom.Text = med.nomMedecin;
            txtPrenom.Text = med.prenomMedecin;
        }

        
    }
}
