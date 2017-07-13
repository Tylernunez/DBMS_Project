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
            using (var db = new UniversityContext())
            {
                
                var firstName = new Student { FName = "Bob" };
                db.Students.Add(firstName);
                db.SaveChanges();

                // Display all students from the database 
                var query = from b in db.Students
                            orderby b.FName
                            select b;

                /* Console.WriteLine("Enter a Query:");
                 string input = Console.ReadLine();

                 db.Database.ExecuteSqlCommand(input);
                 */
                Console.WriteLine("All students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FName);
                }
            }
        }

        
    }
    
}
