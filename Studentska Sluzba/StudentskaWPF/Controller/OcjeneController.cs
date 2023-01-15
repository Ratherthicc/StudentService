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
            return ocjene.GetAllPolozeni();
        }

        public List<Ocena> GetAllNepolozeni()
        {
            return ocjene.GetAllNepolozeni();
        }

        public void Create(Ocena o)
        {
            ocjene.Add(o);
        }

        public void CreateNepolozeni(Ocena o)
        {
            ocjene.Add2(o);
        }
        public void Delete(Ocena o)
        {
            ocjene.Remove(o);
        }

        public void DeleteNepolozeni(Ocena o)
        {
            ocjene.Remove2(o);
        }

        public void Subscribe(IObserver observer)
        {
            ocjene.Subscribe(observer);
        }
    }
}
