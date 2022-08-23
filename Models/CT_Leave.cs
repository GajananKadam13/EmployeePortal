using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_Leave
    {
        ///For Apply Leave
        /// 
        public int LeavePKID { get; set; }
        public int EmployeePKID { get; set; }
        public string EmployeeName { get; set; }
        
        public string Leavetype { get; set; }
        public DateTime Fromdate { get; set; }
        public string FromdateFormat { get; set; }
        public DateTime Todate { get; set; }
        public string TodateFormat { get; set; }
        public string ContactDetails { get; set; }
        public string Reason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedOnFormat { get; set; }


        public string ManagerApproveRejectStatus { get; set; }
        public string ManagerApproveRejectComment { get; set; }
        public string HRApproveRejectStatus { get; set; }

        public string HRApproveRejectComment { get; set; }


        public string TotalBalanceLeave { get; set; }


    }
}