using StudentskaSluzba.Console;
using StudentskaSluzba.Manager;
using StudentskaSluzba.model;
using System;
using System.Threading.Tasks.Dataflow;

namespace StudentskaSluzba
{
    class Program
    {

        static void Main()
        {
            AdresaManager manager = new AdresaManager();
          
            ProfesorManager managerr = new ProfesorManager();
            PredmetManager predmet = new PredmetManager();
            KatedraManager katedra = new KatedraManager();
            StudentManager stud = new StudentManager();
            ConsoleViewAll view = new ConsoleViewAll(manager, managerr, predmet, katedra, stud);
            view.RunMenu();
        }
    }
}
