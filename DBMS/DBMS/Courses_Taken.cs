using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBMS
{
    public class Courses_Taken
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public int Course_Id { get; set; }
        public string Grade { get; set; }

        public virtual List<Courses_Taken> Taken_Courses { get; set; }
    }
}
