using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        DL_ChangePassword ObjDl_ChgPass = new DL_ChangePassword();
        public ActionResult Index()
        {
            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------
            return View();
        }
        [HttpPost]
        public ActionResult Index(CT_ChangePassword obj)
        {
            if (ModelState.IsValid)
            {
                obj.EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]); ;
                string ReturnStatus = ObjDl_ChgPass.FnChangePassword(obj);
                ViewBag.PasswordChangeStatus = ReturnStatus;
            }

            return View();
        }
    }
}