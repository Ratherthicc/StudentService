
using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;

using System;

using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Manager
{
    internal class AdresaManager
    {
        public List<Adresa> adrese;
        private Serializer<Adresa> serializer;

        private readonly string fileName = "adrese.txt";

        public AdresaManager()
        {
            serializer = new Serializer<Adresa>();
            LoadAdrese();
        }

        private void LoadAdrese()
        {
            adrese = serializer.FromCSV(fileName);
        }

        private void SaveAdrese()
        {
            serializer.ToCSV(fileName, adrese);
        }

      
      



        public Adresa AddAdresa(Adresa adresa)
        {
           
            adrese.Add(adresa);
            SaveAdrese();
            return adresa;
        }
        public Adresa RemoveAdresa(int id)
        {
            Adresa adresa = GetAdreseeById(id);
            if (adresa == null) return null;

            adrese.Remove(adresa);
            SaveAdrese();
            return adresa;
        }

        public Adresa GetAdreseeById(int id)
        {
            return adrese.Find(v => v.id == id);
        }

        public List<Adresa> GetAllAdresses()
        {
            
            return adrese;
        }


    
    }
}

    

