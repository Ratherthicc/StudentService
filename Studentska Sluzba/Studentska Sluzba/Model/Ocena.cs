using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Ocena : Serializable
    {
        public int OcjenaNaIspituId;
        private Student student;
        public int studentId;
        private Predmet subject;
        public int predmetId;
        private int grade;
        private DateTime date;

        public Ocena() { }

        public Ocena(int OcjenaNaIspituId, int studentId, int predmetId, DateTime date)
        {

            this.OcjenaNaIspituId = OcjenaNaIspituId;
            this.studentId = studentId;
            this.predmetId = predmetId;
            this.date = date;
        }

        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
      

        public Predmet Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public DateTime Date

        {
            get { return date; }
            set { date = value; }
        }

        public override string ToString()
        {
            string string0 = "\nStudent: " + student.ToString();
            string string1 = "\nPredmet: " + Subject.ToString();
            string string2 = "\nOcena iz predmeta: " + grade;
            string string3 = "\nDatum polaganja: " + date.ToString();

            return string0 + string1 + string2 + string3;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                OcjenaNaIspituId.ToString(),
                studentId.ToString(),
                predmetId.ToString(),
                grade.ToString(),
                date.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            OcjenaNaIspituId = int.Parse(values[0]);
            studentId = int.Parse(values[1]);
            predmetId = int.Parse(values[2]);
            grade = int.Parse(values[3]);
            date = DateTime.Parse(values[4]);
        }
    }
}


