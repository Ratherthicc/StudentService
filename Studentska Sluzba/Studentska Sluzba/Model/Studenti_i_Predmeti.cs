using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public class StudentiPredmet : Serializable
    {
        public int StudentId { get; set; }
        public int PredmetId { get; set; }

        public StudentiPredmet()
        {

        }

        public StudentiPredmet(int StudentId, int PredmetId)
        {
            this.StudentId = StudentId;
            this.PredmetId = PredmetId;
        }

        public void FromCSV(string[] values)
        {
            StudentId = int.Parse(values[0]);
            PredmetId = int.Parse(values[1]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                StudentId.ToString(),
                PredmetId.ToString()
            };
            return csvValues;
        }

        public override string ToString()
        {
            string string0 = String.Format("\nId studenta: {0}" +
                                          "\nId predmeta: {1}", StudentId, PredmetId);

            return string0;

        }
        }
}
