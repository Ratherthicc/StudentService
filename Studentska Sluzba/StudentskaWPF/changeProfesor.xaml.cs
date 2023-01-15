using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using StudentskaWPF.Observer;
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
    /// Interaction logic for changeProfesor.xaml
    /// </summary>
    public partial class changeProfesor : Window, IObserver
    {

        private ProfesorController _profesorController;
        private KatedraController _katedraController;
        private PredmetController _predmetController;
        public ObservableCollection<Katedra> katedre1 { get; set; }
        public Profesor profesor { get; set; }
        public Katedra selectedKatedra { get; set; } 
        public Predmet selectedPredmet { get; set; }

        public ObservableCollection<Predmet> listaPredmeta { get; set; }
        public changeProfesor(Profesor p, ProfesorController controller)
        {
            InitializeComponent();
            DataContext = this;
            profesor = p;
            ime.Text = p.Name;
            prezime.Text = p.Surname;
            datRodj.Text = p.DateOfBirth.ToString();
            idAdrStanovanja.Text = p.adresaStanovanjaId.ToString();
            brojTel.Text = p.ContactPhone.ToString();
            emailAdr.Text = p.Email.ToString();
            idAdrKancelarije.Text = p.adresaKancelarijeId.ToString();
            zvanje.Text = p.Title.ToString();
            brLicneKarte.Text = p.IdNumber.ToString();
            godStaza.Text = p.YearsOfTrail.ToString();

            _katedraController = new KatedraController();
            _profesorController = controller;
            _predmetController = new PredmetController();

            katedre1 = new ObservableCollection<Katedra>(_katedraController.GetAllKatedra());
            listaPredmeta = new ObservableCollection<Predmet>(_predmetController.getPredmetByIdProf(profesor));

            _katedraController.Subscribe(this);
            _profesorController.Subscribe(this);
            _predmetController.Subscribe(this);

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
            profesor.Name = ime.Text;
            profesor.Surname = prezime.Text;

            String datrdj = datRodj.Text;
            DateTime datumrodj = DateTime.Parse(datrdj);
            profesor.DateOfBirth = datumrodj;

            profesor.adresaStanovanjaId = int.Parse(idAdrStanovanja.Text);
            profesor.ContactPhone = brojTel.Text;
            profesor.Email = emailAdr.Text;
            profesor.adresaKancelarijeId = int.Parse(idAdrKancelarije.Text);
            profesor.Title = zvanje.Text;
            profesor.IdNumber = brLicneKarte.Text;
            profesor.YearsOfTrail = int.Parse(godStaza.Text);

            _profesorController.Update(profesor);
            Close();
        }

        private void dodelaSefaKatedri_click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Da li ste sigurni da zelite da unesete izmenu?", "Upozorenje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((profesor.Title.ToLower() == "redovni profesor" || profesor.Title.ToLower() == "vanredni profesor") && profesor.YearsOfTrail > 4)
                {
                    _katedraController.dodelaSefaKatedri(profesor, selectedKatedra);
                    MessageBox.Show("Uspesna izmena!");
                }
                else
                    MessageBox.Show("Zvanje ili godine staza nisu dobre!");
            }

        }
        public void Update()
        {
            listaPredmeta.Clear();
            foreach(var predmet in _predmetController.getPredmetByIdProf(profesor))
            {
                listaPredmeta.Add(predmet);
            }
        }

        private void dodajPredmet_click(object sender, RoutedEventArgs e)
        {
        }

        private void ukloniPredmet_click(object sender, RoutedEventArgs e)
        {

            if (selectedPredmet == null)
                MessageBox.Show("Morate izabrati predmet za uklanjanje!");
            else
            if (MessageBox.Show("Da li ste sigurni da zelite da uklonite predmet?", "Ukloni predmet", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _predmetController.deletePredmetByPredmet(selectedPredmet);
                Update();
                MessageBox.Show("Uspesno uklonjen predmet!");
            }
        }
    }
}
