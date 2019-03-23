using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ThisAbility.Models;
using WebApplication3.Models;

namespace ThisAbility.Dal
{
    public class DataLayer : DbContext

    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tblEmployees");

            modelBuilder.Entity<Employer>().ToTable("tblEmployers");

            modelBuilder.Entity<Manager>().ToTable("tblManagers");


        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<Manager> managers { get; set; }




    }

}