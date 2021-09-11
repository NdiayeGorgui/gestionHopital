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
    /// Logique d'interaction pour AjoutMedecin.xaml
    /// </summary>
    public partial class AjoutMedecin : Window
    {
        NorthernLightsHospitalEntities db;
        public AjoutMedecin()
        {
          
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
            txtNom.Focus();
        }

        //cette methode permet d'ajouter un médecin
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Medecin med = new Medecin();
            //pour empecher de saisir des valeurs vides
            if ((String.IsNullOrEmpty(txtNom.Text))|| (String.IsNullOrEmpty(txtPrenom.Text)))
            {
                MessageBox.Show("Le Nom et le prénom sont requis !.",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

           
                med.nomMedecin = txtNom.Text;
                med.prenomMedecin = txtPrenom.Text;

                db.Medecins.Add(med);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Medecin ajouté avec succes!");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }
        //cette methode permet de vider les champs
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
        }
    }
}
