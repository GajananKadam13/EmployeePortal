using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class EmployeeDetailController : Controller
    {
        CT_CreateEmployee obj = new CT_CreateEmployee();
        DL_CreateEmployee objdl_CreateUser = new DL_CreateEmployee();
        // GET: EmployeeDetail

        public ActionResult Index(int EmployeePKID)
        {
            CT_CreateEmployee obj_CE = new CT_CreateEmployee();
            CT_EmployeeEducation obj_EmpEdu = new CT_EmployeeEducation();
            obj_CE = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);
            //----------Designation-------------------------
            if (obj_CE.Designation=="1")
            {
                obj_CE.Designation = "HR";
            }
            if (obj_CE.Designation == "2")
            {
                obj_CE.Designation = "Software Engineer";
            }
            if (obj_CE.Designation == "3")
            {
                obj_CE.Designation = "Manager";
            }
            if (obj_CE.Designation == "4")
            {
                obj_CE.Designation = "Security";
            }

            //----------Department-------------------------
            if (obj_CE.Department == "1")
            {
                obj_CE.Department = "HR";
            }
            if (obj_CE.Department == "2")
            {
                obj_CE.Department = "Development";
            }
            if (obj_CE.Department == "3")
            {
                obj_CE.Department = "Accountant";
            }
            if (obj_CE.Department == "4")
            {
                obj_CE.Department = "Sales";
            }
            if (obj_CE.Department == "5")
            {
                obj_CE.Department = "Marketing";
            }

            //----------Country-------------------------
            if (obj_CE.Country == "1")
            {
                obj_CE.Country = "India(Bharat)";
            }
            if (obj_CE.Country == "2")
            {
                obj_CE.Country = "Japan";
            }
            if (obj_CE.Country == "3")
            {
                obj_CE.Country = "USA";
            }
            if (obj_CE.Country == "4")
            {
                obj_CE.Country = "Rashiya";
            }
            if (obj_CE.Country == "5")
            {
                obj_CE.Country = "France";
            }
            //CT_CreateEmployee obj = new CT_CreateEmployee();
            // obj = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);

         
            return View(obj_CE);
        }
    }
}