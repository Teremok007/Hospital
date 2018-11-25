using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Firm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MFO { get; set; }
        public bool IsClosed { get; set; }
        public string Account { get; set; }
        public string Bank { get; set; }
        public int Nds { get; set; }
        public string Boss { get; set; }
        public string License { get; set; }
    }
}