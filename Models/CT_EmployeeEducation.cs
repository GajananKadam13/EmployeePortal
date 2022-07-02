using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeEducation
    {
        //-----------Edjucation---------------------------------------------
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public string PassingYear { get; set; }
        public string Institute { get; set; }
        public string StatrDate { get; set; }
        public string EndrDate { get; set; }
        public string Percentage { get; set; }
    }
}