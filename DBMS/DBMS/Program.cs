using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

namespace DBMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("queries.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                ExecuteLine(line);
            }
            //Console.Read();
            //file.Close();

            using (var db = new SchoolContext())
            {
                using (SchoolContext context = new SchoolContext())
                {
                    var query1 = from s in db.Courses
                                 where s.Abbr == "CMPS"
                                 select s;

                    foreach (var s in query1)
                    {
                        Console.WriteLine(s.Name);
                    }

                    var query2 = from q in db.Students
                                 where q.Major == "Computer Science"
                                 select q;

                    foreach (var q in query2)
                    {
                        counter++;
                        Console.Write(counter + ".");
                        Console.Write(q.FName);
                        Console.Write(" ");
                        Console.Write(q.LName);
                        Console.Write(" ");
                    }
                    var query3 = from r in db.Courses
                                 where r.Credit > 3
                                 select r;

                    foreach (var r in query3)
                    {
                        counter++;
                        Console.Write(counter + ".");
                        Console.Write(r.Name);
                        Console.Write(" ");
                        Console.Write(r.Number);
                        Console.Write(" ");
                    }
                    counter = 0;
                    
                }
            }
            Console.Read();
            /* Console.WriteLine("Enter a Query:");
             string input = Console.ReadLine();

             db.Database.ExecuteSqlCommand(input);
             */
            /*Console.WriteLine("All students in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.FName);
            }*/
        }


        public static void ExecuteLine(string command)
        {

            using (var db = new SchoolContext())
            {
                db.Database.ExecuteSqlCommand(command);
                db.SaveChanges();
            }
        }
    }

}

   

    

