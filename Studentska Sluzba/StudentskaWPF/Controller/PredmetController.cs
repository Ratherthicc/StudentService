using StudentskaSluzba.model;
using StudentskaWPF.DAOModel;
using StudentskaWPF.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.Controller
{
    public class PredmetController
    {
        private DAOPredmet predmeti;

        public PredmetController()
        {
            predmeti = new DAOPredmet();
        }

        public List<Predmet> GetAllPredmet()
        {
            return predmeti.GetAll();
        }

        public void Create(Predmet predmet)
        {
            predmeti.Add(predmet);
        }

        public void Delete(Predmet predmet)
        {
            predmeti.Remove(predmet);
        }

        public void Update(Predmet predmet)
        {
            predmeti.Update(predmet);
        }

        public void Subscribe(IObserver observer)
        {
            predmeti.Subscribe(observer);
        }

        public List<Predmet> getPredmetByIdProf(Profesor profesor)
        {
            List<Predmet> tempPredmeti = new List<Predmet>();

            foreach ( Predmet p in predmeti.GetAll())
                {
                if (p.ProfesorId == profesor.profesorId)
                    tempPredmeti.Add(p);
                }

            return tempPredmeti;
        }
    }
}
