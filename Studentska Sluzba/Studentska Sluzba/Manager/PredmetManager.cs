using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Manager
{
    internal class PredmetManager
    {

        private List<Predmet> predmeti;
        private Serializer<Predmet> ser;

        private readonly string fileName = "predmet.txt";

        public PredmetManager()
        {
            ser = new Serializer<Predmet>();
            LoadPredmeti();
        }

        private void LoadPredmeti()
        {
            predmeti = ser.FromCSV(fileName);
        }

        private void SavePredmeti()
        {
            ser.ToCSV(fileName, predmeti);
        }





        public Predmet AddPredmet(Predmet x)
        {

            predmeti.Add(x);
            SavePredmeti();
            return x;
        }
        public Predmet RemovePredmet(int id)
        {
            Predmet x = GetAdreseeById(id);
            if (x == null) return null;

            predmeti.Remove(x);
            SavePredmeti();
            return x;
        }

        public Predmet GetAdreseeById(int id)
        {
            return predmeti.Find(v => v.PredmetId == id);
        }

        public List<Predmet> GetAllSubjects()
        {
            return predmeti;
        }




    }
}
