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

        //[RegularExpression(@"[0-9]{4}-[0-9]{2}-[0-9]{2}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DayOfBirth { get; set; }

        /// <summary>
        /// Идентификационный код.
        /// </summary>
        public string TaxCode { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}