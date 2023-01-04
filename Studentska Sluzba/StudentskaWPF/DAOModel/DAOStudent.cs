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
    class DAOStudent: ISubject
    {
        private List<IObserver> observers;

        private StudentStorage storage;
        private List<Student> studenti;

        public DAOStudent()
        {
            storage = new StudentStorage();
            studenti = storage.Load();
            observers = new List<IObserver>();
        }

        public int NextId()
        {
            return studenti.Max(s => s.studentId) + 1;
        }

        public void Add(Student student)
        {
            student.studentId = NextId();
            studenti.Add(student);
            storage.Save(studenti);
            NotifyObservers();
        }

        public void Remove(Student student)
        {
            studenti.Remove(student);
            storage.Save(studenti);
            NotifyObservers();
        }

        public void Update(Student student)
        {

            int index = studenti.FindIndex(s => s.studentId == student.studentId);

            if (index != -1)
            {
                studenti[index] = student;
            }
            storage.Save(studenti);
            NotifyObservers();



        }   //nisam siguran hoce li ovo raditi takodje

        public List<Student> GetAll()
        {
            return studenti;
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

