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
    /// Interaction logic for changeProfesorPredmet.xaml
    /// </summary>
    public partial class changeProfesorPredmet : Window
    {
        public ObservableCollection<Predmet> predmetiZaDodelu { get; set; }
        public Predmet selectedPredmet { get; set; }
        private PredmetController _predmetController;
        public Profesor profesor;
        ObservableCollection<Predmet> listaPredmeta;
        public MainWindow mainWin;
        public changeProfesorPredmet(PredmetController predmetController, Profesor p, ObservableCollection<Predmet> predmeti, MainWindow mw)
        {
            InitializeComponent();
            mainWin = mw;
            DataContext = this;
            listaPredmeta = predmeti;
            profesor = p;
            _predmetController = predmetController;
            predmetiZaDodelu = new ObservableCollection<Predmet>(_predmetController.getPredmetiNotTeachedByProfesor(profesor));
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void potvrda_click(object sender, RoutedEventArgs e)
        {
            if (selectedPredmet == null)
                MessageBox.Show("Morate izabrati predmet za dodavanje");
            else
            {
                _predmetController.Delete(selectedPredmet);
                selectedPredmet.Profesor = profesor;
                _predmetController.Create(selectedPredmet);
                listaPredmeta.Add(selectedPredmet);
                mainWin.Update();
                this.Close();
            }
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
