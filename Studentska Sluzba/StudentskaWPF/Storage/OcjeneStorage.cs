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
        private const string putanja2 = "../../../Data/nepolozeni.csv";



        private Serializer<Ocena> serializer;
        private Serializer<Ocena> serializer2;

        public OcjeneStorage()
        {
            serializer = new Serializer<Ocena>();
            serializer2 = new Serializer<Ocena>();
            
    }

        public List<Ocena> Load()
        {
            return serializer.FromCSV(putanja);
        }

        public List<Ocena> Load2()
        {
            return serializer2.FromCSV(putanja2);
        }


        public void Save(List<Ocena> ocjene)
        {
            serializer.ToCSV(putanja, ocjene);
            

        }

        public void Save2(List<Ocena> ocjene)
        {
            serializer2.ToCSV(putanja2, ocjene);


        }



    }
}

