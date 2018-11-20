using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("Hospital")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         
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

            modelBuilder.Entity<Patient>().
                Property(p => p.TaxCode).
                IsRequired().
                IsUnicode();

            base.OnModelCreating(modelBuilder);
        }
    }
}