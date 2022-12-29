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
using StudentskaSluzba.model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentskaWPF.Controller;

namespace StudentskaWPF
{
    /// <summary>
    /// Interaction logic for addPredmet.xaml
    /// </summary>
    public partial class AddPredmet : Window, INotifyPropertyChanged
    {
        PredmetController control;
        public Predmet Predmet { get; set; }

        public AddPredmet(PredmetController controller)
        {
          
            InitializeComponent();

            DataContext = this;
            Predmet = new Predmet();
            control = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
