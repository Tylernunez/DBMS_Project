namespace DBMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationAddMI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "MI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "MI");
        }
    }
}
