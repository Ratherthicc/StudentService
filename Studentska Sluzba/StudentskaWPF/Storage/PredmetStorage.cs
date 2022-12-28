using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;
using StudentskaSluzba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;


namespace StudentskaWPF.Storage
{
    class PredmetStorage
    {

        private const string StoragePath = "../../Data/predmeti.csv";

        

        private Serializer<Predmet> serializer;

        public PredmetStorage()
        {
            serializer = new Serializer<Predmet>();
        }

        public List<Predmet> Load()
        {
            return serializer.FromCSV(StoragePath);
        }

        public void Save(List<Predmet> predmeti)
        {
            serializer.ToCSV(StoragePath, predmeti);
        }
    }



}
