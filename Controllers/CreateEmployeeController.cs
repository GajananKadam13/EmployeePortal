using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class CreateEmployeeController : Controller
    {
        // GET: AddEmployee
        CT_CreateEmployee Oj_CT = new CT_CreateEmployee();
        DL_CreateEmployee objdl_CreateUser = new DL_CreateEmployee();
        public ActionResult Index(CT_CreateEmployee Obj_CE)
        {
            if (Obj_CE.Password != null)
            {
                ModelState["ConfirmPassword"].Errors.Clear();
                //ModelState["Password"].Errors.Clear();
                Obj_CE.ConfirmPassword = Obj_CE.Password;
            }

            ModelState["Password"].Errors.Clear();


            return View(Obj_CE);
        }
        [HttpPost]
        public ActionResult Index(CT_CreateEmployee obj, string ddlGender,int ddlRole,string Address,int hdn_Emp_pkid)
        {
            string returntype = "";
            obj.Gender = ddlGender;
            obj.Role = ddlRole;
            obj.Address = Address;
            obj.EMP_PK_ID = hdn_Emp_pkid;
            if (ModelState.IsValid)
            {
                if (obj.EMP_PK_ID==0)
                {
                    returntype = objdl_CreateUser.FnCreateEmployee(obj);
               
                    if (returntype == "Success")
                    {
                        ViewBag.Message = "Registerd Success";
                        return View(obj);
                    }
                    else
                    {
                        ViewBag.Message = " Failed";
                    }
                }
                else
                {
                    //Update Employee
                    returntype = objdl_CreateUser.FnCreateEmployee(obj);
                }

            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult ViewEmployee(CT_CreateEmployee obj)
        {
            List<CT_CreateEmployee> list = new List<CT_CreateEmployee>();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
             list = objdl_CreateUser.FnGetEmployees();
            Oj_CT.CT_CreateEmployeelist = list;
            return View(Oj_CT);
        }

       
        public ActionResult ViewEmployeeById(int EmployeePKID)
        {
             CT_CreateEmployee obj = new CT_CreateEmployee();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            obj = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);
            return RedirectToAction("Index", obj);
        }

        public ActionResult DeleteEmployeeById(int EmployeePKID)
        {
            string returnType = "";
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            returnType= objdl_CreateUser.FnDeleteEmployeeById(EmployeePKID).ToString();
            return RedirectToAction("Index", returnType);
        }


    }
}