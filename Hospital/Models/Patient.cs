using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public enum PatientStatus
    {
        Arrived =1,
        Sick = 2,
        Healthy =3
    }

    public class Patient : Person
    {
        /// <summary>
        /// 1 - Arrived
        /// 2 - Sick
        /// 3 - Healthy
        /// 
        /// TODO: change it to enum
        /// </summary>
        public PatientStatus Status { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DayOfBirth { get; set; }

        /// <summary>
        /// Идентификационный код.
        /// </summary>
        [Display(Name = "IdentityCode")]
        [StringLength(10, ErrorMessage = "The Identity code cannot be longer than 10 characters.")]
        public string TaxCode { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
    }
}