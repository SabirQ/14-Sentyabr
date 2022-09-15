using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCardTask.Models;

namespace VCardTask.DAL
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<VCard> VCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=VCardTask14_09;integrated security=true;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VCard>(model =>
            {
                model.HasKey(prop => prop.Id);
                model.Property(prop => prop.Firstname).HasMaxLength(30).IsRequired(true);
                model.Property(prop => prop.Lastname).HasMaxLength(30).IsRequired(true);
                model.Property(prop => prop.Email).IsRequired(true);
                model.HasIndex(prop => prop.Email).IsUnique(true);
                model.Property(prop => prop.Phone).IsRequired(true);
                model.Property(prop => prop.Country).HasMaxLength(50).IsRequired(true);
                model.Property(prop => prop.City).HasMaxLength(50).IsRequired(true);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
