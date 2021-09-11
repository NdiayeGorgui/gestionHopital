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
    /// Logique d'interaction pour Prepose.xaml
    /// </summary>
    public partial class Prepose : Window
    {
        string nss;
        public Prepose()
        {
            InitializeComponent();
        }

        private void addPat_Click(object sender, RoutedEventArgs e)
        {
            AjoutPatient ajoutPatient = new AjoutPatient();
            ajoutPatient.ShowDialog();
        }

        private void cherchPat_Click(object sender, RoutedEventArgs e)
        {
           
            RecherchePatient recherchePatient = new RecherchePatient(nss);
            recherchePatient.ShowDialog();
        }

      

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
