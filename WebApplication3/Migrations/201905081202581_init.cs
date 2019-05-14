namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCVs",
                c => new
                    {
                        cvId = c.Int(nullable: false, identity: true),
                        id = c.String(),
                        Langs = c.Int(nullable: false),
                        Educ = c.Int(nullable: false),
                        VolunteerNhobbies = c.Int(nullable: false),
                        Jobs = c.Int(nullable: false),
                        Disabilities = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cvId);
            
            CreateTable(
                "dbo.tblDisabilitys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Disabilities = c.Boolean(nullable: false),
                        Vision = c.Boolean(nullable: false),
                        VisionExp = c.String(),
                        Hearing = c.Boolean(nullable: false),
                        HearingExp = c.String(),
                        Learning = c.Boolean(nullable: false),
                        LearningExp = c.String(),
                        Movment = c.Boolean(nullable: false),
                        MovmentExp = c.String(),
                        MentalHealth = c.Boolean(nullable: false),
                        MentalHealthExp = c.String(),
                        Communicating = c.Boolean(nullable: false),
                        CommunicatingExp = c.String(),
                        Social = c.Boolean(nullable: false),
                        SocialExp = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblEducations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Educ = c.Boolean(nullable: false),
                        Uni = c.Boolean(nullable: false),
                        InstituteUniversity = c.String(),
                        TitleOfDiploma = c.String(),
                        Degree = c.String(),
                        UniFromYear = c.DateTime(),
                        UniToYear = c.DateTime(),
                        School = c.Boolean(nullable: false),
                        SchoolName = c.String(),
                        SchoolFromYear = c.DateTime(),
                        SchoolToYear = c.DateTime(),
                        Course = c.Boolean(nullable: false),
                        CourseName = c.String(),
                        CourseFromYear = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 15),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                        Cv = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
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
                "dbo.tblLanguages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Lang = c.Boolean(nullable: false),
                        VeryGood = c.String(),
                        Good = c.String(),
                        Basic = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.tblPastJobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pastjobs = c.Boolean(nullable: false),
                        pastJob1 = c.Boolean(nullable: false),
                        title1 = c.String(),
                        explain1 = c.String(),
                        pastJob2 = c.Boolean(nullable: false),
                        title2 = c.String(),
                        explain2 = c.String(),
                        pastJob3 = c.Boolean(nullable: false),
                        title3 = c.String(),
                        explain3 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblPersonalDetails",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Tel = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Skills = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblVolunteerHobbys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Volunteer = c.Boolean(nullable: false),
                        VolunteerDet = c.String(),
                        Hobbies = c.Boolean(nullable: false),
                        HobbiesDet = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblVolunteerHobbys");
            DropTable("dbo.tblPersonalDetails");
            DropTable("dbo.tblPastJobs");
            DropTable("dbo.tblManagers");
            DropTable("dbo.tblLanguages");
            DropTable("dbo.tblEmployers");
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblEducations");
            DropTable("dbo.tblDisabilitys");
            DropTable("dbo.tblCVs");
        }
    }
}
