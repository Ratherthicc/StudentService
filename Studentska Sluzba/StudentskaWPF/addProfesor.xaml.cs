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
    /// Interaction logic for addProfesor.xaml
    /// </summary>
    public partial class addProfesor : Window
    {
    

        ProfesorController _profesorcontroller;
        public Profesor Profesor { get; set; }

        public addProfesor(ProfesorController controller)
        {
            InitializeComponent();
            DataContext = this;
            Profesor = new Profesor();

            _profesorcontroller = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

         
            String ime = ime1.Text;
            String prezime = prezime1.Text;
            String datrdj = datum.Text;
            DateTime datumRodj = DateTime.Parse(datrdj);
            String adrst1 = adresastan.Text;
            int adrst = int.Parse(adrst1);
            String brtel = telefon.Text;
            String email = email1.Text;
            String idkan1 = adresakanc.Text;
            int idkan = int.Parse(idkan1);

            String brlic = brojlicne.Text;
            String zvanje = zvanje1.Text;
            String godst = godina.Text;
            int godineStaza = string.IsNullOrEmpty(godst) ? -1 : int.Parse(godst);
           

            Profesor p= new Profesor( prezime, ime, datumRodj, adrst, brtel, email, idkan, brlic, zvanje, godineStaza);

       
                _profesorcontroller.Create(p);
                Close();
            
         


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     
    }
}
