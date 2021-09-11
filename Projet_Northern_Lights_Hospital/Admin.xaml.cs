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
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        //aller vers la page ajout medecin
        private void addMed_Click(object sender, RoutedEventArgs e)
        {
            AjoutMedecin ajoutMed = new AjoutMedecin();
            ajoutMed.ShowDialog();
        }

        //aller vers la page modifier medecin
        private void modifMed_Click(object sender, RoutedEventArgs e)
        {
            ModifMedecin modifMed = new ModifMedecin();
            modifMed.ShowDialog();
        }

        //aller vers la page supprimer medecin
        private void delMedecin_Click(object sender, RoutedEventArgs e)
        {
            SupprimMedecin supprimMed = new SupprimMedecin();
            supprimMed.ShowDialog();
        }

        //fermer la page
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
        
            this.Close();
        }

        //pour afficher le tableau de consultation par l'admin
        private void ConsultationLst_Click(object sender, RoutedEventArgs e)
        {
            TableauConsultation tab = new TableauConsultation();
            tab.ShowDialog();
        }
    }
}
