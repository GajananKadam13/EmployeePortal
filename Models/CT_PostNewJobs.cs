using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_PostNewJobs
    {
        public int PoJob_PKID { get; set; }
        public string DepartmenName { get; set; }
        public string Designation { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnFormat { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; }
        
    }
}