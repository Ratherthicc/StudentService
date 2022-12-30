using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.Storage
{
    class StudentStorage
    {
        private const string putanja = "../../../Data/studenti.csv";

        private Serializer<Student> serializer;


        public StudentStorage()
        {
            serializer = new Serializer<Student>();
        }

        public List<Student> Load()
        {
            return serializer.FromCSV(putanja);
        }

        public void Save(List<Student> students)
        {
            serializer.ToCSV(putanja, students);
        }
    }

}
