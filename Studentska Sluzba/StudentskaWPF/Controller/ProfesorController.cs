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
    class ProfesorController
    {

        private DAOProfesor profesori;

        public ProfesorController()
        {
            profesori = new DAOProfesor();
        }

        public List<Profesor> GetAllProfesor()
        {
            return profesori.GetAll();
        }

        public void Create(Profesor profesor)
        {
            profesori.Add(profesor);
        }

        public void Delete(Profesor profesor)
        {
            profesori.Remove(profesor);
        }

        public void Update(Profesor profesor)
        {
         //   profesori.Update(profesor);
        }

        public void Subscribe(IObserver observer)
        {
            profesori.Subscribe(observer);
        }
    
}
}
