using ConsoleAppExample.Manager.Serialization;
using StudentskaSluzba.model;
using StudentskaSluzba.Serializer;
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
            public Profesor RemoveAdresa(string id)
            {
                Profesor x = GetAdreseeById(id);
                if (x == null) return null;

                profesori.Remove(x);
                SaveProfesori();
                return x;
            }

            public Profesor GetAdreseeById(string id)
            {
                return profesori.Find(v => v.IdNumber == id);
            }

            public List<Profesor> GetAllProfesors()
            {
                return profesori;
            }
        }
    }



