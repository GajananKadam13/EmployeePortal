using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_CreateEmployee : CT_EmployeeEducation  
    {
        //-----Registartion Form-----------
        //public string Salutaion { get; set; }
        //public string Department { get; set; }
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }
        //[Display(Name = "Middle Name")]
        //public string MiddleName { get; set; }
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //public string Gender { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime DOB { get; set; }
        //public string Nationality { get; set; }
        //public string Email { get; set; }
        //public string Landline { get; set; }
        //public string Mobile { get; set; }
        //public int Role { get; set; }
        ////------------Address Details-------
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Country { get; set; }
        ////-----------Login Details-----------------
        //public int EMP_PK_ID { get; set; }
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }
        //[Required]
        //public string Password { get; set; }
        ////[Compare("Password")]
        //[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]

        //[Display(Name = "Confirm Password")]
        //public string ConfirmPassword { get; set; }
        //public string CreatedBy { get; set; }
        //public string CreationDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public string ModifiedDate { get; set; }
        //public string Status { get; set; }
        //-------------------------------------------------------------------------------------------


        public List<CT_CreateEmployee> CT_CreateEmployeelist = new List<CT_CreateEmployee>();

        //-----------------------Basic Information---------------------------------------------------------------------------------------------------

        public int EmployeePKID { get; set; }
        [Required]
        public string ProfilePictureName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string PersonalEmail { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Description { get; set; }
        //-------------Employee Information----------------------------------------------
        [Required]
        public string EmployeeEnrollmentID { get; set; }
        [Required]
        public DateTime DateofJoining { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string ReportingEmployee { get; set; }
        public string TypeofEmployee { get; set; }
        //-----------Contact Information---------------------------------------------
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }

        //-----------STATUS-------------------------------------------
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public string  Password { get; set; }
        [Required]
        public string Role { get; set; }
        //-------------------------------------------------------------------


        //-----------------************************************************************************************************************------------------------


        //############################################################
        //==============Education===================================
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public string PassingYear { get; set; }
        public string Institute { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Percentage { get; set; }
        //=================================================
        
        //############################################################

        //=================Experience================================
        public string Organization { get; set; }
        public string ExperienceDesignation { get; set; }
        public string ExperienceStartDate { get; set; }
        public string ExperienceEndDate { get; set; }
        public string StartSalary { get; set; }
        public string EndSalary { get; set; }
        public string Reason { get; set; }

        //=================================================
        //############################################################
        //===============Documents==================================
        public string DocumentName { get; set; }
        //=================================================
        //############################################################

        //############################################################
        //===============Salary==================================
        public string BasicSalary { get; set; }
        public string HouseRentAllowences { get; set; }
        public string ConveyanceAllowences { get; set; }
        public string MedicalAllowences { get; set; }
        public string SpecialAllowences { get; set; }
        public string GrossSalary { get; set; }
        public string EPF { get; set; }
        public string HealthInsuranceESI { get; set; }
        
        public string NetPay { get; set; }
        //=================================================
        //############################################################

        public List<CT_EmployeeEducation> CT_EmployeeEducationlist = new List<CT_EmployeeEducation>();
        public List<CT_EmployeeExperience> CT_EmployeeExperiencelist = new List<CT_EmployeeExperience>();
         public List<CT_EmployeeDocuments> CT_EmployeeDocumentslist = new List<CT_EmployeeDocuments>();
        
        //public CT_EmployeeEducation CT_EmployeeEducationObj;
    }

}