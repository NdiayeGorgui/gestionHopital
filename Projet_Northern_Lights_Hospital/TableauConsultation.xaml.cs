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
    /// Logique d'interaction pour TableauConsultation.xaml
    /// </summary>
    public partial class TableauConsultation : Window
    {
        NorthernLightsHospitalEntities db;
        public TableauConsultation()
        {
            InitializeComponent();
            db = new NorthernLightsHospitalEntities();
        }

        //chargement des données recupérées dans le tableau a travers cette requete de jointure
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           var query =


           from p in db.Patients 
           join a in db.Admissions on p.NSS equals a.NSS
           join l in db.Lits on a.NumeroLit equals l.NumeroLit 
           join t in db.TypeLits on l.IDType equals t.IDType

           select new { p.nom, p.prenom,a.Medecin.nomMedecin,a.Medecin.prenomMedecin, 
               p.telephone, p.NSS,p.Assurance.nomAssurance,l.TypeLit.description, a.dateAdmission, 
               a.dateConge,a.NumeroLit,a.IDMedecin };

            dgConsultation.DataContext = query.ToList();

        }
    }
}
