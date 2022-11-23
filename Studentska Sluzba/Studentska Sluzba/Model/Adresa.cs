using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace StudentskaSluzba.model
{
    class Adresa : Serializable
    {
        public int id { get; set; }
        private String street;
        private String streetNumber;
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

        public override string ToString()
        {
            string string5 = "\nid adrese: " + id;
            string string0 = "\nUlica: " + street;
            string string1 = "\nBroj: " + streetNumber;
            string string2 = "\nGrad: " + town;
            string string3 = "\nDrzava: " + country;

            return string5 + string0 + string1 + string2 + string3;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id.ToString(),
                street,
                streetNumber,
                town,
                country
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id = int.Parse(values[0]);
            street = values[1];
            streetNumber = values[2];
            town = values[3];
            country = values[4];
        }
    }
}



