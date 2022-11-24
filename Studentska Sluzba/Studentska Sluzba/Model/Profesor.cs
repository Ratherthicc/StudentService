using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzba.Serializer;

namespace StudentskaSluzba.model
{
    class Profesor  : Serializable
    {
        public int profesorId { get; set; }
        private String surname;
        private String name;
        private DateTime dateOfBirth;
        private Adresa residentialAddress;
        public int AdresaStanovanjaId { get; set; }
        private String contactPhone;
        private String email;
        private Adresa officeAddress;
        public int AdresaKancelarijeId { get; set; } //
        private String idNumber;
        private String title;
        private int yearsOfTrail;
        private List<Predmet> teachSubjects;
        

        public Profesor() {
            teachSubjects = new List<Predmet>();
            Adresa residentialAdress = new Adresa();
            Adresa officeAddress = new Adresa();

        }

        public Profesor(int profesorId, String surname, String name, DateTime dateOfBirth, Adresa residentialAddress, String contactPhone,
                String email, Adresa officeAddress, String idNumber, String title, int yearsOfTrail
                )
        {
            this.profesorId = profesorId;
            this.surname = surname;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.residentialAddress = residentialAddress;
            this.contactPhone = contactPhone;
            this.email = email;
            this.officeAddress = officeAddress;
            this.idNumber = idNumber;
            this.title = title;
            this.yearsOfTrail = yearsOfTrail;
            teachSubjects = new List<Predmet>();
            AdresaStanovanjaId = this.residentialAddress.id;
            AdresaKancelarijeId = this.officeAddress.id;

        }


        public string Surname
        {
            get { return surname; } // get metoda
            set { surname = value; } // set metoda
        }



        public string Name
        {
            get { return name; } // get metoda
            set { name = value; } // set metoda
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
            set { email = value; }
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
            set { title = value; }
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
                Surname,
                Name,
                DateOfBirth.ToString( "dd/MM/yyyy"),
                AdresaStanovanjaId.ToString(),
                ContactPhone.ToString(),
                Email,
                AdresaKancelarijeId.ToString(),
                IdNumber,
                Title,
                yearsOfTrail.ToString()

            };
            return csvValues;
        }

        // Data output:
        public void FromCSV(string[] values)
        {

            profesorId = Convert.ToInt32(values[0]);
            Surname = values[1];
            Name = values[2];
            DateOfBirth = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
            AdresaStanovanjaId = Convert.ToInt32(values[4]);
            ContactPhone = values[5];
            Email = values[6];

            AdresaKancelarijeId = Convert.ToInt32(values[7]);

            IdNumber = values[8];
            Title = values[9];
            YearsOfTrail = int.Parse(values[10]);
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
                                           surname, name, dateOfBirth,AdresaStanovanjaId, contactPhone, email,
                                           AdresaKancelarijeId, idNumber, title, yearsOfTrail);

            string string1 = "\nPredmeti: ";
            foreach (Predmet p in teachSubjects)
            {
                string1 += p.ToString();
            }

            return string0 + string1;
        }







    }
}

