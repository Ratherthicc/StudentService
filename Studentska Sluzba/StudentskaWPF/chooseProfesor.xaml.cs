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
using System.Windows.Shapes;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for chooseProfesor.xaml
    /// </summary>
    public partial class chooseProfesor : Window
    {
        public Predmet _predmet;
        public changePredmet _changePredmet;
        public PredmetController _predmetController;
        public ProfesorController _profesorController;
        public ObservableCollection<Profesor> _profesori { get; set; }  
        public Profesor _selectedProfesor { get; set; }

        public chooseProfesor(PredmetController predmetcontroller, Predmet p, changePredmet cp)
        {
            InitializeComponent();
            DataContext = this;
            _changePredmet = cp;
            _predmetController = predmetcontroller;
            _profesorController = new ProfesorController();
            _profesori = new ObservableCollection<Profesor>(_profesorController.GetAllProfesor());
            _predmet = p;
        }

        private void potvrda_click(object sender, RoutedEventArgs e)
        {
            if (_selectedProfesor == null)
                MessageBox.Show("Morate izabrati profesora!");
            else
            {
                if (MessageBox.Show("Da li ste sigurni?", "Biranje profesora", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _changePredmet.idprofesora.Text = _selectedProfesor.Name + " " + _selectedProfesor.Surname;
                    this.Close();
                }
            }
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
