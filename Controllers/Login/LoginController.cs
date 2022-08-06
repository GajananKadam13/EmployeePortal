using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;

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
    }
}