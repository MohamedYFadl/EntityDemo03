using EntityDemo03.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo03.Contexts
{
    public class DemoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=Demo; trusted_connection=true; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasBaseType<Vechicle>();
            modelBuilder.Entity<Truck>().HasBaseType<Vechicle>();
            modelBuilder.Entity<Vechicle>().HasDiscriminator<string>("VechicleType").HasValue<Car>("C").HasValue<Truck>("T");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Vechicle> vechicles { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
