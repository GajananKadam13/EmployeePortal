using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        DL_Login objdl_Log = new DL_Login();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CT_Login obj)
        {
            DataTable dt = new DataTable();
            if (ModelState.IsValid)
            {
              
                dt = objdl_Log.FnCheckLogin(obj);
                if (dt.Rows.Count> 0 )
                {
                    Session["Emp_PK_ID"] = dt.Rows[0]["Emp_PK_ID"].ToString();
                    Session["EmployeeName"] = dt.Rows[0]["EmployeeName"].ToString();
                    ViewBag.Message = "Login Success";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Login Failed";
                }
            }

            return View();
        }
    }
}