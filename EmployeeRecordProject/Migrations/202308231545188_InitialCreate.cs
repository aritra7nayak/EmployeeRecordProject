namespace EmployeeRecordProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Degree = c.String(nullable: false),
                        PassingYear = c.Int(nullable: false),
                        DegreePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        PhoneNo = c.Int(nullable: false),
                        EmailId = c.String(nullable: false),
                        UploadedPhoto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeEducations", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeEducations", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeEducations");
        }
    }
}
