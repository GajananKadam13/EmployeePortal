using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_ResetPassword
    {
        public int EmployeePKID { get; set; }
        public string CompanyEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthFormat { get; set; }
        
        public string Gender { get; set; }

        public string Password { get; set; }
        public List<CT_ResetPassword> CT_ResetPasswordlist = new List<CT_ResetPassword>();
    }
}