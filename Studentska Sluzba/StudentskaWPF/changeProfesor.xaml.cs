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

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for changeProfesor.xaml
    /// </summary>
    public partial class changeProfesor : Window
    {

        private ProfesorController _profesorController;
        public Profesor profesor { get; set; }
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

            _profesorController = controller;

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
    }
}
