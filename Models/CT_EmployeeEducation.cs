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
        public int Edu_PKID { get; set; }
        public int Employee_PKID { get; set; }

       // [Required(ErrorMessage = "{0} is required.")]
        public string Degree { get; set; }
        public string DegreeText { get; set; }
        //[Required(ErrorMessage = "{0} is required.")]
        public string Specialization { get; set; }
        public string SpecializationText { get; set; }
        //[Required]
        public DateTime PassingYear { get; set; }
        public string PassingYearFormat { get; set; }
        //[Required]
        public string Institute { get; set; }

        //[Required]
        public DateTime StartDate { get; set; }
        public string StartDateFormat { get; set; }
        //[Required]
        public DateTime EndDate { get; set; }
        public string EndDateFormat { get; set; }
        
        //[Required]
        public string Percentage { get; set; }
        public int CreatedBy { get; set; }
        public int LastEmployeePKID { get; set; }
        public string Status { get; set; }
         
        public CT_EmployeeEducation employeeEducationsModel {get;set;}
        public List<CT_EmployeeEducation> employeeEducationsModelList { get; set; }
    }
}