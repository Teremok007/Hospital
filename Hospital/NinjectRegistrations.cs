using Hospital.Models;
using Hospital.Repositories;
using Ninject.Modules;
using System.Web.ModelBinding;

namespace Hospital
{
    internal class NinjectRegistrations : NinjectModule
    {
            public override void Load()
            {                
                Bind<IDoctorRepository>().To<DoctorRepository>();
                Bind<IPatientRepository>().To<PatientRepository>();
            }

    }

}