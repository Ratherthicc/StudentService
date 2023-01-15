using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for polaganje.xaml
    /// </summary>
    public partial class polaganje : Window, INotifyPropertyChanged
    {
        public Predmet predmet;
        public ObservableCollection<Predmet> polozeni;
        public ObservableCollection<Predmet> nepolozeni;
        public OcjeneController ocjenactrl;
        public Student student;
        public changeStudent cs;
        public polaganje(Predmet p, ObservableCollection<Predmet> nepoloz, ObservableCollection<Predmet> poloz,  OcjeneController o, changeStudent s, Student ss) 
        {
            InitializeComponent();
            ocjenactrl = o;
            student = ss;
            polozeni = poloz;
            nepolozeni = nepoloz;
            predmet = p;
            label3.Content = p.Id;
            label4.Content = p.Name;
            cs = s;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Click_potvrdi(object sender, RoutedEventArgs e)
        {
            if (predmet == null)
            {
                MessageBox.Show("Morate izabrati predmet za polaganje");
            }
            else
            {
               
                Ocena o = new Ocena();
                foreach (Ocena ocj in ocjenactrl.GetAllNepolozeni())
                {
                    if (ocj.predmetId == predmet.PredmetId && student.studentId == ocj.studentId)
                    {
                        ocjenactrl.DeleteNepolozeni(ocj);
                        o = ocj;
                        break;
                    }
                }

                o.grade = int.Parse(textBox2.Text);
                o.date = DateTime.Parse(textBox3.Text);
                ocjenactrl.Create(o);
                polozeni.Add(predmet);
                nepolozeni.Remove(predmet);

                cs.Update();
                this.Close();
            }
        }

        private void Click_odustani(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
