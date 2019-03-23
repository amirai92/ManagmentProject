using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ThisAbility.Models;

namespace ThisAbility.Dal
{
    public class LookingAdsDal : DbContext

    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tbLookingAds");

        }
        public DbSet<Employee> LookingAds { get; set; }
    }

}