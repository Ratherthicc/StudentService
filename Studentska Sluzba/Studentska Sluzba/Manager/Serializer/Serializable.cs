using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Serializer
{
    public interface Serializable
    {

        string[] ToCSV();
        void FromCSV(string[] values);

    }
}
