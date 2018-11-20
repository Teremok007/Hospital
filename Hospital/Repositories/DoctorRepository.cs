using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class DoctorRepository : IDoctorRepository, IDisposable
    {
        private HospitalContext db = new HospitalContext();

        public void Add(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Doctor doctor)
        {
            db.Entry<Doctor>(doctor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Doctor GetDoctor(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return db.Doctors.ToList();
        }

        public void Remove(int id)
        {
            Doctor doctor = GetDoctor(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
        }

        public IEnumerable<Patient> GetPatients(int doctorId)
        {
            Doctor doctor = GetDoctor(doctorId);
            if (doctor == null)
            {
                return null;
            }
            return doctor.Patients.ToList();
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return db.Specializations.OrderBy(s => s.Name);
        }

        public Specialization GetDoctorSpecialization(Doctor doctor)
        {
            return db.Specializations.Find(doctor.SpecializationId);
        }
    }
}