using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzba.Serializer;

namespace StudentskaSluzba.model
{
    class Predmet : Serializable
    {
        public int PredmetId;
        private String id;
        private String name;
        private Semmester semester;
        private int yearOfStudy;
        private Profesor professor;
        public int ProfesorId { get; set; }
        private int espb;
        private List<Student> studentsPassed;
        private List<Student> studentsRemaining;

        public enum Semmester
        {

            SUMMER,
            WINTER

        }

        public Predmet() {
            studentsPassed = new List<Student>();
            studentsRemaining = new List<Student>();
        }

        public Predmet(int PredmetId , String id, String name, Semmester semester, int yearOfStudy, Profesor professor, int espb
           )
        {
            this.PredmetId = PredmetId;
            this.id = id;
            this.name = name;
            this.semester = semester;
            this.yearOfStudy = yearOfStudy;
            this.professor = professor;
            this.espb = espb;
            ProfesorId = this.professor.profesorId;
            studentsPassed = new List<Student>();
            studentsRemaining = new List<Student>();
            ProfesorId = this.professor.profesorId;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }




        public String Name
        {
            get { return name; }
            set { name = value; }
        }



        public Semmester Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public int YearOfStudy
        {
            get { return yearOfStudy; }
            set { yearOfStudy = value; }
        }

        public Profesor Profesor
        {
            get { return professor; }
            set { professor = value; }
        }


        public int Espb
        {
            get { return espb; }
            set { espb = value; }
        }



        public List<Student> StudentsRemaining
        {
            get { return studentsRemaining; }
            set { studentsRemaining = value; }
        }


        public List<Student> StudentsPassed
        {
            get { return studentsPassed; }
            set { studentsPassed = value; }
        }

        // Defining methods from Serializable..

        // Napomena: Procitati napomene 2 i 3 iz klasa Student i Profesor.

        // Data input:
        public string[] ToCSV()
        {
            string sem = this.semester == Semmester.SUMMER ? "SUMMER" : "WINTER";
            string[] csvValues =
            {
                PredmetId.ToString(),
                this.id,
                this.name,
                sem,
                this.yearOfStudy.ToString(),
                ProfesorId.ToString(),
                this.espb.ToString()
            };

            return csvValues;
        }

        // Data read:
        public void FromCSV(string[] values)
        {
            PredmetId = int.Parse(values[0]);
            this.id = values[1];
            this.name = values[2];
            this.semester = values[3] == "SUMMER" ? Semmester.SUMMER : Semmester.WINTER;
            this.yearOfStudy =int.Parse(values[4]);
            ProfesorId.ToString(values[5]);
            this.espb = (byte)int.Parse(values[6]);
        }


        public override string ToString()
        {
            string string0 = String.Format("\nPredmet ID: {0}" +
                                           "\nSifra predmeta: {1}" +
                                           "\nNaziv predmeta: {2}" +
                                           "\nGodina na kojoj se predmet izvodi: {3}" +
                                           "\nPredmetni profesor: {4}" +
                                           "\nESPB bodovi: {5}",
                                           PredmetId, Id, Name, YearOfStudy, ProfesorId, Espb);


            return string0;
        }








    }
}