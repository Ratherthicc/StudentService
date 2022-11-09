using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Student
    {

        private String name;
        private String surname;
        private DateTime dateOfBirth;
        private Adresa address;
        private String phoneNumber;
        private String email;
        private String idNumber;
        private short yearOfEnrollment;
        private byte yearOfStudy;
        private nacinfins methodOfFinancing;
        private float avgGrade;
        private List<Ocena> gradesPassedSubjects;
        private List<Predmet> remainingSubjects;

        public enum nacinfins
        {
   
         B,S			
		}
	
	public Student() { }

public Student(String name, String surname, DateTime dateOfBirth, Adresa address, String phoneNumber, String email,
        String idNumber, short yearOfEnrollment, byte yearOfStudy, nacinfins methodOfFinancing, float avgGrade,
        List<Ocena> gradesPassedSubjects, List<Predmet> remainingSubjects)
{

    this.name = name;
    this.surname = surname;
    this.dateOfBirth = dateOfBirth;
    this.address = address;
    this.phoneNumber = phoneNumber;
    this.email = email;
    this.idNumber = idNumber;
    this.yearOfEnrollment = yearOfEnrollment;
    this.yearOfStudy = yearOfStudy;
    this.methodOfFinancing = methodOfFinancing;
    this.avgGrade = avgGrade;
    this.gradesPassedSubjects = gradesPassedSubjects;
    this.remainingSubjects = remainingSubjects;
}

public String getname()
{
    return name;
}

public void setname(String name)
{
    this.name = name;
}

public String getsurname()
{
    return surname;
}

public void setsurname(String surname)
{
    this.surname = surname;
}

public DateTime getdateOfBirth()
{
    return dateOfBirth;
}

public void setdateOfBirth(DateTime dateOfBirth)
{
    this.dateOfBirth = dateOfBirth;
}

public Adresa getaddress()
{
    return address;
}

public void setaddress(Adresa address)
{
    this.address = address;
}

public String getphoneNumber()
{
    return phoneNumber;
}

public void setphoneNumber(String phoneNumber)
{
    this.phoneNumber = phoneNumber;
}

public String getEmail()
{
    return email;
}

public void setEmail(String email)
{
    this.email = email;
}

public String getidNumber()
{
    return idNumber;
}

public void setidNumber(String idNumber)
{
    this.idNumber = idNumber;
}

public short getyearOfEnrollment()
{
    return yearOfEnrollment;
}

public void setyearOfEnrollment(short yearOfEnrollment)
{
    this.yearOfEnrollment = yearOfEnrollment;
}

public byte getyearOfStudy()
{
    return yearOfStudy;
}

public void setyearOfStudy(byte yearOfStudy)
{
    this.yearOfStudy = yearOfStudy;
}

public nacinfins getmethodOfFinancing()
{
    return methodOfFinancing;
}

public void setmethodOfFinancing(nacinfins methodOfFinancing)
{
    this.methodOfFinancing = methodOfFinancing;
}



public void setavgGrade(float avgGrade)
{
    this.avgGrade = avgGrade;
}

public List<Ocena> GradesPassedSubjects
        {
            get { return gradesPassedSubjects; }
            set { gradesPassedSubjects = value; }
        }
      

public List<Predmet> getremainingSubjects()
{
    return remainingSubjects;
}

public void setremainingSubjects(List<Predmet> remainingSubjects)
{
    this.remainingSubjects = remainingSubjects;
}
	
	
}
    }

