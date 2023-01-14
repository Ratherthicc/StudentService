using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.Storage
{
    internal class KatedraStorage
    {
        private const string putanja = "../../../Data/katedra.csv";



        private Serializer<Katedra> serializer;

        public KatedraStorage()
        {
            serializer = new Serializer<Katedra>();
        }

        public List<Katedra> Load()
        {
            return serializer.FromCSV(putanja);
        }

        public void Save(List<Katedra> katedra)
        {
            serializer.ToCSV(putanja, katedra);
        }
    }
}
