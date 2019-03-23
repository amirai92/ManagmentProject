using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ThisAbility.Models;

namespace ThisAbility.Dal
{
    public class WantedAdsDal : DbContext

    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tbWantedAds");

        }
        public DbSet<Employee> WantedAds { get; set; }
    }

}