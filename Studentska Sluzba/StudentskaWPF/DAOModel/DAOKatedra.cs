using StudentskaSluzba.model;
using StudentskaWPF.Controller;
using StudentskaWPF.Observer;
using StudentskaWPF.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaWPF.DAOModel
{
    internal class DAOKatedra : ISubject
    {
        private List<IObserver> observers;

        private KatedraStorage storage;
        private List<Katedra> katedra;
        
        public DAOKatedra()
        {
            storage = new KatedraStorage();
            katedra = storage.Load();
            observers = new List<IObserver>();
           
        }



        public void Add(Katedra k)
        {

            katedra.Add(k);
            storage.Save(katedra);
            NotifyObservers();
        }

        public void Remove(Katedra k)
        {
            katedra.Remove(k);
            storage.Save(katedra);
            NotifyObservers();
        }


        public List<Katedra> GetAll()
        {
            return katedra;
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

        public void dodelaSefaKatedri(Profesor profesor, Katedra selectedKatedra)
        {
            Katedra katedraTemp = new Katedra();
            List<Katedra> katedraList = storage.Load();
            katedraTemp = katedraList.Find(k => k.IdKatedre == selectedKatedra.IdKatedre);
            katedraTemp.Idchairman = int.Parse(profesor.IdNumber);

            storage.Save(katedraList);
        }

    }
}

