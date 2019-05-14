namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 15),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                        CV = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.UserName);

            CreateTable(
          "dbo.tblQA",
          c => new
          {
              Title = c.String(nullable: false, maxLength: 150),
              EditorName = c.String(nullable: false, maxLength: 150),
              InfoContent = c.String(nullable: false, maxLength: 1500),
             // Password = c.String(nullable: false, maxLength: 15),
          })
          .PrimaryKey(t => t.Title);

            CreateTable(
                "dbo.tblEmployers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.tblManagers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblManagers");
            DropTable("dbo.tblEmployers");
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblQA");
        }
    }
}
