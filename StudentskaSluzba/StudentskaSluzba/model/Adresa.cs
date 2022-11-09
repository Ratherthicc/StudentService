using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentskaSluzba.model
{
    class Adresa
    {
        private String street;
        private String streetNumber; //
        private String town;
        private String country;

        public Adresa() { }

        public Adresa(String street, String streetNumber, String town, String country)
        {

            this.street = street;
            this.streetNumber = streetNumber;
            this.town = town;
            this.country = country;
        }


    public String Street
        {
            get { return street; }
            set { street = value; }
        }
  

    public String StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }

        public String Town
        {
            get { return town; }
            set { town = value; }
        }

        public String Country
        {
            get { return country; }
            set { country = value; }
        }




    }
    }

