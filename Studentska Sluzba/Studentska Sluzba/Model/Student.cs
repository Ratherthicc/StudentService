using StudentskaSluzba.Manager.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
   public class Student : Serializable, INotifyPropertyChanged
    {
        public int studentId { get; set; }
        public String name { get; set; }

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("name"); }
        }
        public String surname { get; set; }

        public String Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("surname"); }
        }
        public DateTime dateOfBirth { get; set; }
        public Adresa adress { get; set; }
        public int adresaId { get; set; }
        public String phoneNumber { get; set; }
        public String email { get; set; }
        public String idNumber { get; set; }

        public String IdNumber
        {
            get { return idNumber; }
            set { idNumber = value; OnPropertyChanged("idNumber"); }
        }
        public int yearOfEnrollment { get; set; }
        public int YearOfEnrollment
        {
            get { return yearOfEnrollment; }
            set { yearOfEnrollment = value; OnPropertyChanged("yearOfEnrollment"); }
        }

        public int yearOfStudy { get; set; }
        public Status methodOfFinancing { get; set; }

        public Status MethodOfFinancing
        {
            get { return methodOfFinancing; }
            set { methodOfFinancing = value; OnPropertyChanged("yearOfEnrollment"); }
        }
        public float avgGrade { get; set; }

        public float AvgGrade
        {
            get { return avgGrade; }
            set { avgGrade = value; OnPropertyChanged("avgGrade"); }
        }

        public List<Predmet> gradesPassedSubjects;
        public List<Predmet> remainingSubjects;

        public enum Status { B = 0, S = 1 };
        public Student() {
            gradesPassedSubjects = new List<Predmet>();
            remainingSubjects = new List<Predmet>();
        }

        // Constructor:
        public Student( String name,String surname,DateTime dateOfBirth,int adresaId, String phoneNumber, String email,String idNumber,int yearOfEnrollment,
            int yearOfStudy,Status methodOfFinancing)
          
         
        {
           
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.adresaId = adresaId;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.idNumber = idNumber;
            this.yearOfEnrollment = yearOfEnrollment;
            this.yearOfStudy = yearOfStudy;
            this.methodOfFinancing = methodOfFinancing;
          
           
            gradesPassedSubjects = new List<Predmet>();
            remainingSubjects = new List<Predmet>();
           

        }

      
      

       

     
        public string[] ToCSV()
        {
          

            string[] csvValues =
            {
                this.studentId.ToString(),
                this.idNumber.ToString(),
                this.name,
                this.surname,
                this.dateOfBirth.ToString( "dd/MM/yyyy"),
                this.adresaId.ToString(),
                this.phoneNumber,
                this.email,
                this.yearOfEnrollment.ToString(),
                this.yearOfStudy.ToString(),
                 this.methodOfFinancing.ToString(),
             
               
              // Napomena2: Ovi atributi klase se ne serijalizuju, potrebno je napraviti tabelu koja 
              // modeluje veze student-ocena i student-predmet ( odnost vise na vise )..

              /*private List<Ocena> gradesPassedSubjects;
                private List<Predmet> remainingSubjects;*/

            };
            return csvValues;
        }

        // Data read:
        public void FromCSV(string[] values)
        {
            this.studentId = int.Parse(values[0]);
            this.idNumber = values[1];
            this.name = values[2];
            this.surname = values[3];
            this.dateOfBirth = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
            this.adresaId= Convert.ToInt32(values[5]);
            this.phoneNumber = values[6];
            this.email = values[7];
            this.yearOfEnrollment = int.Parse(values[8]);
            this.yearOfStudy = int.Parse(values[9]);
            this.methodOfFinancing = Enum.Parse<Status>(values[10]);
         
                
        }




        public override string ToString()
        {
            string string0 = String.Format("\nPrezime: {0}" +
                                           "\nIme: {1}" +
                                           "\nDatum rodjenja: {2}" +
                                           "\nAdresa Stanovanja: {3}" +
                                           "\nKontakt Telefon: {4}" +
                                           "\nEmail Adresa: {5}" +
                                           "\nBroj indeksa: {6}" +
                                           "\nGodina upisa: {7}" +
                                           "\nTrenutna godina studija: {8}" +
                                           "\nStatus: {9}" +
                                           "\nProsecna ocena: {10}",
                                           surname, name, dateOfBirth, adresaId, phoneNumber, email,
                                           idNumber, yearOfEnrollment, yearOfStudy, methodOfFinancing, avgGrade);
            string string1 = "\nSpisak polozenih ispita: ";
            if (gradesPassedSubjects.Count() == 0)
            {
                string1 += "NEMA";
            }
            else
            {
                foreach (Predmet o in gradesPassedSubjects)
                {
                    string1 += o.ToString();
                }
            }

            string string2 = "\nSpisak nepolozenih ispita: ";
            if (remainingSubjects.Count() == 0)
            {
                string2 += "NEMA";
            }
            else
            {
                foreach (Predmet p in remainingSubjects)
                {
                    string2 += p.ToString();
                }
            }

            return string0 + string1 + string2;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }





    }
}

