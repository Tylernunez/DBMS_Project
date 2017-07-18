namespace DBMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbr = c.String(),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Description = c.String(),
                        Credit = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(),
                        Name = c.String(),
                        Semester_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.Semester_Id)
                .Index(t => t.Semester_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        MI = c.String(),
                        LName = c.String(),
                        WNum = c.String(),
                        Major = c.String(),
                        Degree = c.String(),
                        Grad = c.Boolean(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Courses_Taken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                        Courses_Taken_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses_Taken", t => t.Courses_Taken_Id)
                .Index(t => t.Courses_Taken_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses_Taken", "Courses_Taken_Id", "dbo.Courses_Taken");
            DropForeignKey("dbo.Students", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Semesters", "Semester_Id", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Courses_Taken", new[] { "Courses_Taken_Id" });
            DropIndex("dbo.Students", new[] { "Student_Id" });
            DropIndex("dbo.Semesters", new[] { "Semester_Id" });
            DropIndex("dbo.Courses", new[] { "Course_Id" });
            DropTable("dbo.Courses_Taken");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.Courses");
        }
    }
}
