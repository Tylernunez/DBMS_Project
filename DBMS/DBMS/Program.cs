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
            int sum = 0;
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
                    var query2 = from q in db.Students
                                 where q.Major == "CMPS"
                                 select q;
                Console.WriteLine("All students majoring in CMPS:");
                foreach (var q in query2)
                    {
                        counter++;
                        Console.Write(q.FName);
                        Console.Write(" ");
                        Console.Write(q.LName);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    var query3 = from r in db.Courses
                                 where r.Credit > 3
                                 select r;
                Console.WriteLine("All courses with more than 3 credit hours:");
                foreach (var r in query3)
                    {
                        Console.Write(r.Name);
                        Console.Write(" ");
                        Console.Write(r.Number);
                        Console.WriteLine();
                    }

                var listCourses = from b in db.Courses
                            orderby b.Name
                            select b;

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("All Courses in the database:");
                foreach (var item in listCourses)
                {
                    Console.Write(item.Name + " ");
                    Console.Write(item.Number);
                    Console.WriteLine();
                }

                var listCourses2 = from b in db.Courses
                                  orderby b.Name
                                  where b.Number >= 200
                                  select b;

                Console.WriteLine();
                Console.WriteLine("All Courses in the database after the delete:");
                foreach (var item in listCourses2)
                {
                    Console.Write(item.Name + " ");
                    Console.Write(item.Number);
                    Console.WriteLine();
                }
                Console.WriteLine();

                var query4 = from ct in db.Taken_Courses
                             join stu in db.Students on ct.Student_Id equals stu.Id
                             join cour in db.Courses on ct.Course_Id equals cour.Id
                             where stu.Id == 1
                             select cour;
                //select new { Taken_Courses = ct, Student = stu };

                Console.WriteLine("Courses taken by student (Id = 1):");
                foreach (var o in query4)
                {
                    Console.Write(o.Name + " ");
                    Console.Write(o.Number + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();

                var query5 = from ct2 in db.Taken_Courses
                             join stu2 in db.Students on ct2.Student_Id equals stu2.Id
                             join cour2 in db.Courses on ct2.Course_Id equals cour2.Id
                             where stu2.Id == 1 && cour2.Semester_Id == 2
                             select cour2;


                Console.WriteLine("Classes taken by Student (Id = 1) from last semester:");
                
                foreach (var h in query5)
                {
                    Console.Write(h.Name + " ");
                    Console.Write(h.Number + " ");
                    Console.Write(h.Credit + " ");
                    sum += h.Credit;
                    Console.WriteLine();
                }
                Console.WriteLine("Cumulative credit hours for Student (Id = 1) from last semester: " + sum);
                Console.WriteLine();

                var query6a = from ct3 in db.Taken_Courses
                             join stu3 in db.Students on ct3.Student_Id equals stu3.Id
                             join cour3 in db.Courses on ct3.Course_Id equals cour3.Id
                             where ct3.Grade == "A" && cour3.Number == 339 && cour3.Semester_Id == 3
                             select stu3;

                var query6b = from sem in db.Semesters
                             join cour4 in db.Courses on sem.Id equals cour4.Semester_Id
                             where sem.Id == 3
                             select sem;

                foreach (var n in query6b)
                {
                    Console.WriteLine("Students with an A in CMPS 339 in " + n.Name + ":");
                }

                
                foreach (var p in query6a)
                {
                    Console.Write(p.FName + " ");
                    Console.Write(p.LName + " ");
                    Console.WriteLine();
                }

            }
            Console.Read();
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

   

    

