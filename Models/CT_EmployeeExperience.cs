using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeExperience
    {
        ////-----------------------Experience----------------------

        public string Organization { get; set; }
        public string ExperienceDesignation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartSalary { get; set; }
        public string EndSalary { get; set; }
        public string Reason { get; set; }
        ////-------------------------------------------

    }
}