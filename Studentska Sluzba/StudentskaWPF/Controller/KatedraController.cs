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
    class KatedraController
    {
        private DAOKatedra katedre;

        public KatedraController()
        {
            katedre = new DAOKatedra();
        }

        public List<Katedra> GetAllKatedra()
        {
            return katedre.GetAll();
        }

        public void Create(Katedra k)
        {
            katedre.Add(k);
        }

        public void Delete(Katedra k)
        {
            katedre.Remove(k);
        }

        public void Subscribe(IObserver observer)
        {
            katedre.Subscribe(observer);
        }

        public void dodelaSefaKatedri(Profesor profesor, Katedra selectedKatedra)
        {
            katedre.dodelaSefaKatedri(profesor, selectedKatedra);
        }
    }
}

