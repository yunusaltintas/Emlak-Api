using Emlak.Data.Entities;
using Emlak.Data.EntityTypeBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data
{
    public class EmlakDbContext : DbContext
    {
        public EmlakDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementTypeBuilder())
                        .ApplyConfiguration(new UserTypeBuilder());



        }
    }
}
