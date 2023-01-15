using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzba.Manager.Serializer;


namespace StudentskaSluzba.model
{
    public class Profesor  : Serializable, INotifyPropertyChanged
    {
        public int profesorId { get; set; }
        private String surname;
        private String name;
        private DateTime dateOfBirth;
        private Adresa residentialAddress;
        public int adresaStanovanjaId { get; set; }
        private String contactPhone;
        private String email;
        private Adresa officeAddress;
        public int adresaKancelarijeId { get; set; } //
        private String idNumber;
        private String title;
        private int yearsOfTrail;
        private List<Predmet> teachSubjects;
        private String nameAndSurname;
        

        public Profesor() {
            teachSubjects = new List<Predmet>();
            Adresa residentialAdress = new Adresa();
            Adresa officeAddress = new Adresa();
            this.nameAndSurname = this.name + this.surname;

        }

        public Profesor( String surname, String name, DateTime dateOfBirth, int adresaStanovanjaId, String contactPhone,
                String email, int AdresaKancelarijeId, String idNumber, String title, int yearsOfTrail
                )
        {
           
            this.surname = surname;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
         
            this.contactPhone = contactPhone;
            this.email = email;
          
            this.idNumber = idNumber;
            this.title = title;
            this.yearsOfTrail = yearsOfTrail;
           
            this.adresaStanovanjaId = adresaStanovanjaId;
            this.adresaKancelarijeId = AdresaKancelarijeId;

            this.nameAndSurname = this.name + " " + this.surname;

        }


        public string Surname
        {
            get { return surname; } // get metoda
            set { surname = value; OnPropertyChanged("surname"); }
        }



        public string Name
        {
            get { return name; } // get metoda
            set { name = value; OnPropertyChanged("name"); }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; } 
            set { dateOfBirth = value; } 
        }


        public Adresa ResidentialAddress
        {
            get { return residentialAddress; }
            set { residentialAddress = value; }
        }

     
        public String ContactPhone
        {
            get { return contactPhone; }
            set { contactPhone = value; }
        }


        public String Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("email"); }
        }


        public Adresa OfficeAddress
        {
            get { return officeAddress; }
            set { officeAddress = value; }
        }

        public String IdNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }


        public String Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("title"); }
        }

        public String NameAndSurname
        {
            get { return this.name + " " + this.surname; }
            set { nameAndSurname = value; OnPropertyChanged("nameAndSurname"); }
        }
        public int YearsOfTrail

        {
            get { return yearsOfTrail; }
            set { yearsOfTrail = value; }
        }

        public List<Predmet> TeachSubjects

        {
            get { return teachSubjects; }
            set { teachSubjects = value; }
        }

        // Defining methods from Serializable..

        // Napomena1: Redosled upisa polja klase mora biti isti kao redosled ispisa..

        // Napomena3: Lista predmeta koji profesor predaje se ne serijalizuje, potrebno
        // je napraviti posebnu tabelu koja modeluje odnos profesor-predmeti ( veza vise na vise )..

        // Data input:
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                profesorId.ToString(),
                surname,
                name,
                dateOfBirth.ToString( "dd/MM/yyyy"),
                adresaStanovanjaId.ToString(),
                contactPhone.ToString(),
                email,
                adresaKancelarijeId.ToString(),
                idNumber,
                title,
                yearsOfTrail.ToString()

            };
            return csvValues;
        }

        // Data output:
        public void FromCSV(string[] values)
        {

            profesorId = Convert.ToInt32(values[0]);
            surname = values[1];
            name = values[2];
            dateOfBirth = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
            adresaStanovanjaId = Convert.ToInt32(values[4]);
            contactPhone = values[5];
            email = values[6];

            adresaKancelarijeId = Convert.ToInt32(values[7]);

            idNumber = values[8];
            title = values[9];
            yearsOfTrail = int.Parse(values[10]);
        }



        public override string ToString()
        {
            string string0 = String.Format("\nPrezime: {0}" +
                                           "\nIme: {1}" +
                                           "\nDatum rodjenja: {2}" +
                                           "\nID Adresa Stanovanja: {3}" +
                                           "\nKontakt Telefon: {4}" +
                                           "\nEmail Adresa: {5}" +
                                           "\nID Adresa Kancelarije: {6}" +
                                           "\nBroj licne karte: {7}" +
                                           "\nZvanje: {8}" +
                                           "\nGodine staza: {9}",
                                           surname, name, dateOfBirth, adresaStanovanjaId, contactPhone, email,
                                           adresaKancelarijeId, idNumber, title, yearsOfTrail);
            string string1 = "\nPredmeti: ";
            return string1;
        }
       /*     foreach (Predmet p in teachSubjects)
            {
                string1 += p.ToString();
            }

            return string0 + string1;

        } */

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }




    }
}

