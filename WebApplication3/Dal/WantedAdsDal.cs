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
            modelBuilder.Entity<User>().ToTable("tbWantedAds");

        }
        public DbSet<User> WantedAds { get; set; }
    }

}