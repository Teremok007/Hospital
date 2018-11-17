using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IDoctorRepository : IDisposable
    {
        IEnumerable<Doctor> GetDoctors();

        Doctor GetDoctor(int? id);

        void Edit(Doctor doctor);

        void Add(Doctor doctor);

        void Remove(int id);
    }
}
