using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Specialization
    {        
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Specializations name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot be longer than 250 characters.")]
        public string Description { get; set; }
    }
}