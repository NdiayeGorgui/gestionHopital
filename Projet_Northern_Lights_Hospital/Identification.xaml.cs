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
    /// Logique d'interaction pour Identification.xaml
    /// </summary>
    public partial class Identification : Window
    {
        public Identification()
        {
            InitializeComponent();
        }

        //cette methode permet de faire l'identification des acteurs(admin,médecin et préposé)
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
       
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Le nom d'utilisateur et le mot de passe sont requis !.",
                    "Attention", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtUserName.Text.Trim().ToLower().Equals("admin") && txtPassword.Password.Trim().ToLower().Equals("admin"))
            {
                 Admin admin = new Admin();

                admin.ShowDialog();
              
            }

            else if (txtUserName.Text.Trim().ToLower().Equals("medecin") && txtPassword.Password.Trim().ToLower().Equals("medecin"))
            {

                Conge conge = new Conge();

                conge.ShowDialog();
             

            }
            else if (txtUserName.Text.Trim().ToLower().Equals("prepose") && txtPassword.Password.Trim().ToLower().Equals("prepose"))
            {

                Prepose prepose = new Prepose();

                prepose.ShowDialog();
              

            }
            else
            {

                MessageBox.Show("Les informations saisies ne sont pas valides.",
                "Attention", MessageBoxButton.OK, MessageBoxImage.Information);

                // Nous supprimons tout le texte saisie et nous donnons le focus à txtuserName

                txtUserName.Text = String.Empty;
                txtPassword.Password = String.Empty;
                txtUserName.Focus();

             
            }
        }

        //pour fermer l'application avec un message de confirmation
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.MainWindow.Close();

        }
        //Override the onClose method in the Application Main window

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Désirez-vous réellement quitter cette application ?", "",
                                                  MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
    }
    }

