using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_Login
    {
        [Required]
        public string UserName { get;set;}
        [Required]
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Status { get; set; }
    }
}