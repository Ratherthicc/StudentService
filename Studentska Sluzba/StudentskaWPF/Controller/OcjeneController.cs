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
    public class OcjeneController
    {
        private DAOOcjene ocjene;

        public OcjeneController()
        {
            ocjene = new DAOOcjene();
        }

        public List<Ocena> GetAllOcjene()
        {
            return ocjene.GetAll();
        }

        public void Create(Ocena o)
        {
            ocjene.Add(o);
        }

        public void Delete(Ocena o)
        {
            ocjene.Remove(o);
        }

      

        public void Subscribe(IObserver observer)
        {
            ocjene.Subscribe(observer);
        }
    }
}
