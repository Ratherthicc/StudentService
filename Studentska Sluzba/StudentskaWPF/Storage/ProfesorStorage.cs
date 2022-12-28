using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.Storage
{
    class ProfesorStorage
    {
        private const string putanja = "../../Data/profesori.csv";

        private Serializer<Profesor> serializer;
    public ProfesorStorage()
        {
            serializer = new Serializer<Profesor>();
        }
     public List<Profesor> Load()
        {
            return serializer.FromCSV(putanja);
        }

     public void Save(List<Profesor> profesori)
        {
            serializer.ToCSV(putanja, profesori);
        }

    }
}

