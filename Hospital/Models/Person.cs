using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}