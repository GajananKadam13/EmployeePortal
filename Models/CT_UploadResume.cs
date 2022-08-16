using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_UploadResume
    {
        public int EmployeePKID { get; set; }
        public string Resume { get; set; }
        public string file_Name { get; set; }
        public string CreatedOn { get; set; }
        public string Status { get; set; }
    }
}