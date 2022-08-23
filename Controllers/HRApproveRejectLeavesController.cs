using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal.Controllers
{
    public class HRApproveRejectLeavesController : Controller
    {
        DL_Leave objdl_BalLeave = new DL_Leave();
        DL_ApproveRejectLeavesHR Objdl_AppRej = new DL_ApproveRejectLeavesHR();
        // GET: HRApproveRejectLeaves
        public ActionResult Index()
        {
            ViewBag.returnStatus = TempData["returnStatus"];
            return View();
        }

        public ActionResult GetEmployeeApplyLeaveApproveRejectHR()
        {
            JsonResult result = new JsonResult();
            List<CT_Leave> listLeaveBal = new List<CT_Leave>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            listLeaveBal = Objdl_AppRej.GetEmployeeApplyLeaveApproveRejectHR(EmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listLeaveBal), JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult CallAproveRejectPartialHR(int LeavePKID)
        {
            List<CT_Leave> OneLeave = new List<CT_Leave>();
            OneLeave = Objdl_AppRej.GetEmployeeParticularLeavesHR(LeavePKID);
            ViewBag.LeavePKID = OneLeave[0].LeavePKID;
            ViewBag.EmployeePKID = OneLeave[0].EmployeePKID;
            ViewBag.LeaveType = OneLeave[0].Leavetype;
            ViewBag.FromDate = OneLeave[0].FromdateFormat;
            ViewBag.ToDate = OneLeave[0].TodateFormat;
            ViewBag.ContactDetails = OneLeave[0].ContactDetails;
            ViewBag.Reason = OneLeave[0].Reason;
            ViewBag.CreatedOn = OneLeave[0].CreatedOnFormat;
            ViewBag.ManagerApproveRejectStatus = OneLeave[0].ManagerApproveRejectStatus;
            ViewBag.ManagerApproveRejectComment = OneLeave[0].ManagerApproveRejectComment;
            ViewBag.HRApproveRejectStatus = OneLeave[0].HRApproveRejectStatus;
            ViewBag.HRApproveRejectComment = OneLeave[0].HRApproveRejectComment;
            return PartialView("_ApproveRejPartialHR", LeavePKID);
        }


        [HttpPost]
        public ActionResult ApproveRejectLeavHR(string Comment, string ddlApproveReject, int hdn_LeavePKID)
        {
            string returnStatus = "";
            returnStatus=Objdl_AppRej.ApproveRejectLeavesByHR(Comment, ddlApproveReject, hdn_LeavePKID);
            TempData["returnStatus"] = returnStatus;
            return RedirectToAction("Index");
        }
    }
}