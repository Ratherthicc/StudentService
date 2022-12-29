
using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Manager
{
    internal class StudentManager
    {

        public List<Student> studenti;
        private Serializer<Student> serializer;

        private readonly string fileName = "student.txt";

        public StudentManager()
        {
            serializer = new Serializer<Student>();
            LoadStudenti();
        }

        private void LoadStudenti()
        {
            studenti = serializer.FromCSV(fileName);
        }

        private void SaveStudenti()
        {
            serializer.ToCSV(fileName, studenti);
        }





        public Student AddStudent(Student x)
        {

            studenti.Add(x);
            SaveStudenti();
            return x;
        }
        public Student RemoveStudent(int id)
        {
            Student x = GetStudentById(id);
            if (x == null) return null;

            studenti.Remove(x);
            SaveStudenti();
            return x;
        }

        public Student GetStudentById(int id)
        {
            return studenti.Find(v => v.studentId == id);
        }

        public List<Student> GetStudents()
        {
            return studenti;
        }
    }
}
