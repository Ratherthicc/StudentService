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
        private List<Ocena> nepolozeni;

        public DAOOcjene()
        {
            storage = new OcjeneStorage();
            ocjene = storage.Load();
            nepolozeni = storage.Load2();
            observers = new List<IObserver>();
        }

        public int NextId()
        {
            return ocjene.Max(s => s.OcjenaNaIspituId) + 1;
        }

        public int NextId2()
        {
            return nepolozeni.Max(s => s.OcjenaNaIspituId) + 1;
        }

        public void Add(Ocena o)                       // SVAKA FUNKCIJA JE RADJENA U DVIJE VARIJANTE, ZA LISTU KOMBINACIJA STUDENT - PREDMET KOJI SU POLOZENI
                                                        // I ISTE TE KOMBINACIJE ZA PREDMETE KOJI SU NEPOLOZENI
        {     
            o.OcjenaNaIspituId = NextId();
            ocjene.Add(o);
            storage.Save(ocjene);
            NotifyObservers();
        }


        public void Add2(Ocena o)
        {
            o.OcjenaNaIspituId = NextId2();
            nepolozeni.Add(o);
            storage.Save2(ocjene);
            NotifyObservers();
        }

        public void Remove(Ocena o)
        {
            ocjene.Remove(o);
            storage.Save(ocjene);
            NotifyObservers();
        }

        public void Remove2(Ocena o)
        {
            nepolozeni.Remove(o);
            storage.Save2(nepolozeni);
            NotifyObservers();
        }

        public List<Ocena> GetAllPolozeni()
        {
            return ocjene;
        }

        public List<Ocena> GetAllNepolozeni()
        {
            return nepolozeni;
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
