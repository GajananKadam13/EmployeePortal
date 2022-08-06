using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;

namespace EmployeePortal.Controllers
{
    public class HomeController : Controller
    {
        DL_Home Obj_dL_Home = new DL_Home();
        // GET: Home
        public ActionResult Index()
        {
            int EmployeePKID =Convert.ToInt32(Session["EmployeePKID"]);
            string status= Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            string statusEmpCheckInTime = Obj_dL_Home.FnGetEmployeeCheckInTime(EmployeePKID);
            
            ViewBag.CheckInOuStatus= status;
            ViewBag.EmpCheckInTime = statusEmpCheckInTime;
            return View();
        }

        public ActionResult CheckIn(int EmployeePKID, string CheckInOutStatus)
        {
            JsonResult result = new JsonResult();
            string returntype = "";
            returntype = Obj_dL_Home.FnCreateEmployee(EmployeePKID, CheckInOutStatus);

            result = this.Json(JsonConvert.SerializeObject(returntype), JsonRequestBehavior.AllowGet);
            return result;
        }



    }
}