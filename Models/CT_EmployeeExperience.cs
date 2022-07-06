using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeExperience
    {
        ////-----------------------Experience----------------------

        [Required]
        public string Organization { get; set; }
        [Required]
        public string ExperienceDesignation { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string StartSalary { get; set; }
        [Required]
        public string EndSalary { get; set; }
        [Required]
        public string Reason { get; set; }

        public int LastEmployeePKID { get; set; }
        public int CreatedBy { get; set; }
        

        ////-------------------------------------------

    }
}