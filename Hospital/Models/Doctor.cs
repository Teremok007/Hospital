using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Doctor : Person
    {
        public virtual Specialization Specialization { get; set; }

        public int SpecializationId { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
    }
}