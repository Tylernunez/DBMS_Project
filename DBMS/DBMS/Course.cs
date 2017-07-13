using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBMS
{
    public class Course
    {
        public int Id { get; set; }
        public string Abbr { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
