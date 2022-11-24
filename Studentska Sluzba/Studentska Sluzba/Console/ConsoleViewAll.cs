using ConsoleAppExample.Manager.Serialization;
using StudentskaSluzba.Manager;
using StudentskaSluzba.Manager;
using StudentskaSluzba.model;
using StudentskaSluzba.Model;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace StudentskaSluzba.Console
{

    internal class ConsoleViewAll : ConsoleView


    {
        private PredmetManager pred;
        private PolaganjeManager polaganje;
        private AdresaManager manager;
        private ProfesorManager managerr;
        private KatedraManager katedra;
        private StudentManager s;
        private OcenaManager o;
        public ConsoleViewAll(AdresaManager manager, ProfesorManager managerr, PredmetManager pred, KatedraManager katedra, StudentManager s, OcenaManager o, PolaganjeManager polaganje)
        {
            this.manager = manager;
            this.managerr = managerr;
            this.pred = pred;
            this.katedra = katedra;
            this.s = s;
            this.o = o;
            this.polaganje = polaganje;
        }
        private void PrintAdrese(List<Adresa> adrese)
        {
            System.Console.WriteLine("Adrese: ");

            foreach (Adresa v in adrese)
            {
                System.Console.WriteLine(v);
            }
        }

        private void PrintProfesori(List<Profesor> profesors)
        {
            System.Console.WriteLine("Profesor: ");

            foreach (Profesor p in profesors)
            {
                System.Console.WriteLine(p);
            }
        }

        private void PrintPredmeti(List<Predmet> predmeti)
        {
            System.Console.WriteLine("Predmeti: ");

            foreach (Predmet p in predmeti)
            {
                System.Console.WriteLine(p);
            }
        }

        private void PrintKatedre(List<Katedra> katedre)
        {
            System.Console.WriteLine("Katedra: ");

            foreach (Katedra katt in katedre)
            {
                System.Console.WriteLine(katt);
            }
        }

        private void PrintStudenti(List<Student> s)
        {
            System.Console.WriteLine("Student: ");

            foreach (Student x in s)
            {
                System.Console.WriteLine(x);
            }
        }

        private void PrintOcjene(List<Ocena> s)
        {
            System.Console.WriteLine("Ocjene: ");

            foreach (Ocena x in s)
            {
                System.Console.WriteLine(x);
            }
        }


        private Adresa InputAdresa()
        {
            Adresa a1 = new Adresa();

            System.Console.WriteLine("Unesite id adrese: ");
            int c = SafeInputInt();
            a1.id = c;


            System.Console.WriteLine("Enter adresa name: ");
            string name = System.Console.ReadLine();
            a1.Street = name;

            System.Console.WriteLine("Enter number of street: ");
            string broj = System.Console.ReadLine();
            a1.StreetNumber = broj;

            System.Console.WriteLine("Enter town: ");
            string town = System.Console.ReadLine();
            a1.Town = town;


            System.Console.WriteLine("Enter country: ");
            string country = System.Console.ReadLine();
            a1.Country = country;

            return a1;
        }

        private Profesor InputProfesor()
        {
            Profesor p = new Profesor();

            System.Console.WriteLine("ID preofesora: ");
            int profesorId = SafeInputInt();
            p.profesorId = profesorId;




            System.Console.WriteLine("Unesite prezime profesora: ");
            string surname = System.Console.ReadLine();
            p.Surname = surname;

            System.Console.WriteLine("Unesite ime profesora: ");
            string name = System.Console.ReadLine();
            p.Name = name;

            System.Console.WriteLine("Unesite datum rodjenja: ");
            string datum = System.Console.ReadLine();
            p.DateOfBirth = DateTime.ParseExact(datum, "dd/MM/yyyy", null);


            p.ResidentialAddress = manager.adrese[1];
            p.AdresaStanovanjaId = manager.adrese[1].id;


            System.Console.WriteLine("Unesite broj telefona: ");
            string broj = System.Console.ReadLine();
            p.ContactPhone = broj;

            System.Console.WriteLine("Unesite mejl: ");
            string mejl = System.Console.ReadLine();
            p.Email = mejl;

            p.OfficeAddress = manager.adrese[3];
            p.AdresaKancelarijeId = manager.adrese[0].id;


            System.Console.WriteLine("Unesite jmbg: ");
            string xxx = System.Console.ReadLine();
            p.IdNumber = xxx;


            System.Console.WriteLine("Unesite zvanje: ");
            string x = System.Console.ReadLine();
            p.Title = x;





            System.Console.WriteLine("Unesite godine radnog staza: ");
            int wheels = SafeInputInt();
            p.YearsOfTrail = wheels;
            return p;
        }

        private Predmet InputPredmet()
        {
            Predmet predmet = new Predmet();

            System.Console.WriteLine("Unesite ID predmeta: ");
            int predmetId = SafeInputInt();
            predmet.PredmetId = predmetId;

            System.Console.WriteLine("Unesite sifru predmeta: ");
            string id = System.Console.ReadLine();
            predmet.Id = id;

            System.Console.WriteLine("Unesite naziv predmeta: ");
            string nazivPredmeta = System.Console.ReadLine();
            predmet.Name = nazivPredmeta;

            predmet.Semester = 0;

            System.Console.WriteLine("Unesite godinu na kojoj se predmet izvodi: ");
            int x = SafeInputInt();
            predmet.YearOfStudy = x;

            predmet.Profesor = managerr.profesori[0];
            predmet.ProfesorId = managerr.profesori[0].profesorId;

            System.Console.WriteLine("Unesite ESP bodove: ");
            int ESPB = SafeInputInt();
            predmet.Espb = ESPB;


            return predmet;


        }

        private Katedra InputKatedra()
        {
            Katedra k = new Katedra();
            System.Console.WriteLine("Unesite ID katedre: ");
            int katedraId = SafeInputInt();
            k.IdKatedre = katedraId;

            System.Console.WriteLine("Unesite sifru katedre: ");
            string sifra = (System.Console.ReadLine());
            k.DepartmentCode = sifra;

            System.Console.WriteLine("Unesite naziv katedre: ");
            String naziv = System.Console.ReadLine();
            k.DepartmentName = naziv;

            k.Chairman = managerr.profesori[0];
            k.Idchairman = managerr.profesori[0].profesorId;

            k.lecturers.Add(managerr.profesori[0]);


            return k;
        }

        private Student inputStudent()
        {
            Student student = new Student();

            System.Console.WriteLine("ID studenta: ");
            int studentId = SafeInputInt();
            student.studentId = studentId;

            System.Console.WriteLine("Ime: ");
            string name = System.Console.ReadLine();
            student.name = name;

            System.Console.WriteLine("Prezime: ");
            string prezime = System.Console.ReadLine();
            student.surname = prezime;

            System.Console.WriteLine("Datum Rodjenja: ");
            DateTime datumRodjenja = Convert.ToDateTime(System.Console.ReadLine());
            student.dateOfBirth = datumRodjenja;


            student.address = manager.adrese[1];
            student.adresaId = manager.adrese[1].id;

            System.Console.WriteLine("Kontakt telefon: ");
            string brTelefona = System.Console.ReadLine();
            student.phoneNumber = brTelefona;

            System.Console.WriteLine("Email adresa: ");
            string email = System.Console.ReadLine();
            student.email = email;

            System.Console.WriteLine("Broj indeksa: ");
            string brIndeksa = System.Console.ReadLine();
            student.idNumber = brIndeksa;
            //  brIndeksa.ToLower();

            System.Console.WriteLine("Godina upisa: ");
            int godinaUpisa = SafeInputInt();
            student.yearOfEnrollment = godinaUpisa;

            System.Console.WriteLine("Trenutna godina studija: ");
            int trenutnaGod = SafeInputInt();
            student.yearOfStudy = trenutnaGod;

            System.Console.WriteLine("Nacin finansiranja (0 za Budzet ili 1 za Samofinansiranje): ");
            int status = SafeInputInt();
            student.methodOfFinancing = (Student.Status)status;

            System.Console.WriteLine("Prosjecna ocjena: ");
            float p = SafeInputFloat();
            student.avgGrade = p;


            return student;
        }

        private Ocena inputOcena()
        {
            Ocena ocjena = new Ocena();

            System.Console.WriteLine("Unesite ID ocene na predmetu: ");
            int ocenaId = SafeInputInt();
            ocjena.OcjenaNaIspituId = ocenaId;

            System.Console.WriteLine("Unesite ID studenta: ");
            int studentId = SafeInputInt();
            ocjena.studentId = studentId;

            System.Console.WriteLine("Unesite ID predmeta: ");
            int predmetId = SafeInputInt();
            ocjena.predmetId = predmetId;

            System.Console.WriteLine("Unesite ocenu (od 6 do 10): ");
            int ocijena;
            do
            {
                ocijena = SafeInputInt();
            } while (ocijena < 6 || ocijena > 10);
            ocjena.grade = ocijena;

            System.Console.WriteLine("Unesite datum polaganja: ");
            string s = System.Console.ReadLine();
            ocjena.date = DateTime.ParseExact(s, "dd/MM/yyyy", null);


            return ocjena;




        }

        private void AddAdresa()
        {
            Adresa a1 = InputAdresa();
            manager.AddAdresa(a1);
            System.Console.WriteLine("Adresa added");
        }

        private void AddProfesor()
        {
            Profesor a1 = InputProfesor();
            managerr.AddProfesor(a1);
            System.Console.WriteLine("Profesor added");
        }

        private void AddPredmet()
        {
            Predmet a1 = InputPredmet();
            pred.AddPredmet(a1);
            System.Console.WriteLine("Predmet added");
        }

        private void AddKatedra()
        {
            Katedra a1 = InputKatedra();
            katedra.AddKatedra(a1);
            System.Console.WriteLine("Katedra added");

        }

        private void AddStudent()
        {
            Student m = inputStudent();
            s.AddStudent(m);
            System.Console.WriteLine("Student added");

            StudentiPredmet x = new StudentiPredmet(m.studentId, 1);
            polaganje.AddStudentiPolozili(x);
            System.Console.WriteLine("polaganje added");

            StudentiPredmet y = new StudentiPredmet(m.studentId, 2);
            polaganje.AddStudentiNisuPolozili(y);
            System.Console.WriteLine("polaganje added");



        }

        private void AddOcjena()
        {
            Ocena m = inputOcena();
            o.AddOcjena(m);
            System.Console.WriteLine("Ocjena added");

        }

        private void ShowMenu()
        {
            System.Console.WriteLine("\nChoose an option: ");
            System.Console.WriteLine("1: Prikazi sve adrese");
            System.Console.WriteLine("2: Dodaj adresu");
            System.Console.WriteLine("3: Prikazi profesore");
            System.Console.WriteLine("4: Dodaj profesora");
            System.Console.WriteLine("5: Dodaj predmet");
            System.Console.WriteLine("6: Prikazi predmete");
            System.Console.WriteLine("7: Prikazi katedre");
            System.Console.WriteLine("8: Dodaj katedre");
            System.Console.WriteLine("9: Prikazi studente");
            System.Console.WriteLine("10: Dodaj studenta");
            System.Console.WriteLine("11: Prikazi ocjene");
            System.Console.WriteLine("12: Dodaj ocjene");
            System.Console.WriteLine("13: izbrisi adresu");
            System.Console.WriteLine("14: izbrisi katedru");
            System.Console.WriteLine("15: izbrisi studenta");
            System.Console.WriteLine("16: izbrisi profesora");
            System.Console.WriteLine("17: izbrisi predmet");
            System.Console.WriteLine("18: izbrisi Ocjenu");
            System.Console.WriteLine("19: prikaz studenata i polozenih ispita");
            System.Console.WriteLine("20: prikaz studenata i nepolozenih ispita");





            System.Console.WriteLine("0: Close");
        }
        public void RunMenu()
        {
            while (true)
            {
                ShowMenu();
                string userInput = System.Console.ReadLine();
                if (userInput == "0") break;
                HandleMenuInput(userInput);
            }
        }

        public void brisanje()
        {
            System.Console.WriteLine("unesite id adrese koju zelite izbrisati: ");
            int n = SafeInputInt();
            manager.RemoveAdresa(n);
        }

        public void brisanjeKatedre()
        {
            System.Console.WriteLine("unesite id katedre koju zelite izbrisati: ");
            int n = SafeInputInt();
            katedra.RemoveKatedra(n);

        }

        public void brisanjeStudenta()
        {
            System.Console.WriteLine("unesite id studenta kojeg zelite izbrisati: ");
            int n = SafeInputInt();
            s.RemoveStudent(n);
        }

        public void brisanjeProfesora()
        {
            System.Console.WriteLine("unesite id profesora kojeg zelite izbrisati: ");
            int n = SafeInputInt();

            managerr.RemoveProfesor(n);
        }

        public void brisanjePredmeta()
        {
            System.Console.WriteLine("unesite id predmeta kog zelite izbrisati: ");
            int n = SafeInputInt();
            s.RemoveStudent(n);

        }

        public void brisanjeOcjene()
        {
            System.Console.WriteLine("unesite id ocjene koju zelite izbrisati: ");
            int n = SafeInputInt();
            o.RemoveOcjena(n);

        }

        public void prikazPolaganja()
        {

            System.Console.WriteLine("spisak parova studentID - predmed POLAGANJA ");

             List<StudentiPredmet> spisak = polaganje.getStudentiPolozili();
            foreach (StudentiPredmet v in spisak)
            {
                System.Console.WriteLine(v);
            }
        }

        public void prikazNepoolaganja()
        {

            System.Console.WriteLine("spisak parova studentID - predmed NEPOLOZENIH ");

            List<StudentiPredmet> spisak = polaganje.getStudentiNisuPolozili();
            foreach (StudentiPredmet v in spisak)
            {
                System.Console.WriteLine(v);
            }
        }

        private int InputId()
        {
            System.Console.WriteLine("unesi id: ");
            int n = SafeInputInt();
            return n;
        }

  




        private void HandleMenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    PrintAdrese(manager.GetAllAdresses());
                    break;
                case "2":
                    AddAdresa();
                    break;
                case "3":
                    PrintProfesori(managerr.GetAllProfesors());
                    break;
                case "4":
                    AddProfesor();
                    break;
                case "5":
                    AddPredmet();
                    break;
                case "6":
                    PrintPredmeti(pred.GetAllSubjects());
                    break;
                case "7":
                    PrintKatedre(katedra.GetAllKatedras());
                    break;
                case "8":
                    AddKatedra();
                    break;
                case "9":
                    PrintStudenti(s.GetStudents());
                    break;
                case "10":
                    AddStudent();
                    break;
                case "11":
                    PrintOcjene(o.GetAllOcjene());
                    break;
                case "12":
                    AddOcjena();    
                    break;
                case "13":
                    brisanje();
                    break;
                case "14":
                    brisanjeKatedre();
                    break;
                case "15":
                    brisanjeStudenta();
                    break;
                case "16":
                    brisanjeProfesora();
                    break;
                case "17":
                    brisanjePredmeta();
                    break;
                case "18":
                    brisanjeOcjene();
                    break;
                case "19":
                    prikazPolaganja();
                    break;
                case "20":
                    prikazNepoolaganja();
                    break;


            }


         
        }
    }
}

