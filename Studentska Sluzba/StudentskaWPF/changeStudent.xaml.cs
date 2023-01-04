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
using static StudentskaSluzba.model.Student;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for changeStudent.xaml
    /// </summary>
    public partial class changeStudent : Window, INotifyPropertyChanged
    {
        private StudentController studentcontroller;
        public Student Student { get; set; }

        public changeStudent(StudentController controller, Student s)
        {
            InitializeComponent();
            DataContext = this;
            Student = s;
            ime.Text = s.Name;
            prezime.Text = s.Surname;
            datRodj.Text = s.dateOfBirth.ToString();
            idAdrStanovanja.Text = s.adresaId.ToString();
            brojTel.Text = s.phoneNumber;
            emailAdr.Text = s.email;
            brIndeksa.Text = s.idNumber;
            godUpisa.Text = s.yearOfEnrollment.ToString();
            trenutnaGodStudija.Text = s.yearOfStudy.ToString();
            nacinFinansiranja.Text = s.methodOfFinancing.ToString();



            studentcontroller = controller;
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
            Student.name = ime.Text;
            Student.surname = prezime.Text;
            String datrdj = datRodj.Text;
            DateTime datumrodj = DateTime.Parse(datrdj);
            Student.dateOfBirth = datumrodj;

            Student.adresaId = int.Parse(idAdrStanovanja.Text);
            Student.phoneNumber = brojTel.Text;
            Student.email = emailAdr.Text;
            Student.idNumber = brIndeksa.Text;

            String gu = godUpisa.Text;
           
            Student.yearOfEnrollment = int.Parse(gu);


            String tgu = trenutnaGodStudija.Text;
            int trenutnagod = int.Parse(tgu);
            Student.yearOfStudy = trenutnagod;

            String nacfn = nacinFinansiranja.Text;


            if (nacfn == "B")
            {
                Status nacin_fin = Status.B;
                Student.methodOfFinancing = nacin_fin;

            }
            else if (nacfn == "S")
            {
                Status nacin_fin = Status.S;
                Student.methodOfFinancing = nacin_fin;
            }


            
                studentcontroller.Update(Student);
                Close();
          
               
            }
    }
}
