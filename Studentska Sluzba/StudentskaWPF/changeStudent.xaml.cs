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
using static StudentskaSluzba.model.Student;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for changeStudent.xaml
    /// </summary>
    public partial class changeStudent : Window, INotifyPropertyChanged
    {
        public Predmet selektovan { get; set; }

        public Predmet selektovan1 { get; set; }




        private StudentController studentcontroller;
        private OcjeneController ocjenecontroller;
        private PredmetController predmetcontroller;

        public ObservableCollection<Predmet> predmeti;
        public ObservableCollection<Predmet> polozeni { get; }
        public ObservableCollection<Predmet> nepolozeni { get; }


        public Student Student { get; set; }

        public changeStudent(StudentController controller, Student s)
        {
            predmetcontroller = new PredmetController();
            ocjenecontroller = new OcjeneController();

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
            nepolozeni = new ObservableCollection<Predmet>();
            polozeni = new ObservableCollection<Predmet>();

            studentcontroller = controller;

            foreach (var ocjena in ocjenecontroller.GetAllOcjene())       // pravljenje liste polozenih predmeta na osnovu ID polja u studentu i predmetu
            {
                if (ocjena.studentId == s.studentId)
                {
                    foreach (var predmet in predmetcontroller.GetAllPredmet())
                    {
                        if (predmet.PredmetId == ocjena.predmetId)
                        {

                            polozeni.Add(predmet);
                        }
                    }
                }
            }


            foreach (var ocjena in ocjenecontroller.GetAllNepolozeni())       // pravljenje liste polozenih predmeta na osnovu ID polja u studentu i predmetu
            {
                if (ocjena.studentId == s.studentId)
                {
                    foreach (var predmet in predmetcontroller.GetAllPredmet())
                    {
                        if (predmet.PredmetId == ocjena.predmetId)
                        {

                            nepolozeni.Add(predmet);
                        }
                    }
                }
            }





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

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string sMessageBoxText = $"Zelite li da ponistite ocjenu?\n{selektovan}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmPredmetDeletion2()
        {
            string sMessageBoxText = $"Zelite li da ponistite predmet\n{selektovan1}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
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

        private void Update()
        {
            studentcontroller.Update(Student);
        }

        private void ponisti(object sender, RoutedEventArgs e)
        {
            if (selektovan != null)
            {

                MessageBoxResult r = ConfirmPredmetDeletion();
                if (r == MessageBoxResult.Yes)
                {
                    Ocena ocjena = new Ocena();
                    foreach (Ocena i in ocjenecontroller.GetAllOcjene())
                    {
                        if (Student.studentId == i.studentId)
                        {
                            ocjenecontroller.Delete(i);
                            ocjena = i;
                            break;
                        }
                    }

                          ocjena.grade = 0;
                          ocjena.date = DateTime.MaxValue;
                         
                          ocjenecontroller.CreateNepolozeni(ocjena);
                          nepolozeni.Add(selektovan);
                          nepolozeni.Remove(selektovan);
                          this.Update();
                    
                }
            }
        }


        private void dodaj_button(object sender, RoutedEventArgs e)
        {
            var noviPredmet = new dodajPredmet(predmetcontroller,ocjenecontroller,polozeni,nepolozeni,Student);
            noviPredmet.Show();

        }
       




    }
}