using StudentskaSluzba.model;
using StudentskaWPF.Observer;
using StudentskaWPF.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.DAOModel
{
    class DAOPredmet : ISubject
    {

        private List<IObserver> observers;

        private PredmetStorage storage;
        private List<Predmet> predmeti;

        public DAOPredmet()
        {
            storage = new PredmetStorage();
            predmeti = storage.Load();
            observers = new List<IObserver>();
        }

        public int NextId()
        {
            return predmeti.Max(s => s.PredmetId) + 1;
        }

        public void Add(Predmet predmet)
        {
            predmet.PredmetId = NextId();
            predmeti.Add(predmet);
            storage.Save(predmeti);
            NotifyObservers();
        }

        public void Remove(Predmet predmet)
        {
            predmeti.Remove(predmet);
            storage.Save(predmeti);
            NotifyObservers();
        }

        public void Update(Predmet predmet)
        {
            int index = predmeti.FindIndex(p => p.PredmetId == predmet.PredmetId);
            if (index != -1)
            {
                predmeti[index] = predmet;
            }

            storage.Save(predmeti);
            NotifyObservers();
        }
        //nisam siguran dal ce ovo raditi
        public List<Predmet> GetAll()
        {
            return predmeti;
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

        public List<Predmet> getPredmetListByProfId(Profesor profesor)
        { 
            List<Predmet> tempPredmeti = new List<Predmet>();

                foreach (Predmet p in GetAll())
                    {
                    if (p.ProfesorId == profesor.profesorId)
                        tempPredmeti.Add(p);
                    }

            return tempPredmeti;
        }

        public void deletePredmetByPredmetId(int id)
        {
            predmeti.Find(p => p.PredmetId == id).ProfesorId = -1;
            storage.Save(predmeti);
            NotifyObservers();
        }

        public List<Predmet> getPredmetiNotTeachedByProfessor(Profesor profesor)
        {
            List<Predmet> tempPredmeti = new List<Predmet>();

            foreach (Predmet p in GetAll())
            {
                if (p.ProfesorId != profesor.profesorId)
                {
                    tempPredmeti.Add(p);
                }
            }

            return tempPredmeti;
        }
    }
}
