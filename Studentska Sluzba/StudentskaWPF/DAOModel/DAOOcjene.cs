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
    public class DAOOcjene: ISubject
    {

        private List<IObserver> observers;

        private OcjeneStorage storage;
        private List<Ocena> ocjene;

        public DAOOcjene()
        {
            storage = new OcjeneStorage();
            ocjene = storage.Load();
            observers = new List<IObserver>();
        }

        public int NextId()
        {
            return ocjene.Max(s => s.OcjenaNaIspituId) + 1;
        }

        public void Add(Ocena o)
        {
            o.OcjenaNaIspituId = NextId();
            ocjene.Add(o);
            storage.Save(ocjene);
            NotifyObservers();
        }

        public void Remove(Ocena o)
        {
            ocjene.Remove(o);
            storage.Save(ocjene);
            NotifyObservers();
        }

     
        public List<Ocena> GetAll()
        {
            return ocjene;
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
    }
}
