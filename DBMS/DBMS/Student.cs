﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBMS
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MI { get; set; }
        public string LName { get; set; }
        public string WNum { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public bool Grad { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
