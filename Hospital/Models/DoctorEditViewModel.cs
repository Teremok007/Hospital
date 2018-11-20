using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Models
{
    public class DoctorEditViewModel
    {
        public IEnumerable<Specialization> Specializations { get; set; }

        public Doctor Doctor { get; set; }

        public IEnumerable<SelectListItem> SpecializationAsSelectItem(int? id)
        {
            yield return new SelectListItem()
            {
            };
            foreach (var item in Specializations)
            {
                yield return new SelectListItem()
                {
                    Disabled = false,                    
                    Text = item.Name,
                    Selected = id==null?false:(id == item.Id),
                    Value = item.Id.ToString()
                };
            }
        }

        public MultiSelectList Patients { get; set; }

    }
}