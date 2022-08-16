using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_ReferanceResume
    {
        public int Refer_PKID { get; set; }
        public int EmployeePKID { get; set; }
        public int PostNewJobPKID { get; set; }
        public string  Resume { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnFormat { get; set; }
        public string Status { get; set; }
        public string HRComment { get; set; }
        public string EmployeeName{ get; set; }
    }
}