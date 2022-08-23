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
    public class TotalBalanceLeaveEmployeeController : Controller
    {
        DL_TotalBalanceLeaveEmployee objdl_BalLeave = new DL_TotalBalanceLeaveEmployee();
        DL_CreateEmployee objdl_CreateUser = new DL_CreateEmployee();
        // GET: TotalBalanceLeaveEmployee
        public ActionResult Index()
        {
            GetEmployeeBalanceLeave();
            return View();
        }

        public ActionResult GetEmployeeBalanceLeave()
        {
            JsonResult result = new JsonResult();
            CT_AddBalanceLeave objExp = new CT_AddBalanceLeave();
            List<CT_AddBalanceLeave> listLeaveBal = new List<CT_AddBalanceLeave>();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            listLeaveBal = objdl_BalLeave.GetCurrentEmployeeBalanceLeave(EmployeePKID);

            ViewBag.BalLeavePKID = listLeaveBal[0].BalLeavePKID;
            ViewBag.EmployeePKID = listLeaveBal[0].EmployeePKID;
            ViewBag.EmployeeName = listLeaveBal[0].EmployeeName;
            ViewBag.LossOfPay = listLeaveBal[0].LossOfPay;
            ViewBag.CasualLeave = listLeaveBal[0].CasualLeave;
            ViewBag.CompOff = listLeaveBal[0].CompOff;
            ViewBag.SickLeave = listLeaveBal[0].SickLeave;
            ViewBag.RecreationalLeave = listLeaveBal[0].RecreationalLeave;
            ViewBag.CreatedOnFormat = listLeaveBal[0].CreatedOnFormat;

            result = this.Json(JsonConvert.SerializeObject(listLeaveBal), JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}