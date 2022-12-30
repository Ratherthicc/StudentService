using StudentskaSluzba.model;
using StudentskaWPF.Controller;
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
using static StudentskaSluzba.model.Predmet;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for addStudent.xaml
    /// </summary>
    public partial class addStudent : Window
    {
        private Student student;
        private StudentController _studentController;


        public addStudent(StudentController st)
        {
            this.DataContext = this;
            InitializeComponent();
            _studentController = st;
            student = new Student();
        }


        private void Potvrda(object sender, RoutedEventArgs e)
        {


            String ime = ime1.Text;
            String prezime = prezime1.Text;
            String datrdj = datum.Text;
            DateTime datumrodj = DateTime.Parse(datrdj);

            String adrst = adresa.Text;
            int adresaid = int.Parse(adrst);

            String brtel = brojtel.Text;
            String email = email1.Text;
            String brindx = brojindeksa.Text;
            String gu = godinaupisa.Text;
            int godupis = string.IsNullOrEmpty(gu) ? 0 : int.Parse(gu);
            String nacfn = nacinfins.Text;
            String tgu = trenutnagodina.Text;
            String trenutnagod1 = trenutnagodina.Text;
            int trenutnagod = int.Parse(trenutnagod1);

            String nacin = nacinfins.Text;




            Student s = new Student(ime, prezime, datumrodj, adresaid, brtel, email, brindx, godupis, trenutnagod, 0);
            _studentController.Create(s);

        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}