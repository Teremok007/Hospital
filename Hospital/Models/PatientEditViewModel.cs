using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class PatientEditViewModel
    {
        private Patient _patient;

        public PatientEditViewModel()
        {
            this._patient = new Patient();
        }
        public Patient Patient { get { return _patient; } set { _patient = value; } }

        public int Id { get { return _patient.Id; } set { _patient.Id = value; } }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(75, MinimumLength = 2)]
        public string Name { get { return _patient.Name; } set { _patient.Name = value; } }

        [Required(ErrorMessage = "TaxCode is required")]
        public string TaxCode { get { return _patient.TaxCode; } set { _patient.TaxCode = value; } }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "DateTime is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DayOfBirth { get { return _patient.DayOfBirth; } set { _patient.DayOfBirth = value; } }

        [EnumDataType(typeof(PatientStatus))]
        public PatientStatus Status { get { return _patient.Status; } set { _patient.Status = value; } }
        
        public MultiSelectList DoctorSelectList { get; set; }

        public List<int> SelectedDoctorsId { get; set; }
        public List<Doctor> Doctors { get { return _patient.Doctors; } }
        
    }
}