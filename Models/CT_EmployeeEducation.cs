using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeEducation
    {
        //-----------Edjucation---------------------------------------------
        [Required(ErrorMessage = "{0} is required.")]
        public string Degree { get; set; }
        [Required(ErrorMessage ="{0} is required.")]
        public string Specialization { get; set; }
        [Required]
        public DateTime PassingYear { get; set; }
        [Required]
        public string Institute { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Percentage { get; set; }
        public int CreatedBy { get; set; }
        public int LastEmployeePKID { get; set; }
    }
}