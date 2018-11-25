using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital.DAL
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("Hospital")
        {
        }

        static HospitalContext()
        {
            Database.SetInitializer<HospitalContext>(new DBInitializer());
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Specialization>().
                HasIndex(s => s.Name).
                IsUnique();
              */  

            modelBuilder.Entity<Doctor>().
                HasRequired( d => d.Specialization).
                WithMany().
                HasForeignKey( k => k.SpecializationId);

            modelBuilder.Entity<Patient>().
                HasMany(p => p.Doctors).
                WithMany(d => d.Patients).
                Map(mp =>
                    {
                        mp.MapLeftKey("Patient_Id");
                        mp.MapRightKey("Doctor_Id");
                        mp.ToTable("PatientDoctors");
                    });

            modelBuilder.Entity<Doctor>().
                Property(p => p.SpecializationId).
                IsRequired();

            modelBuilder.Entity<Doctor>().
                Property(p => p.Name).
                IsRequired();

            modelBuilder.Entity<Patient>().
                Property(p => p.TaxCode).
                IsRequired().
                IsUnicode();
            modelBuilder.Entity<Patient>().
                Property(p => p.Name).
                IsRequired();
            modelBuilder.Entity<Patient>().
                Property(p => p.DayOfBirth).
                IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        
    }
}