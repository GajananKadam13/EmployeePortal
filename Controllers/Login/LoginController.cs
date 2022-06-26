using System;
using System.Collections.Generic;
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
            if (ModelState.IsValid)
            {
                string returntype = "";
                returntype = objdl_Log.FnCheckLogin(obj);
                if (returntype == "1")
                {
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