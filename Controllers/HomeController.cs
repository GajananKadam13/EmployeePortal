using System;
using System.Collections.Generic;
using System.IO;
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
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            string statusEmpCheckInTime = Obj_dL_Home.FnGetEmployeeCheckInTime(EmployeePKID);


            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------
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
        public ActionResult Get_HR_PostedNewJobs()
        {
            JsonResult result = new JsonResult();
            CT_PostNewJobs objExp = new CT_PostNewJobs();
            List<CT_PostNewJobs> listExp = new List<CT_PostNewJobs>();

            listExp = Obj_dL_Home.Get_HR_PostedNewJobs();
            result = this.Json(JsonConvert.SerializeObject(listExp), JsonRequestBehavior.AllowGet);
            return result;
        }


        [HttpPost]
        public ActionResult UploadReferenceResume(HttpPostedFileBase file_Resume , int hdn_Job_PKID)
        {
            JsonResult result = new JsonResult();
            if (file_Resume != null)
            {
                string path = Server.MapPath("~/ReferenceResume/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string EmpCompanyEmail = Session["EmployeeName"].ToString();

                string extension = System.IO.Path.GetExtension(file_Resume.FileName);
                var FileFinalName = EmpCompanyEmail + extension;
                file_Resume.SaveAs(path + FileFinalName);
                EmpCompanyEmail = FileFinalName;
            }

            result = this.Json(JsonConvert.SerializeObject("Test"), JsonRequestBehavior.AllowGet);
            return result;
        }
        public ActionResult CallResumePartial(int Job_PKID)
        {
            return PartialView("_ResumePartial",Job_PKID);

        }

        


    }
}