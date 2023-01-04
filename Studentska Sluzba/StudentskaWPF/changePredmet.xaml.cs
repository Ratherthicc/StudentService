using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static StudentskaSluzba.model.Predmet;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for changePredmet.xaml
    /// </summary>
    public partial class changePredmet : Window, INotifyPropertyChanged
    {
        private PredmetController predmetctrl;
        public Predmet pr;
        public changePredmet(PredmetController controller, Predmet p)
        {
            InitializeComponent();
            DataContext = this;
            pr = p;

            naziv.Text = p.Name;
            ComboSemestar.Text = p.Semester.ToString();
            ComboTrGodIzvodjenja.Text = p.YearOfStudy.ToString();
            idprofesora.Text = p.ProfesorId.ToString();
            espb.Text = p.Espb.ToString();

            predmetctrl = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void odustaniClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void potvrdiClick(object sender, RoutedEventArgs e)
        {

            pr.Name = naziv.Text;

            String godIz = ComboTrGodIzvodjenja.Text;
            int godinaIzvodjenja = int.Parse(godIz);
            pr.YearOfStudy = godinaIzvodjenja;

            pr.ProfesorId = int.Parse(idprofesora.Text);

            String bres = espb.Text;
            int brojEspb = string.IsNullOrEmpty(bres) ? -1 : int.Parse(bres);
            pr.Espb = brojEspb;

            String semestar = ComboSemestar.Text;
            Semmester s;

            if (semestar == "letnji")
            {
                s = Semmester.SUMMER;
                pr.Semester = s;
            }
            else if (semestar == "zimski")
            {
                s = Semmester.WINTER;
                pr.Semester = s;
            }



            predmetctrl.Update(pr);
            Close();

        }
    }
}