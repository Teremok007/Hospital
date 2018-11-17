using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Util
{
    public class HospitalDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(DoctorRepository))
            {
                return new DoctorRepository();
            }

            if (serviceType == typeof(PatientRepository))
            {
                return new PatientRepository();
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}