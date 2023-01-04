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
    class DAOProfesor: ISubject
    {

        private List<IObserver> observers;

        private ProfesorStorage storage;
        private List<Profesor> profesori;

        public DAOProfesor()
        {
            storage = new ProfesorStorage();
            profesori = storage.Load();
            observers = new List<IObserver>();
        }

        public int NextId()
        {
            return profesori.Max(s => s.profesorId) + 1;
        }

        public void Add(Profesor profesor)
        {
            profesor.profesorId = NextId();
            profesori.Add(profesor);
            storage.Save(profesori);
            NotifyObservers();
        }

        public void Remove(Profesor profesor)
        {
            profesori.Remove(profesor);
            storage.Save(profesori);
            NotifyObservers();
        }

       public void Update(Profesor profesor)
        {
            int index = profesori.FindIndex(p => p.profesorId == profesor.profesorId);
            if (index != -1)
            {
                profesori[index] = profesor;
            }

            storage.Save(profesori);
            NotifyObservers();
        }
           //nisam siguran dal ce ovo raditi
        public List<Profesor> GetAll()
        {
            return profesori;
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

