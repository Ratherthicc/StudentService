using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using StudentskaWPF.Observer;
using System.Xml.Serialization;
using StudentskaWPF.DAOModel;
using StudentskaWPF.Storage;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {

        private StudentController studentController;
        public ObservableCollection<Student> listastudenata { get; }
        public Student SelectedStudent { get; set; }

        private ProfesorController profesorcontroller;
        public ObservableCollection<Profesor> listaprofesora { get; }
        public Profesor SelectedProfesor { get; set; }

        private PredmetController predmetcontroller;
        public ObservableCollection<Predmet> listapredmeta { get; }
        public Predmet SelectedPredmet { get; set; }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }


        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;



            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();



            studentController = new StudentController();
            studentController.Subscribe(this);
            listastudenata = new ObservableCollection<Student>(studentController.GetAllStudents());

            profesorcontroller = new ProfesorController();
            profesorcontroller.Subscribe(this);
            listaprofesora = new ObservableCollection<Profesor>(profesorcontroller.GetAllProfesor());

            predmetcontroller = new PredmetController();
            predmetcontroller.Subscribe(this);
            listapredmeta = new ObservableCollection<Predmet>(predmetcontroller.GetAllPredmet());





        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
              // var otvoriAddStudent = new AddStudent(_studentcontroller);
                // otvoriAddStudent.Show();
            }
            else if (tabControl.SelectedIndex == 1)
            {
            //    var otvoriAddProfesor = new AddProfesor(_profesorcontroller);
            //    otvoriAddProfesor.Show();
            }
            else if (tabControl.SelectedIndex == 2)
            {
               var AddPredmet = new AddPredmet(predmetcontroller);
               AddPredmet.Show();
            }
        }


        private void delete_click(object sender, RoutedEventArgs e)
        {

            if (tabControl.SelectedIndex == 0)
            {
                if (SelectedStudent != null)
                {
                    MessageBoxResult result = ConfirmStudentDeletion();
                    if (result == MessageBoxResult.Yes)
                    {
                        studentController.Delete(SelectedStudent);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati studenta za brisanje");
                }
            }
            else if (tabControl.SelectedIndex == 1)
            {
                if (SelectedProfesor != null)
                {
                    MessageBoxResult result = ConfirmProfesorDeletion();
                    if (result == MessageBoxResult.Yes)
                    {
                        profesorcontroller.Delete(SelectedProfesor);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati profesora za brisanje");
                }
            }
            else if (tabControl.SelectedIndex == 2)
            {
                if (SelectedPredmet != null)
                {
                    MessageBoxResult result = ConfirmPredmetDeletion();
                    if (result == MessageBoxResult.Yes)
                    {
                            predmetcontroller.Delete(SelectedPredmet);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet za brisanje");
                }
            }
        }

        

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            dateBlock.Text = DateTime.Now.ToString();
        }


        private MessageBoxResult ConfirmStudentDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete stuenta\n{SelectedStudent}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmProfesorDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete profesora\n{SelectedProfesor}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete predmet\n{SelectedPredmet}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                if (SelectedStudent != null)
                {
                    string sMessageBoxText = $"Prikaz studenta\n{SelectedStudent}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati studenta za prikaz");
                }

            }
            else if (tabControl.SelectedIndex == 1)
            {
                if (SelectedProfesor != null)
                {
                    string sMessageBoxText = $"Prikaz profesora\n{SelectedProfesor}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati profesora za prikaz");
                }

            }
            else if (tabControl.SelectedIndex == 2)
            {
                if (SelectedPredmet != null)
                {
                    string sMessageBoxText = $"Prikaz predmeta\n{SelectedPredmet}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet za prikaz");
                }

            }

        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StudentStorage st = new StudentStorage();
            ProfesorStorage ps = new ProfesorStorage();
            PredmetStorage pt = new PredmetStorage();

            st.Save(studentController.GetAllStudents());
            ps.Save(profesorcontroller.GetAllProfesor());
            pt.Save(predmetcontroller.GetAllPredmet());
        }

        private void UpdateText(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                textUpdateTab.Text = "Studenti";
            else if (tabControl.SelectedIndex == 1)
                textUpdateTab.Text = "Profesori";
            else if (tabControl.SelectedIndex == 2)
                textUpdateTab.Text = "Predmeti";
        }

        private void UpdateStudentsList()
        {
            listastudenata.Clear();
            foreach (var student in studentController.GetAllStudents())
            {
                listastudenata.Add(student);
            }
        }

        private void UpdateProfesorList()
        {
            listaprofesora.Clear();
            foreach (var profesor in profesorcontroller.GetAllProfesor())
            {
                listaprofesora.Add(profesor);
            }
        }

        private void UpdatePredmetList()
        {
            listapredmeta.Clear();
            foreach (var predmet in predmetcontroller.GetAllPredmet())
            {
                listapredmeta.Add(predmet);
            }
        }

        public void Update()
        {
            UpdateStudentsList();
            UpdateProfesorList();
            UpdatePredmetList();
        }
    }
}
