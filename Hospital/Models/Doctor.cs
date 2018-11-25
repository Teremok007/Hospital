using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Doctor : Person
    {
        public string Specialization { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}