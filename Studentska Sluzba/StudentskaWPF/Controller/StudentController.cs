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
   public class StudentController
    {

        private DAOStudent studenti;

        public StudentController()
        {
            studenti = new DAOStudent();
        }

        public List<Student> GetAllStudents()
        {
            return studenti.GetAll();
        }

        public void Create(Student student)
        {
            studenti.Add(student);
        }

        public void Delete(Student student)
        {
            studenti.Remove(student);
        }

        public void Update(Student student)
        {
          //  studenti.Update(student);
        }

        public void Subscribe(IObserver observer)
        {
            studenti.Subscribe(observer);
        }
    }
}

