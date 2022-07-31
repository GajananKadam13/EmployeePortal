using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeDocuments
    {
        public int Doc_PKID { get; set; }
        public int Employee_PKID { get; set; }
        public string DocumentName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string Status { get; set; }
    }
}