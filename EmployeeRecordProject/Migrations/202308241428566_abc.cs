namespace EmployeeRecordProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PhoneNo", c => c.Int(nullable: false));
        }
    }
}
