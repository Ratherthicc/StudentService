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
  

     

        public List<Katedra> GetAllKatedras()
        {

            return katedre;
        }



    }
}
