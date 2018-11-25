using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private HospitalContext db = new HospitalContext();

        public void Add(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Edit(Patient patient)
        {
            db.Entry<Patient>(patient).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Patient GetPatient(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.Patients.Find(id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return db.Patients;
        }

        public void Remove(int id)
        {
            Patient patient = GetPatient(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public IEnumerable<Doctor> GetDoctors(int patientId)
        {
            Patient patient = GetPatient(patientId);
            if (patient == null)
            {
                return null;
            }
            return patient.Doctors;
        }
    }
}