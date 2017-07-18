using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBMS
{
    public class Semester
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }

        public virtual List<Semester> Semesters { get; set; }
    }
}
