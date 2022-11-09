using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Predmet
    {
        private String id;
        private String name;
        private Semmester semester;
        private byte yearOfStudy;
        private Profesor professor;
        private byte espb;
        private List<Student> studentsPassed;
        private List<Student> studentsRemaining;

        public enum Semmester
        {

            SUMMER,
            WINTER

        }

        public Predmet() { }

        public Predmet(String id, String name, Semmester semester, byte yearOfStudy, Profesor professor, byte espb,
            List<Student> studentsPassed, List<Student> studentsRemaining)
        {

            this.id = id;
            this.name = name;
            this.semester = semester;
            this.yearOfStudy = yearOfStudy;
            this.professor = professor;
            this.espb = espb;

            this.studentsPassed = studentsPassed;
            this.studentsRemaining = studentsRemaining;
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

        public byte YearOfStudy
        {
            get { return yearOfStudy; }
            set { yearOfStudy = value; }
        }

        public Profesor Profesor
        {
            get { return professor; }
            set { professor = value; }
        }


        public byte Espb
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






    }
}