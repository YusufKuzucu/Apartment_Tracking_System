using Apartment_Tracking_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Apartment_Tracking_System.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tenant>()
           .HasOne(sakin => sakin.Flat)
           .WithOne(daire => daire.Tenant).HasForeignKey<Flat>(x => x.TenantId);

            modelBuilder.Entity<Flat>()
           .HasIndex(daire => daire.FlatNo)
           .IsUnique();

            modelBuilder.Entity<Apartment>()
                .HasOne(apartman => apartman.Manager)
                .WithMany(yönetici => yönetici.Apartments)
                .HasForeignKey(apartman => apartman.ManagerId);


            modelBuilder.Entity<Flat>()
                .HasOne(daire => daire.Apartment)
                .WithMany(apartman => apartman.Flats).HasForeignKey(x => x.ApartmentId);

            modelBuilder.Entity<Dues>()
                .HasOne(aidat => aidat.Flat)
                .WithMany(daire => daire.Dues)
                .HasForeignKey(aidat => aidat.FlatId);
        }
    }
}
