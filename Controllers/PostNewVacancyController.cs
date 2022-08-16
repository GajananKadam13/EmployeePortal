using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;
using PagedList;

namespace EmployeePortal.Controllers
{
    public class PostNewVacancyController : Controller
    {
        DL_PostNewVacancy objDl_PostVac = new DL_PostNewVacancy();
        // GET: PostNewVacancy
        public ActionResult Index()
        {
            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;

            return View();
        }

        [HttpPost]
        public ActionResult Index(CT_PostNewJobs objPost, string btn_Submit, int? hdn_PostedJob_PKID)
        {
            string returnType = "";
            ViewBag.Submit = btn_Submit;
            if (hdn_PostedJob_PKID != 0 && hdn_PostedJob_PKID != null)
            {
                objPost.PoJob_PKID = Convert.ToInt32(hdn_PostedJob_PKID);
            }

            objPost.CreatedBy = Convert.ToInt32(Session["EmployeePKID"]);

            returnType = objDl_PostVac.FnAddNewJobVacancy(objPost);
            ViewBag.AddedJobStatus = returnType;


            if (returnType == "Success")
            {
                ViewBag.Message = "Success";
            }
            if (returnType == "Updated")
            {
                ViewBag.Message = "Updated";
            }
            return View();
        }
        public ActionResult GetPostNewVacancyData()
        {
            JsonResult result = new JsonResult();
            CT_PostNewJobs objExp = new CT_PostNewJobs();
            List<CT_PostNewJobs> listExp = new List<CT_PostNewJobs>();
            //int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            listExp = objDl_PostVac.FnGetAllJobVacancy();
            result = this.Json(JsonConvert.SerializeObject(listExp), JsonRequestBehavior.AllowGet);

            return result;
        }


        public ActionResult DeletePostedJobById(int PostedJob_PKID)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            returnType = objDl_PostVac.DeletePostedJobById(PostedJob_PKID).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        public ActionResult ViewAppliedJob(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<CT_ReferanceResume> resetList = null;
            CT_ReferanceResume ObjResetPass = new CT_ReferanceResume();
            List<CT_ReferanceResume> list = new List<CT_ReferanceResume>();


            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------

            //list = objdl_Log.FnGetEmployeesForResetPassword();
            // resetList = list.ToPagedList(pageIndex, pageSize);

            list = TempData["SearchResumeData"] as List<CT_ReferanceResume>;
            if (list == null)
            {
                list = objDl_PostVac.FnViewEmployeeAppliedJob();
                resetList = list.ToPagedList(pageIndex, pageSize);
                return View(resetList);
            }
            else
            {
                ViewBag.searchResume = TempData["searchResume"];
                resetList = list.ToPagedList(pageIndex, pageSize);
                return View(resetList);
            }
        }

        [HttpPost]
        public ActionResult ApproveRejectModel(int Refer_PKID)
        {
            return PartialView("ApproveRejectCandidateResume", Refer_PKID);
        }

        public ActionResult SaveApproveReject(string status, string HRComment, int Ref_PKID)
        {
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            JsonResult result = new JsonResult();
            var ReturnStatus = objDl_PostVac.FnAddApproveRejectCandidateResume(status, HRComment, EmployeePKID, Ref_PKID);
            result = this.Json(JsonConvert.SerializeObject(ReturnStatus), JsonRequestBehavior.AllowGet);
            return result;

        }

        public ActionResult SearchByResumeStatus(string searchStatus)
        {
            List<CT_ReferanceResume> list = new List<CT_ReferanceResume>();
            list = objDl_PostVac.FnSearchStaus(searchStatus);
           // Oj_CT.CT_CreateEmployeelist = list;
            TempData["SearchResumeData"] = list;//Oj_CT.CT_CreateEmployeelist;
            TempData["searchResume"] = searchStatus;
            return RedirectToAction("ViewAppliedJob");
        }



    }
}