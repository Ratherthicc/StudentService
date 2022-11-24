using ConsoleAppExample.Manager.Serialization;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Manager
{
    internal class KatedraManager
    {
        public List<Katedra> katedre;
        private Serializer<Katedra> serializer;

        private readonly string fileName = "katedre.txt";

        public KatedraManager()
        {
            serializer = new Serializer<Katedra>();
            LoadKatedre();
        }

        private void LoadKatedre()
        {
            katedre = serializer.FromCSV(fileName);
        }

        private void SaveKatedre()
        {
            serializer.ToCSV(fileName, katedre);
        }






        public Katedra AddKatedra(Katedra katedra)
        {

            katedre.Add(katedra);
            SaveKatedre();
            return katedra;
        }

        public Katedra RemoveKatedra(int id)
        {
            Katedra x = GetKatedreaid(id);
            if (x == null) return null;

            katedre.Remove(x);
            SaveKatedre();
            return x;
        }

        public Katedra GetKatedreaid(int id)
        {
            return katedre.Find(v => v.IdKatedre == id);
        }


        public List<Katedra> GetAllKatedras()
        {

            return katedre;
        }



    }
}
