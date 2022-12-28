using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzba.Manager.Serializer;


namespace StudentskaSluzba.model
{
    public class Katedra : Serializable
    {
        public int IdKatedre;
        private String departmentCode;
        private String departmentName;
        public Profesor chairman;
        public int Idchairman;
        public List<Profesor> lecturers;

        public Katedra() { 
        lecturers = new List<Profesor>();

        }

        public Katedra(int IdKatedre,String departmentCode, String departmentName, Profesor chairman)
        {
            this.IdKatedre = IdKatedre;
            this.departmentCode = departmentCode;
            this.departmentName = departmentName;
            this.chairman = chairman;
            lecturers= new List<Profesor>();
            Idchairman = chairman.profesorId;
        }

        

        public String DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        public String DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public Profesor Chairman
        {
            get { return chairman; }
            set { chairman = value; }
        }

   
        public List<Profesor> Lecturers
        {
            get { return lecturers; }
            set { lecturers = value; }
        }

        // Defining methods from Serializable..
        // Data input:

        public override string ToString()
        {
            string string5 = "\nID katedre: " + IdKatedre.ToString();
            string string0 = "\nSifra katedre: " + DepartmentCode.ToString();
        
            string string2 = "\nNaziv katedre: " + departmentName;
            string string3 = "\nSef katedre: " + Idchairman;
            string string4 = "\nProfesori na katedri: " + lecturers.ToString(); // nece da ispise listu??

            return string0 + string2 + string3 + string4 + string5;
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                IdKatedre.ToString(),
                departmentCode,
                departmentName,
                Idchairman.ToString(),
            };

            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            IdKatedre = int.Parse(values[0]);
            departmentCode = (values[1]);
            departmentName = values[2];
            Idchairman = int.Parse(values[3]);
        }
    }
}
                