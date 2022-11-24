using StudentskaSluzba.Manager;
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
            OcenaManager ocena = new OcenaManager();
            PolaganjeManager polaganje = new PolaganjeManager();
            ConsoleViewAll view = new ConsoleViewAll(manager, managerr, predmet, katedra, stud,ocena,polaganje);
            view.RunMenu();
        }
    }
}
