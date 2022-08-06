using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeAttendance
    {
        public int Att_PKID { get; set; }
        public int EmployeePKID { get; set; }   
        public string LogInTime { get; set; }
        public string Weekday { get; set; }
        public string LogoutTime { get; set; }
        public string Month { get; set; }
    }
}