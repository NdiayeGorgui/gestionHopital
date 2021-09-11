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
    /// Logique d'interaction pour ModifMedecin.xaml
    /// </summary>
    public partial class ModifMedecin : Window
    {
        NorthernLightsHospitalEntities db;
        public ModifMedecin()
        {
           
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
            cboIDMedecin.DataContext = db.Medecins.ToList();
        }

        //cette methode permet de modifier le nom et/ou le prénom du médecin
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Medecin med = cboIDMedecin.SelectedItem as Medecin;
            if (med!=null)
            {
                med.IDMedecin = (cboIDMedecin.SelectedItem as Medecin).IDMedecin;
                med.nomMedecin = txtNom.Text;
                med.prenomMedecin = txtPrenom.Text;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Medecin modifié avec succes!");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

           


        }

        //cette methode permet d'afficher sur les zones de texte les information a modifier selon l'id du medecin selectionné
        private void cboIDMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin med = cboIDMedecin.SelectedItem as Medecin;
            cboIDMedecin.Text= med.IDMedecin.ToString();
            txtNom.Text = med.nomMedecin.Trim();
            txtPrenom.Text = med.prenomMedecin.Trim();

        }
    }
}
