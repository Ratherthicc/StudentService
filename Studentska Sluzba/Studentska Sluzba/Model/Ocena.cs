using StudentskaSluzba.Manager.Serializer;

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
        public Student student;
        public int studentId;
        public Predmet subject;
        public int predmetId;
        public int grade;
        public DateTime date;

        public Ocena() {
        this. student = new Student();
        this. subject = new Predmet();
        }

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
            string string00 = "\nOcjenaID: " + OcjenaNaIspituId.ToString();
            string string0 = "\nStudentID: " + studentId.ToString();
            string string1 = "\nPredmetID: " + predmetId.ToString();
            string string2 = "\nOcena iz predmeta: " + grade;
            string string3 = "\nDatum polaganja: " + date.ToString();

            return string00 + string0 + string1 + string2 + string3;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                OcjenaNaIspituId.ToString(),
                studentId.ToString(),
                predmetId.ToString(),
                grade.ToString(),
                date.ToString( "dd/MM/yyyy"),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            OcjenaNaIspituId = int.Parse(values[0]);
            studentId = int.Parse(values[1]);
            predmetId = int.Parse(values[2]);
            grade = int.Parse(values[3]);
            date = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
        }
    }
}


