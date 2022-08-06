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
        List<CT_EmployeeAttendance> objEmpAttenlst = new List<CT_EmployeeAttendance>();
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
        

        public ActionResult GetEmployeeAttendanceData()
        {
            JsonResult result = new JsonResult();
            CT_EmployeeAttendance objExp = new CT_EmployeeAttendance();
            List<CT_EmployeeAttendance> listExp = new List<CT_EmployeeAttendance>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            
            listExp = Obj_dL_Home.FnGetEmployeeAttendanceWholeMonth(EmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listExp), JsonRequestBehavior.AllowGet);

            
            return result;
        }




    }
}