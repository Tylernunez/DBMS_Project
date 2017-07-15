using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace DBMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string line; 
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("queries.txt");
            while ((line = file.ReadLine()) != null)
            {
                ExecuteLine(line);
            }
            Console.ReadLine();
            file.Close();


            using (var db = new UniversityContext())
            {
                
                /*var firstName = new Student { FName = "Bob" };
                db.Students.Add(firstName);
                db.SaveChanges();*/

                // Display all students from the database 
                var query = from b in db.Students
                            orderby b.FName
                            select b;

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
        }

        public static void ExecuteLine(string command)
        {
            var word = command.Substring(0, command.IndexOf(' '));
            if (word == "SELECT")
            {
                select(command);
                return;
            }
            
            using (var db = new UniversityContext())
            {
                db.Database.ExecuteSqlCommand(command);
                
                //CREATE TABLE tableTest(test1 varchar(255), test2 int, test3 varchar(255));
                //INSERT INTO tableTest(test1, test2, test3) VALUES('hello', 28, 'goodbye');
                //CREATE VIEW viewTest AS SELECT test1, test2, test3 FROM tableTest;
                //DROP TABLE Students;
            }
        }
        
        public static void select(string command)
        {

            using (var db = new UniversityContext())
            {

                var obContext = ((IObjectContextAdapter)db).ObjectContext;
                IEnumerable<Object> results = obContext.ExecuteStoreQuery<Object>(command);
                foreach(Object i in results)
                {
                    string print = i.ToString();
                    Console.Write(print);
                }
                
                
            }
        }
    }
    
}
