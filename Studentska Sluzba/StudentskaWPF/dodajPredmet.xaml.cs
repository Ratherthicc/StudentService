using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for dodajPredmet.xaml
    /// </summary>
    /// 



    public partial class dodajPredmet : Window
    {

        public Predmet selektovan { get; set; }
        public Student student { get; set; }

        private OcjeneController ocjentactrl;
        public ObservableCollection<Predmet> moguciPredmetiZaDodati { get; }
        public ObservableCollection<Predmet> polozeni { get; }

        public ObservableCollection<Predmet> nepolozeni { get; }


        public dodajPredmet(PredmetController predcontrol, OcjeneController ocjenacontrol, ObservableCollection<Predmet> polozenii, ObservableCollection<Predmet> nepolozenii, Student s)
        {

            ocjentactrl = ocjenacontrol;
            student = s;
            polozeni = polozenii;
            nepolozeni = nepolozenii;
            InitializeComponent();
            DataContext = this;


            List<Predmet> moguciPredmeti(int br)
            {
                List<Predmet> legalni_predmeti = new List<Predmet>();
                foreach (var p in predcontrol.GetAllPredmet())
                {
                    if (p.YearOfStudy >= br)
                    {
                        legalni_predmeti.Add(p);
                    }
                }
                return legalni_predmeti;

            }

            moguciPredmetiZaDodati = new ObservableCollection<Predmet>(moguciPredmeti(s.yearOfStudy));

            // dobio sam sve moguce predmete ali sad trebam izbaciti one koji se vec nalaze u polozenim i nepolozenim 
            foreach (var predmet in nepolozeni)
            {
                moguciPredmetiZaDodati.Remove(predmet);

            }

            foreach (var predmet in polozeni)
            {
                moguciPredmetiZaDodati.Remove(predmet);

            }


        }



        private void dodajClick(object sender, RoutedEventArgs e)
        {
            if (selektovan != null)
            {

                nepolozeni.Add(selektovan);

                Ocena o = new Ocena();   // sad ga trebam dodati u listu nepolozenih idstudenta - idocjene 

                o.predmetId = selektovan.PredmetId;
                o.studentId = student.studentId;
                o.grade = 0;
                o.date = DateTime.MinValue;


                ocjentactrl.Create(o);

                this.Close();
            }
            else
            {
                MessageBox.Show("SELEKTUJ PRVO!");
            }
        }

        private void odustaniClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
