using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Profesor
    {
        private String surname;
        private String name;
        private DateTime dateOfBirth;
        private Adresa residentialAddress;
        private String contactPhone;
        private String email;
        private Adresa officeAddress; //
        private String idNumber;
        private String title;
        private short yearsOfTrail;
        private List<Predmet> teachSubjects;
        

        public Profesor() { }

        public Profesor(String surname, String name, DateTime dateOfBirth, Adresa residentialAddress, String contactPhone,
                String email, Adresa officeAddress, String idNumber, String title, short yearsOfTrail, List<Predmet> teachSubjects
                )
        {

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
            this.teachSubjects = teachSubjects;
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


        public short YearsOfTrail

        {
            get { return yearsOfTrail; }
            set { yearsOfTrail = value; }
        }




 

        public List<Predmet> TeachSubjects

        {
            get { return teachSubjects; }
            set { teachSubjects = value; }
        }
    }
}

