using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.Storage
{
    internal class OcjeneStorage
    {
        private const string putanja = "../../../Data/ocjene.csv";



        private Serializer<Ocena> serializer;

        public OcjeneStorage()
        {
            serializer = new Serializer<Ocena>();
        }

        public List<Ocena> Load()
        {
            return serializer.FromCSV(putanja);
        }

        public void Save(List<Ocena> ocjene)
        {
            serializer.ToCSV(putanja, ocjene);
        }
    }
}

