using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.Repositories
{
    public interface IPatientRepository : IDisposable
    {
        IEnumerable<Patient> GetPatients();

        IEnumerable<Doctor> GetDoctors(int? patientId);

        ICollection<Doctor> GetDoctorsById(int[] doctorsId);

        Patient GetPatient(int? id);

        void Edit(Patient patient);

        void Add(Patient patient);

        void Remove(int id);


    }
}
