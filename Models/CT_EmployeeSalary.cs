using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_EmployeeSalary
    {
        public int Sal_PKID { get; set; }
        public int Employee_PKID { get; set; }
        public string BasicSalary { get; set; }
        public string HouseRentAllowences { get; set; }
        public string ConveyanceAllowences { get; set; }
        public string MedicalAllowences { get; set; }
        public string SpecialAllowences { get; set; }
        public string GrossSalary { get; set; }
        public string NetPay { get; set; }
        public string EPF { get; set; }
        [DisplayName("HealthInsurance ESI")]
        public string HealthInsurance_ESI { get; set; }
        public int CreatedBy { get; set; }


    }
}