using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_CreateEmployee
    {
        //-----Registartion Form-----------
        public string Salutaion { get; set; }
        public string Department { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
     
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public int Role { get; set; }
        //------------Address Details-------
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //-----------Login Details-----------------
        public int EMP_PK_ID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        //[Compare("Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        
        [Display(Name= "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Status { get; set; }
        public List<CT_CreateEmployee> CT_CreateEmployeelist = new List<CT_CreateEmployee>();

    }
}