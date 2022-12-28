 using StudentskaSluzba.Manager.Serializer;
using StudentskaSluzba.model;

using System;
using System.Collections.Generic;
using System.Text;

namespace StudentskaSluzba.Manager
{
    internal class ProfesorManager
    {
       
            public List<Profesor> profesori;
            private Serializer<Profesor> serializer;

            private readonly string fileName = "profesor.txt";

            public ProfesorManager()
            {
                serializer = new Serializer<Profesor>();
                LoadProfesori();
            }

            private void LoadProfesori()
            {
                profesori = serializer.FromCSV(fileName);
            }

            private void SaveProfesori()
            {
                serializer.ToCSV(fileName, profesori);
            }





            public Profesor AddProfesor(Profesor x)
            {
                
                profesori.Add(x);

                SaveProfesori();
                return x;
            }
            public Profesor? RemoveProfesor(int id)
            {
                Profesor x = GetAdreseeById(id);
                if (x == null) return null;

                profesori.Remove(x);
                SaveProfesori();
                return x;
            }

            public Profesor GetAdreseeById(int id)
            {
                return profesori.Find(match: v => v.profesorId == id);
            }

            public List<Profesor> GetAllProfesors()
            { 



                return profesori;
            }
        }
    }



