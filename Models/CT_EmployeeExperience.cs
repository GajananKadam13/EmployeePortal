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
        public int Exp_PKID { get; set; }
        
      
        public string Organization { get; set; }
      
        public string ExperienceDesignation { get; set; }
      
        public DateTime StartDate { get; set; }
        public string StartDateFormat { get; set; }

        public DateTime EndDate { get; set; }
        public string EndDateFormat { get; set; }
       
        public string StartSalary { get; set; }
       
        public string EndSalary { get; set; }
     
        public string Reason { get; set; }

        public int LastEmployeePKID { get; set; }
        public int CreatedBy { get; set; }
        

        ////-------------------------------------------

    }
}