using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Models
{
    public class PatientEditViewModel
    {
        private Patient _patient = new Patient();

        public Patient Patient { get { return _patient; } set { _patient = value; } }

        public int Id { get { return _patient.Id; } set { _patient.Id = value;  } }

        public string Name { get { return _patient.Name; } set { _patient.Name = value; } }

        public string TaxCode { get { return _patient.TaxCode;  } set { _patient.TaxCode = value; } }

        public DateTime? DayOfBirth { get { return _patient.DayOfBirth; } set { _patient.DayOfBirth = value; } }

        public PatientStatus Status { get { return _patient.Status; } set { _patient.Status = value; } }

        public MultiSelectList Doctors { get; set; }

        public List<string> DoctorsId { get; set; }
    }
}