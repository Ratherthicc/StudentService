using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using StudentskaSluzba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Manager
{
    internal class PolaganjeManager
    {

        public List<StudentiPredmet> Studenti_koji_su_PredmetPolozili;
        public List<StudentiPredmet> Studenti_koji_nisu_PredmetPolozili;
        private Serializer<StudentiPredmet> serializer1;
        private Serializer<StudentiPredmet> serializer2;

        private readonly string fileName1 = "Studenti_koji_su_PredmetPolozili.txt";
        private readonly string fileName2 = "Studenti_koji_nisu_PredmetPolozili.txt";

        public PolaganjeManager()
        {
            serializer1 = new Serializer<StudentiPredmet>();
            serializer2 = new Serializer<StudentiPredmet>();
            StudentiPolozili();
            StudentiNisuPolozili();
        }

        private void StudentiPolozili()
        {
            Studenti_koji_su_PredmetPolozili = serializer1.FromCSV(fileName1);
        }

        private void StudentiNisuPolozili()
        {
            Studenti_koji_nisu_PredmetPolozili = serializer2.FromCSV(fileName2);
        }

        private void SaveSpisak()
        {
            serializer1.ToCSV(fileName1, Studenti_koji_su_PredmetPolozili);
           
        }

        private void SaveSpisak2()
        {
           
            serializer2.ToCSV(fileName2, Studenti_koji_nisu_PredmetPolozili);
        }






        public StudentiPredmet AddStudentiPolozili(StudentiPredmet x)
        {

            Studenti_koji_su_PredmetPolozili.Add(x);
            SaveSpisak();
            return x;
        }

        public StudentiPredmet AddStudentiNisuPolozili(StudentiPredmet y)
        {

            Studenti_koji_nisu_PredmetPolozili.Add(y);
            SaveSpisak2();
            return y;
        }



        public List<StudentiPredmet> getStudentiPolozili()
        {

            return Studenti_koji_su_PredmetPolozili;
        }

        public List<StudentiPredmet> getStudentiNisuPolozili()
        {

            return Studenti_koji_nisu_PredmetPolozili;
        }
    }
}
