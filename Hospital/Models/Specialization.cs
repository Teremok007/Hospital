using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Specialization
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}