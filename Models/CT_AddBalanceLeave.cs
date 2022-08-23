using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_AddBalanceLeave
    {
        public int BalLeavePKID { get; set; }
        public int EmployeePKID { get; set; }
        public string  EmployeeName { get; set; }
        public int LossOfPay { get; set; }
        public int CasualLeave { get; set; }
        public int CompOff { get; set; }
        public int SickLeave { get; set; }
        public int RecreationalLeave { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnFormat { get; set; }
        
        public int CreatedBy { get; set; }
    }
}