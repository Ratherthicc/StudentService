using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.model
{
    class Katedra
    {
        private String departmentCode;
        private String departmentName;
        private Profesor chairman;
        private List<Profesor> lecturers;

        public Katedra() { }

        public Katedra(String departmentCode, String departmentName, Profesor chairman, List<Profesor> lecturers)
        {
            
            this.departmentCode = departmentCode;
            this.departmentName = departmentName;
            this.chairman = chairman;
            this.lecturers = lecturers;
        }

        public String DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        public String DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public Profesor Chairman
        {
            get { return chairman; }
            set { chairman = value; }
        }

   
        public List<Profesor> Lecturers
        {
            get { return lecturers; }
            set { lecturers = value; }
        }

      
    }
}
