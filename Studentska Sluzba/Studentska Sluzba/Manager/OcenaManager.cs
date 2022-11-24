using ConsoleAppExample.Manager.Serialization;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Manager
{
    internal class OcenaManager
    {
        public List<Ocena> ocjenenaispitu;
        private Serializer<Ocena> serializer;

        private readonly string fileName = "ocjene.txt";

        public OcenaManager()
        {
            serializer = new Serializer<Ocena>();
            LoadOcjene();
        }

        private void LoadOcjene()
        {
            ocjenenaispitu = serializer.FromCSV(fileName);
        }

        private void SaveOcjene()
        {
            serializer.ToCSV(fileName, ocjenenaispitu);
        }






        public Ocena AddOcjena(Ocena x)
        {

            ocjenenaispitu.Add(x);
            SaveOcjene();
            return x;
        }
        public Ocena? RemoveOcjena(int id)
        {
            Ocena x = GetOcjenaById(id);
            if (x == null) return null;

            ocjenenaispitu.Remove(x);
            SaveOcjene();
            return x;
        }

        public Ocena GetOcjenaById(int id)
        {
            return ocjenenaispitu.Find(v => v.OcjenaNaIspituId == id);
        }

        public List<Ocena> GetAllOcjene()
        {

            return ocjenenaispitu;
        }
    }
}
