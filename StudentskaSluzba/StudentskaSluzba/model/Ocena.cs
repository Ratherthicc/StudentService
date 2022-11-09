using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Ocena
    {
        private Student student;
        private Predmet subject;
        private byte grade;
        private DateTime date;

        public Ocena() { }

        public Ocena(Student student, Predmet subject, byte grade, DateTime date)
        {

            this.student = student;
            this.subject = subject;
            this.grade = grade;
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

        public byte Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public DateTime Date

        {
            get { return date; }
            set { date = value; }
        }


    }
}

