using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class MonthlyCalenderController : Controller
    {
        DL_Home Obj_dL_Home = new DL_Home();
        // GET: MonthlyCalender
        public ActionResult Index(int? page)
        {

            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            string statusEmpCheckInTime = Obj_dL_Home.FnGetEmployeeCheckInTime(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------
            ViewBag.EmpCheckInTime = statusEmpCheckInTime;


            //--old---
            CT_EmployeeAttendance objExp = new CT_EmployeeAttendance();
            List<CT_EmployeeAttendance> list = new List<CT_EmployeeAttendance>();
            //---

            int pageSize = 15;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<CT_EmployeeAttendance> stu = null;

            list = TempData["PrevNextAttendanceData"] as List<CT_EmployeeAttendance>;
            if (list == null || list.Count == 0)
            {
                int Month = 0;
                list = Obj_dL_Home.FnGetEmployeeAttendanceEveryMonth(EmployeePKID, Month);
                //Oj_CT.CT_CreateEmployeelist = list;
                stu = list.ToPagedList(pageIndex, pageSize);
            }
            else
            {
                stu = list.ToPagedList(pageIndex,pageSize);
            }
            return View(stu);
        }

        public ActionResult GetPreviousMonth()
        {
            //=======================================
            List<CT_EmployeeAttendance> list = new List<CT_EmployeeAttendance>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);

            DateTime dt = DateTime.Now;
            int Month = dt.Month;
            int Year = dt.Year;
            int PreviewMonthNumber =1;
            if (Session["PreviewMonthNumber"]!=null)
            {
                int MonthNumber = Convert.ToInt32(Session["PreviewMonthNumber"]);
                Session["PreviewMonthNumber"] = MonthNumber + 1;
            }
            else
            {
                Session["PreviewMonthNumber"] = 1;
            }
            PreviewMonthNumber = Convert.ToInt32(Session["PreviewMonthNumber"]);
            list = Obj_dL_Home.FnGetEmployeeAttendanceEveryMonth(EmployeePKID, PreviewMonthNumber);
            TempData["PrevNextAttendanceData"] = list;
            //=======================================
            JsonResult result = new JsonResult();
            result = this.Json(JsonConvert.SerializeObject("ddd"), JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult GetNextMonth()
        {
            //=======================================
            List<CT_EmployeeAttendance> list = new List<CT_EmployeeAttendance>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);

            DateTime dt = DateTime.Now;
            int Month = dt.Month;
            int Year = dt.Year;
            int PreviewMonthNumber = 1;
            if (Session["PreviewMonthNumber"] != null)
            {
                int MonthNumber = Convert.ToInt32(Session["PreviewMonthNumber"]);
                Session["PreviewMonthNumber"] = MonthNumber - 1;
            }
            else
            {
                Session["PreviewMonthNumber"] = 1;
            }
            PreviewMonthNumber = Convert.ToInt32(Session["PreviewMonthNumber"]);
            list = Obj_dL_Home.FnGetEmployeeAttendanceEveryMonth(EmployeePKID, PreviewMonthNumber);
            TempData["PrevNextAttendanceData"] = list;
            //=======================================
            JsonResult result = new JsonResult();
            result = this.Json(JsonConvert.SerializeObject("ddd"), JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}