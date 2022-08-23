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
    public class LeaveController : Controller
    {
        DL_Leave objdl_BalLeave = new DL_Leave();
            DL_CreateEmployee objdl_CreateUser = new DL_CreateEmployee();
        // GET: ApplyLeave
        public ActionResult Index(string hdn_message)
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
        public ActionResult Index(CT_Leave obj,int ddlLeavetype=0 ,int hdn_LeavePKID=0,string btn_Submit = "")
        {
            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------

            ViewBag.Submit = btn_Submit;
            if (hdn_LeavePKID!=0)
            {
                obj.LeavePKID = hdn_LeavePKID;
            }
            string ReturnStatus = "";
            obj.Leavetype = Convert.ToString(ddlLeavetype);
            obj.EmployeePKID = EmployeePKID;
            ReturnStatus = objdl_BalLeave.FnApplyLeave(obj);
            ViewBag.Message = ReturnStatus;
            return View();
        }

        public ActionResult CheckTotalLeaveBalance(int SelectedItem)
        {

            JsonResult result = new JsonResult();
            CT_Leave objExp = new CT_Leave();
            List<CT_AddBalanceLeave> listLeaveBal = new List<CT_AddBalanceLeave>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            listLeaveBal = objdl_BalLeave.CheckTotalLeaveBalance(EmployeePKID);
            int TotalBalanceLeave = 0;
            if (1== SelectedItem)
            {
                TotalBalanceLeave = listLeaveBal[0].LossOfPay;
            }
            if (2 == SelectedItem)
            {
                TotalBalanceLeave = listLeaveBal[0].CasualLeave;
            }
            if (4 == SelectedItem)
            {
                TotalBalanceLeave = listLeaveBal[0].SickLeave;
            }
            if (5 == SelectedItem)
            {
                TotalBalanceLeave = listLeaveBal[0].RecreationalLeave;
            }
            result = this.Json(JsonConvert.SerializeObject(TotalBalanceLeave), JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult GetEmployeeApplyLeave()
        {
            JsonResult result = new JsonResult();
            List<CT_Leave> listLeaveBal = new List<CT_Leave>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            listLeaveBal = objdl_BalLeave.GetEmployeeApplyLeave(EmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listLeaveBal), JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult DeleteEmployeeLeaveById(int EmpLeavePKID)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            returnType = objdl_BalLeave.DeleteEmployeeLeaveById(EmpLeavePKID).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        

         ////########################################################################################################################################

         //--*********HR HR HR HR HR HR HR *****************-Add Balance leave by HR to  Employee-----START--CODE----------
        public ActionResult AddLeave(string hdn_message)
        {
            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------
            List<CT_CreateEmployee> objemp = objdl_CreateUser.FnForfecth_AllEmployee.ToList();
            ViewBag.AllEmployee = objemp;
            return View();
        }
        [HttpPost]
        public ActionResult AddLeave(CT_AddBalanceLeave obj, string ddlAllEmployee = "", int hdn_EmpPKID = 0, string btn_Submit = "")
        {
            string ReturnStatus = "";
            if(hdn_EmpPKID!=0)
            {
                obj.BalLeavePKID = hdn_EmpPKID;
            }
            List<CT_CreateEmployee> objemp = objdl_CreateUser.FnForfecth_AllEmployee.ToList();
            ViewBag.AllEmployee = objemp;
            obj.CreatedBy =Convert.ToInt32(Session["EmployeePKID"]);
            obj.EmployeePKID =Convert.ToInt32(ddlAllEmployee);
            ReturnStatus=objdl_BalLeave.FnEmployeeBalanceLeave(obj);
            ViewBag.Message= ReturnStatus;

            ViewBag.Submit = btn_Submit;
            return View();
        }

        public ActionResult GetEmployeeBalanceLeave()
        {
            JsonResult result = new JsonResult();
            CT_AddBalanceLeave objExp = new CT_AddBalanceLeave();
            List<CT_AddBalanceLeave> listLeaveBal = new List<CT_AddBalanceLeave>();
           
            listLeaveBal = objdl_BalLeave.GetAllEmployeeBalanceLeave();
            result = this.Json(JsonConvert.SerializeObject(listLeaveBal), JsonRequestBehavior.AllowGet);
            return result;
        }
        public ActionResult DeleteEmployeeBalanceLeaveById(int EmpBal_PKID)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            returnType = objdl_BalLeave.DeleteEmployeeBalanceLeaveById(EmpBal_PKID).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        //--***********HR HR HR HR HR HR HR ******************-Add Balance leave  by HR to  Employee-----END--CODE----------
    }
}