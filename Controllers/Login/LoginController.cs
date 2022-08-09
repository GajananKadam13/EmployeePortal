using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;
using PagedList;

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
            DataTable dt = new DataTable();
            if (ModelState.IsValid)
            {
              
                dt = objdl_Log.FnCheckLogin(obj);
                if (dt.Rows.Count> 0 )
                {
                    Session["EmployeePKID"] = dt.Rows[0]["EmployeePKID"].ToString();
                    string [] Name=dt.Rows[0]["EmployeeName"].ToString().Split('-');

                    Session["EmployeeName"] = Name[0] +' '+Name[2];
                    string Designation = Name[5];
                    if(Designation =="1")
                    {
                        Session["Designation"] = "HR";
                    }
                    if (Designation == "2")
                    {
                        Session["Designation"] = "Software Engineer";
                    }
                    if (Designation == "3")
                    {
                        Session["Designation"] = "Manager";
                    }
                    if (Designation == "4")
                    {
                        Session["Designation"] = "Security";  
                    }
                   
                    Session["ProfilePictureName"] =Name[4];
                    ViewBag.Message = "Login Success";
                    //Session["LastEmployeeID"] =3;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Login Failed";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<CT_ResetPassword> resetList = null;
            CT_ResetPassword ObjResetPass = new CT_ResetPassword();
            List<CT_ResetPassword> list = new List<CT_ResetPassword>();


            DL_Home Obj_dL_Home = new DL_Home();
            int EmployeePKID = Convert.ToInt32(Session["EmployeePKID"]);
            string status = Obj_dL_Home.FnEmployeeCheckInOut(EmployeePKID);
            //----START----For Hide and show Onlien and Offline----------
            ViewBag.CheckInOuStatus = status;
            //---END-----For Hide and show Onlien and Offline----------

            //list = objdl_Log.FnGetEmployeesForResetPassword();
            // resetList = list.ToPagedList(pageIndex, pageSize);
            list = TempData["SearchEmployeeData"] as List<CT_ResetPassword>;
            if (list ==null )
            {
                list = objdl_Log.FnGetEmployeesForResetPassword();
                //Oj_CT.CT_CreateEmployeelist = list;
                resetList = list.ToPagedList(pageIndex, pageSize);
                return View(resetList);
            }
            else
            {
                ViewBag.searchEmployee = TempData["searchEmployee"];
                //Oj_CT.CT_CreateEmployeelist = list;
                resetList = list.ToPagedList(pageIndex, pageSize);
                return View(resetList);
            }



           

            //return View(resetList);

        }
        public ActionResult YesResetPassword(int? page,int EmployeePKID)
        {
            JsonResult result = new JsonResult();
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<CT_ResetPassword> resetList = null;
            CT_ResetPassword ObjResetPass = new CT_ResetPassword();
            List<CT_ResetPassword> list = new List<CT_ResetPassword>();

            list = objdl_Log.FnGetEmployeesForResetPassword();
            //Oj_CT.CT_CreateEmployeelist = list;
            resetList = list.ToPagedList(pageIndex, pageSize);

            string status= objdl_Log.FnEmployeesResetPassword(EmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(status), JsonRequestBehavior.AllowGet);
            return result;// View(result);

        }

        public ActionResult SearchEmployee(string searchEmployee)
        {
            CT_ResetPassword CT_Obj = new CT_ResetPassword();
            DL_Login objdl_Login = new DL_Login();
            List<CT_ResetPassword> list = new List<CT_ResetPassword>();
            list = objdl_Login.FnSearchEmployee_ForResetPassword(searchEmployee);
            CT_Obj.CT_ResetPasswordlist = list;
            TempData["SearchEmployeeData"] = CT_Obj.CT_ResetPasswordlist;
            TempData["searchEmployee"] = searchEmployee;
            return RedirectToAction("ResetPassword");
        }
    }
}