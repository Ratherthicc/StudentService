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
using StudentskaSluzba.model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentskaWPF.Controller;
using static StudentskaSluzba.model.Predmet;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for addPredmet.xaml
    /// </summary>
    public partial class addPredmet : Window, INotifyPropertyChanged
    {
        PredmetController control;
        public Predmet Predmet { get; set; }

        public addPredmet(PredmetController controller)
        {
            InitializeComponent();
            DataContext = this;
            Predmet = new Predmet();
            control = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        public Predmet GetPredmetById(string id)
        {
            return control.GetAllPredmet().Find(p => p.Id == id);
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            String sifrapredmeta = TextSifraPred.Text;
            if (sifrapredmeta == "")
            {
                MessageBox.Show("Morate unijeti neke podatke za sifru predmeta!");
            }
            else
            {
                Predmet prpom = GetPredmetById(sifrapredmeta);
                if (prpom == null)
                {
                    String naziv = imepred.Text;


                    String godIz = godizv.Text;
                    int godinaIzvodjenja = string.IsNullOrEmpty(godIz) ? -1 : int.Parse(godIz);
                    int predmetniProfesor = int.Parse(prof.Text);
                    int bres = int.Parse(espb.Text);
                    

                    String semestar = semstar.Text;
                    Semmester sem;

                    if (semestar == "Letnji")
                    {
                        sem = Semmester.SUMMER;
                        Predmet P = new Predmet(sifrapredmeta, naziv, sem, godinaIzvodjenja, predmetniProfesor, bres);
                        control.Create(P);


                    }
                    else if (semestar == "Zimski")
                    {
                        sem = Semmester.WINTER;
                        Predmet P= new Predmet(sifrapredmeta, naziv, sem, godinaIzvodjenja, predmetniProfesor, bres);
                        control.Create(P);
                    }
                    else
                    {
                        MessageBox.Show("Morate unijeti konkretan semestar(letnji,zimski)!");
                    }

                   
                }
                else
                {
                    MessageBox.Show("Postoji predmet vec sa tom sifrom. Morate promjeniti sifru predmeta!");
                }
            }

        }

      

      
    }
}
