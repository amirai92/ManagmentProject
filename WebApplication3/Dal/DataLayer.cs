using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.Dal
{
    public class DataLayer : DbContext

    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tblEmployees");
            modelBuilder.Entity<Employer>().ToTable("tblEmployers");
            modelBuilder.Entity<Manager>().ToTable("tblManagers");

            modelBuilder.Entity<CV>().ToTable("tblCVs");
            modelBuilder.Entity<PersonalDetails>().ToTable("tblPersonalDetails");
            modelBuilder.Entity<Language>().ToTable("tblLanguages");
            modelBuilder.Entity<Education>().ToTable("tblEducations");
            modelBuilder.Entity<VolunteerHobby>().ToTable("tblVolunteerHobbys");
            modelBuilder.Entity<PastJob>().ToTable("tblPastJobs");
            modelBuilder.Entity<Disability>().ToTable("tblDisabilitys");
            modelBuilder.Entity<QA>().ToTable("tblQA");
            modelBuilder.Entity<LookingAd>().ToTable("tblLookingAd");
            modelBuilder.Entity<WantedAd>().ToTable("tblWantedAd");
            modelBuilder.Entity<MessageManeger>().ToTable("tblMessageManeger");
            modelBuilder.Entity<Content>().ToTable("tblContent");
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<Manager> managers { get; set; }
        public DbSet<CV> cVs { get; set; }
        public DbSet<PersonalDetails> personalDetails { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<VolunteerHobby> volunteerHobbies { get; set; }
        public DbSet<PastJob> pastJobs { get; set; }
        public DbSet<MessageManeger> messageManeger { get; set; }
        public DbSet<Content> content { get; set; }

        public DbSet<Disability> disabilities { get; set; }
        public DbSet<QA> QA { get; set; }
        public DbSet<LookingAd> lookingAd { get; set; }
        public DbSet<WantedAd> wantedAd { get; set; }

    }

}