using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


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
            using (var db = new UniversityContext())
            {
               
                 var result = db.Database.SqlQuery<string>(command);
                Console.WriteLine(result);
                //CREATE TABLE tableTest(test1 varchar(255), test2 int, test3 varchar(255));
                //INSERT INTO tableTest(test1, test2, test3) VALUES('hello', 28, 'goodbye');
                //CREATE VIEW viewTest AS SELECT test1, test2, test3 FROM tableTest;
                //DROP TABLE Students;
            }
        }
    }
    
}
