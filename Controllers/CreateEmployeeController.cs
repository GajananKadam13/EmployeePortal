using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;

namespace EmployeePortal.Controllers
{
    public class CreateEmployeeController : Controller
    {
        // GET: AddEmployee
        CT_CreateEmployee Oj_CT = new CT_CreateEmployee();
        DL_CreateEmployee objdl_CreateUser = new DL_CreateEmployee();
        public ActionResult Index(CT_CreateEmployee obj)
        {
            if (obj.EmployeePKID != 0)
            {
                //For Update
            }
            else
            {
                ModelState["ProfilePictureName"].Errors.Clear();
                ModelState["FirstName"].Errors.Clear();

                ModelState["MiddleName"].Errors.Clear();
                ModelState["LastName"].Errors.Clear();
                ModelState["Phone"].Errors.Clear();
                ModelState["PersonalEmail"].Errors.Clear();
                //ModelState["DateOfBirth"].Errors.Clear();


                ModelState["EmployeeEnrollmentID"].Errors.Clear();
                //ModelState["DateofJoining"].Errors.Clear();
                ModelState["CompanyEmail"].Errors.Clear();
                ModelState["ReportingEmployee"].Errors.Clear();

                ModelState["Department"].Errors.Clear();
                ModelState["Designation"].Errors.Clear();
                ModelState["AddressLine1"].Errors.Clear();
                ModelState["AddressLine2"].Errors.Clear();


                ModelState["City"].Errors.Clear();
                ModelState["State"].Errors.Clear();
                ModelState["ZipCode"].Errors.Clear();
                ModelState["Country"].Errors.Clear();



            }
            if(obj.MaritalStatus!="")
            {
                ViewBag.MaritalStatus = obj.MaritalStatus;
            }
            if (obj.Gender != "")
            {
                ViewBag.Gender = obj.Gender;
            }
            if (obj.Department != "")
            {
                ViewBag.Department = obj.Department;
            }
            
            //if (obj.Password != null)
            //{
            //    
            //    //ModelState["Password"].Errors.Clear();
            //    //obj.ConfirmPassword = Obj_CE.Password;
            //}

            //ModelState["Password"].Errors.Clear();

            //Obj_CE
            return View();
        }


        [HttpPost]  //Add Employee Information
        public ActionResult Index(CT_CreateEmployee Obj_CE, string gender, string MaritalStatus, HttpPostedFileBase ProfilePictureFile, string TypeofEmployee, DateTime? DateofJoining = null, DateTime? DateofBirth = null, string ddlDepartment = "", string ddlDesignation = "", string ddlReportingEmployee = "", string ddlCountry = "")
        {
            Obj_CE.Department = ddlDepartment;
            Obj_CE.Designation = ddlDesignation;
            Obj_CE.ReportingEmployee = ddlReportingEmployee;
            Obj_CE.Country = ddlCountry;
            if (ddlDepartment != "")
            {
                ModelState["Department"].Errors.Clear();
            }
            if (ddlDesignation != "")
            {
                ModelState["Designation"].Errors.Clear();
            }
            if (ddlReportingEmployee != "")
            {
                ModelState["ReportingEmployee"].Errors.Clear();
            }
            if (ddlCountry != "")
            {

                ModelState["Country"].Errors.Clear();
            }

            if (ProfilePictureFile != null)
            {
                if (ProfilePictureFile.FileName != "")
                {
                    Obj_CE.ProfilePictureName = ProfilePictureFile.FileName;
                    ModelState["ProfilePictureName"].Errors.Clear();
                }
            }


            if (ModelState.IsValid)
            {
                if (ProfilePictureFile != null)
                {
                    string path = Server.MapPath("~/UploadsImages/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    // //ProfilePictureFile.FileName + '_' + Obj_CE.CompanyEmail;
                    //string FileName = Path.GetFileName(ProfilePictureFile.FileName);
                    //string newFileName=FileName + '_'+ Obj_CE.CompanyEmail;
                    //ProfilePictureFile.SaveAs(path + newFileName);
                    ////ProfilePictureFile.SaveAs(path + Path.GetFileName(FileName));
                    //ViewBag.Message = "File uploaded successfully.";
                    //Obj_CE.ProfilePictureName = newFileName;/// ProfilePictureFile.FileName + '_' + Obj_CE.CompanyEmail;




                    string extension = System.IO.Path.GetExtension(ProfilePictureFile.FileName);
                    var FileFinalName = Obj_CE.CompanyEmail + extension;
                    ProfilePictureFile.SaveAs(path + FileFinalName);
                    Obj_CE.ProfilePictureName = FileFinalName;
                }
                Obj_CE.DateOfBirth = Convert.ToDateTime(DateofBirth);
                Obj_CE.Gender = gender;
                Obj_CE.MaritalStatus = MaritalStatus;
                Obj_CE.DateofJoining = Convert.ToDateTime(DateofJoining);


                Obj_CE.TypeofEmployee = TypeofEmployee;
                Obj_CE.CreatedBy = 0;//Convert.ToInt32(Session["Emp_PK_ID"]);
                string returnValue = objdl_CreateUser.FnCreateEmployee(Obj_CE);
                string [] arrayVal =  returnValue.Split('_');
                string status = arrayVal[0];
                string LastEmployeeID = arrayVal[1];
                if (status == "Success")
                {
                    Session["LastEmployeeID"] = LastEmployeeID;
                    ViewBag.Message = "Success";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddEmployeeEducation()
        {
            CT_EmployeeEducation obj = new CT_EmployeeEducation();
            List<CT_EmployeeEducation> list = new List<CT_EmployeeEducation>();
            if(Session["LastEmployeeID"]==""  || Session["LastEmployeeID"] == null)
            {

            }
            int LastEmployeeID =Convert.ToInt32(Session["LastEmployeeID"]);
            list= objdl_CreateUser.FnGetEmployeesEducation(1);
            obj.employeeEducationsModelList=list;
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddEmployeeEducation(CT_EmployeeEducation Obj_Edu, string ddlDegreee = "", string ddlSpecialization = "", DateTime? PassingYear = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            Obj_Edu.Degree = ddlDegreee;
            Obj_Edu.Specialization = ddlSpecialization;
            Obj_Edu.PassingYear = Convert.ToDateTime(PassingYear);
            Obj_Edu.StartDate = Convert.ToDateTime(StartDate);
            Obj_Edu.EndDate = Convert.ToDateTime(EndDate);

            if (ddlDegreee != "")
            {
                ModelState["Degree"].Errors.Clear();
            }
            if (ddlSpecialization != "")
            {
                ModelState["Specialization"].Errors.Clear();
            }


            if (ModelState.IsValid)
            {
                Obj_Edu.LastEmployeePKID=Convert.ToInt32(Session["LastEmployeeID"]);
                string returnValue = objdl_CreateUser.FnAddEmployeeEducation(Obj_Edu);
                if (returnValue == "Success")
                {
                    ViewBag.Message = "Success";
                }
            }

            return View();
        }
        public ActionResult AddEmployeeExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeExperience(CT_EmployeeExperience Obj_CE_Ex,string Reason, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            Obj_CE_Ex.StartDate =Convert.ToDateTime(StartDate);
            Obj_CE_Ex.EndDate = Convert.ToDateTime(EndDate);
            Obj_CE_Ex.Reason = Reason;

            if (ModelState.IsValid)
            {
                Obj_CE_Ex.LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
                string returnValue = objdl_CreateUser.FnAddEmployeeExperience(Obj_CE_Ex);
                if (returnValue == "Success")
                {
                    ViewBag.Message = "Success";
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult ViewEmployee(CT_CreateEmployee obj)
        {
            List<CT_CreateEmployee> list = new List<CT_CreateEmployee>();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            list = objdl_CreateUser.FnGetEmployees();
            Oj_CT.CT_CreateEmployeelist = list;
            return View(Oj_CT);
        }

        public ActionResult ViewEmployeeById(int EmployeePKID)
        {
            //CT_CreateEmployee obj = new CT_CreateEmployee();
            //obj = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);
            return RedirectToAction("Index", "EmployeeDetail", EmployeePKID);
        }
        public ActionResult EditEmployeeById(int EmployeePKID)
        {
            CT_CreateEmployee obj = new CT_CreateEmployee();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            obj = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);
            return RedirectToAction("Index", obj);
        }

        public ActionResult DeleteEmployeeById(int EmployeePKID)
        {
            string returnType = "";
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            returnType = objdl_CreateUser.FnDeleteEmployeeById(EmployeePKID).ToString();
            return RedirectToAction("Index", returnType);
        }

        public ActionResult CallCommanMessageModel()
        {
             
            return PartialView("_CommanMessagePartial");
        }



        //[HttpPost]
        //public ActionResult Index(CT_CreateEmployee obj, string ddlGender,int ddlRole,string Address,int hdn_Emp_pkid)
        //{
        //    string returntype = "";
        //    obj.Gender = ddlGender;
        //    obj.Role = ddlRole;
        //    obj.Address = Address;
        //    obj.EMP_PK_ID = hdn_Emp_pkid;
        //    if (ModelState.IsValid)
        //    {
        //        if (obj.EMP_PK_ID==0)
        //        {
        //            returntype = objdl_CreateUser.FnCreateEmployee(obj);

        //            if (returntype == "Success")
        //            {
        //                ViewBag.Message = "Registerd Success";
        //                return View(obj);
        //            }
        //            else
        //            {
        //                ViewBag.Message = " Failed";
        //            }
        //        }
        //        else
        //        {
        //            //Update Employee
        //            returntype = objdl_CreateUser.FnCreateEmployee(obj);
        //        }

        //    }
        //    return View(obj);
        //}

        //[HttpGet]
        //public ActionResult ViewEmployee(CT_CreateEmployee obj)
        //{
        //    List<CT_CreateEmployee> list = new List<CT_CreateEmployee>();
        //    //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
        //     list = objdl_CreateUser.FnGetEmployees();
        //    Oj_CT.CT_CreateEmployeelist = list;
        //    return View(Oj_CT);
        //}


        //public ActionResult ViewEmployeeById(int EmployeePKID)
        //{
        //     CT_CreateEmployee obj = new CT_CreateEmployee();
        //    //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
        //    obj = objdl_CreateUser.FnGetEmployeesById(EmployeePKID);
        //    return RedirectToAction("Index", obj);
        //}

        //public ActionResult DeleteEmployeeById(int EmployeePKID)
        //{
        //    string returnType = "";
        //    //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
        //    returnType= objdl_CreateUser.FnDeleteEmployeeById(EmployeePKID).ToString();
        //    return RedirectToAction("Index", returnType);
        //}


    }
}