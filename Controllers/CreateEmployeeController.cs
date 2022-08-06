using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;
using PagedList;

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
            if (obj.MaritalStatus != "")
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

            //--------For Hide and show Onlien and Offline----------
            DL_Home ObjDlHome = new DL_Home();
            string status = ObjDlHome.FnEmployeeCheckInOut( Convert.ToInt32(Session["EmployeePKID"]));
            ViewBag.CheckInOuStatus = status;

            return View();
        }


        [HttpPost]  //Add Employee Information
        public ActionResult Index(CT_CreateEmployee Obj_CE, string gender, string MaritalStatus, HttpPostedFileBase ProfilePictureFile, string TypeofEmployee, DateTime? DateofJoining = null, DateTime? DateofBirth = null, string ddlDepartment = "", string ddlDesignation = "", string ddlReportingEmployee = "", string ddlCountry = "",string ddlRole="")
        {
            Obj_CE.Department = ddlDepartment;
            Obj_CE.Designation = ddlDesignation;
            Obj_CE.ReportingEmployee = ddlReportingEmployee;
            Obj_CE.Country = ddlCountry;
            Obj_CE.Role = ddlRole;
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
            if (ddlRole != "")
            {
                ModelState["Role"].Errors.Clear();
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
                if(Session["EmployeePKID"] !=null)
                {
                    Obj_CE.CreatedBy = Convert.ToInt32(Session["EmployeePKID"]); ;
                }
                else
                {
                    Obj_CE.CreatedBy = 0;//Convert.ToInt32(Session["EmployeePKID"]);
                }
                
                string returnValue = objdl_CreateUser.FnCreateEmployee(Obj_CE);
                string[] arrayVal = returnValue.Split('_');
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
        public ActionResult AddEmployeeEducation(string hdn_Message)
        {
            CT_EmployeeEducation obj = new CT_EmployeeEducation();
            List<CT_EmployeeEducation> list = new List<CT_EmployeeEducation>();
            if (TempData["EmployeeEducation"] != null)
            {
                int Edu_PKID = Convert.ToInt32(TempData["EmployeeEducation"]);
                obj = objdl_CreateUser.FnGetEmployeesEducationById(Edu_PKID);
                list = objdl_CreateUser.FnGetEmployeesEducation(1);
                obj.employeeEducationsModelList = list;
                ViewBag.Degree = obj.Degree;
                ViewBag.Specialization = obj.Specialization;
                return View(obj);
            }


            if (Session["LastEmployeeID"] == "" || Session["LastEmployeeID"] == null)
            {

            }
            int LastEmployeeID = Convert.ToInt32(Session["LastEmployeeID"]);
            list = objdl_CreateUser.FnGetEmployeesEducation(LastEmployeeID);
            obj.employeeEducationsModelList = list;
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddEmployeeEducation(CT_EmployeeEducation Obj_Edu, int? hdn_Edu_PKID, int? hdn_EmpEdu_PKID, string btnmainsub, string ddlDegreee = "", string ddlSpecialization = "", DateTime? PassingYear = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            CT_EmployeeEducation obj = new CT_EmployeeEducation();
            List<CT_EmployeeEducation> list = new List<CT_EmployeeEducation>();
            Obj_Edu.Degree = ddlDegreee;
            Obj_Edu.Specialization = ddlSpecialization;
            Obj_Edu.PassingYear = Convert.ToDateTime(PassingYear);
            Obj_Edu.StartDate = Convert.ToDateTime(StartDate);
            Obj_Edu.EndDate = Convert.ToDateTime(EndDate);
            if (hdn_Edu_PKID != 0)
            {
                Obj_Edu.Edu_PKID = Convert.ToInt32(hdn_Edu_PKID);
            }
            if (hdn_EmpEdu_PKID != 0)
            {
                Obj_Edu.Edu_PKID = Convert.ToInt32(hdn_EmpEdu_PKID);
            }
            if (Obj_Edu.Percentage != "")
            {
                bool perce = Obj_Edu.Percentage.Contains("%");
                if (perce)
                {

                }
                else
                {
                    Obj_Edu.Percentage += "%";
                }
            }



            //if (ddlDegreee != "")
            //{
            //    ModelState["Degree"].Errors.Clear();
            //}
            //if (ddlSpecialization != "")
            //{
            //    ModelState["Specialization"].Errors.Clear();
            //}


            //if (ModelState.IsValid)
            //{
            Obj_Edu.LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            string returnValue = objdl_CreateUser.FnAddEmployeeEducation(Obj_Edu);
            if (returnValue == "Success")
            {
                ViewBag.Message = "Success";
            }
            if (returnValue == "Updated")
            {
                ViewBag.Message = "Updated";
            }
            ViewBag.IsValid = "true";
            //}
            //else
            //{
            //ViewBag.IsValid = "false";
            //}
            ViewBag.Submit = btnmainsub;


            list = objdl_CreateUser.FnGetEmployeesEducation(Obj_Edu.LastEmployeePKID);
            obj.employeeEducationsModelList = list;

            return View();
        }

        [HttpPost]
        public ActionResult EditEmployeeEducation(int Edu_PKID)
        {
            CT_EmployeeEducation obj = new CT_EmployeeEducation();
            List<CT_EmployeeEducation> list = new List<CT_EmployeeEducation>();


            //list = objdl_CreateUser.FnGetEmployeesEducationById(Edu_PKID);
            //obj.employeeEducationsModelList = list;
            TempData["EmployeeEducation"] = Edu_PKID;
            return RedirectToAction("AddEmployeeEducation");


        }




        [HttpGet]
        public ActionResult ViewEmployee(CT_CreateEmployee obj, int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<CT_CreateEmployee> stu = null;
            ///////
            List<CT_CreateEmployee> list = new List<CT_CreateEmployee>();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            //list = TempData["SearchEmployeeData"];

            //--------For Hide and show Onlien and Offline----------
            DL_Home ObjDlHome = new DL_Home();
            string status = ObjDlHome.FnEmployeeCheckInOut(Convert.ToInt32(Session["EmployeePKID"])); 
            ViewBag.CheckInOuStatus = status;
            //-------------------
            list = TempData["SearchEmployeeData"] as List<CT_CreateEmployee>;
            if (list == null)
            {
                list = objdl_CreateUser.FnGetEmployees();
                //Oj_CT.CT_CreateEmployeelist = list;
                stu = list.ToPagedList(pageIndex, pageSize);
                return View(stu);
            }
            else
            {
                ViewBag.searchEmployee = TempData["searchEmployee"];
                //Oj_CT.CT_CreateEmployeelist = list;
                stu = list.ToPagedList(pageIndex, pageSize);
                return View(stu);
            }
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
        public ActionResult EditEmployeeByIdForEdit(int EmployeePKID)
        {
            CT_CreateEmployee obj = new CT_CreateEmployee();
            Session["LastEmployeeID"] = EmployeePKID;

            obj = objdl_CreateUser.FnGetEmployeesByIdForEdit(EmployeePKID);
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

        public ActionResult SearchEmployee(string searchEmployee)
        {
            List<CT_CreateEmployee> list = new List<CT_CreateEmployee>();
            list = objdl_CreateUser.FnSearchEmployee(searchEmployee);
            Oj_CT.CT_CreateEmployeelist = list;
            TempData["SearchEmployeeData"] = Oj_CT.CT_CreateEmployeelist;
            TempData["searchEmployee"] = searchEmployee;
            return RedirectToAction("ViewEmployee");
        }

        //------START-----AddEmployeeExperience-----------------------------------
        public ActionResult AddEmployeeExperience(string hdn_Message)
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployeeExperience(CT_EmployeeExperience Obj_CE_Ex, int? hdn_EmpExp_PKID, string btn_submitMain, string Reason, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            Obj_CE_Ex.StartDate = Convert.ToDateTime(StartDate);
            Obj_CE_Ex.EndDate = Convert.ToDateTime(EndDate);
            Obj_CE_Ex.Reason = Reason;


         
            if(Session["LastEmployeeID"]!=null)
            {
                Obj_CE_Ex.LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else{
                Obj_CE_Ex.LastEmployeePKID = 0;
            }
            Obj_CE_Ex.Exp_PKID = Convert.ToInt32(hdn_EmpExp_PKID);

            //if (ModelState.IsValid)
            //


           

            string returnValue = objdl_CreateUser.FnAddEmployeeExperience(Obj_CE_Ex);
            if (returnValue == "Success")
            {
                ViewBag.Message = "Success";
            }
            if (returnValue == "Updated")
            {
                ViewBag.Message = "Updated";
            }

            ViewBag.Submit = btn_submitMain;
            // }
            return View();
        }

        public ActionResult GetData()
        {
            JsonResult result = new JsonResult();
            DataTable data = null;
            string Name = "Gajanan";
            List<string> my = new List<string>();

            CT_EmployeeExperience objExp = new CT_EmployeeExperience();
            List<CT_EmployeeExperience> listExp = new List<CT_EmployeeExperience>();
            int LastEmployeePKID = 0;
            if (Session["LastEmployeeID"] != null)
            {
                LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else
            {
                LastEmployeePKID = 0;
            }
            listExp = objdl_CreateUser.FnGetEmployeesExperience(LastEmployeePKID);
            ///obj.employeeEducationsModelList = list;


            // Load Data.   
            // Filter data with input query parameters.                    
            // Prepare Ajax JSON Data Result.  


            result = this.Json(JsonConvert.SerializeObject(listExp), JsonRequestBehavior.AllowGet);

            // Return info.  
            return result;
        }

        public ActionResult GetEmployeeEducationData()
        {
            JsonResult result = new JsonResult();

            CT_EmployeeEducation objExp = new CT_EmployeeEducation();
            List<CT_EmployeeEducation> listExp = new List<CT_EmployeeEducation>();
            int LastEmployeePKID = 0;
            if (Session["LastEmployeeID"] != null)
            {
                 LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else
            {
                 LastEmployeePKID = 0;
            }
            listExp = objdl_CreateUser.GetEmployeeEducationData(LastEmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listExp), JsonRequestBehavior.AllowGet);
            return result;
        }


        public ActionResult DeleteEmployeeEducationById(int EmployeeEduPKID)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            returnType = objdl_CreateUser.DeleteEmployeeEducationById(EmployeeEduPKID).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        public ActionResult DeleteEmployeeExperienceById(int EmployeeEduPKID)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            //ViewBag.userdetails = objdl_CreateUser.FnGetEmployees();
            returnType = objdl_CreateUser.DeleteEmployeeEducationById(EmployeeEduPKID).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        //--------END----------AddEmployeeExperience----------------------------


        ////------START---CODE-----Employee Documetns SECTION--------
        ////------START--------AddEmployeeDocumetns--------
        public ActionResult AddEmployeeDocumetns(string hdn_Message)
        {
            CT_EmployeeDocuments Obj_EDo = new CT_EmployeeDocuments();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeDocumetns(CT_EmployeeDocuments Obj_EDo,int? hdn_EmpDocuments_PKID, string btn_Submit, HttpPostedFileBase EmployeeDocumentsFile, string hdn_ConfirmDeleteOrNotImage="")
        {
            string returnType = "";

            if (hdn_ConfirmDeleteOrNotImage != "")
            {
                string filePath = Server.MapPath("~/UploadsDocuments/" + hdn_ConfirmDeleteOrNotImage);
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
            }

            if (hdn_EmpDocuments_PKID != 0)
            {
                Obj_EDo.Doc_PKID = Convert.ToInt32(hdn_EmpDocuments_PKID);
            }

            if (EmployeeDocumentsFile != null)
            {
                string path = Server.MapPath("~/UploadsDocuments/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string extension = System.IO.Path.GetExtension(EmployeeDocumentsFile.FileName);
                string EmployeeId = Convert.ToString(Session["LastEmployeeID"]);
                Obj_EDo.Employee_PKID =Convert.ToInt32(EmployeeId);
                var FileFinalName = EmployeeId + Obj_EDo.DocumentName + extension;
                EmployeeDocumentsFile.SaveAs(path + FileFinalName);
                Obj_EDo.DocumentName = FileFinalName;
                Obj_EDo.CreatedBy = Convert.ToString(Session["EmployeePKID"]);
                returnType = objdl_CreateUser.FnAddEmployeeDocumetns(Obj_EDo);
            }

              ViewBag.Submit = btn_Submit;

            if (returnType == "Success")
            {
                ViewBag.Message = "Success";
            }
            if (returnType == "Updated")
            {
                ViewBag.Message = "Updated";
            }


            //var filePath = Server.MapPath("~/UploadsDocuments/" + "sdfs");


            return View();
        }
        ////------END--------AddEmployeeDocumetns--------

        ////------START--------GetEmployeeDocumetnsData--------
        public ActionResult GetEmployeeDocumetnsData()
        {
            JsonResult result = new JsonResult();

            CT_EmployeeDocuments objExp = new CT_EmployeeDocuments();
            List<CT_EmployeeDocuments> listEmpDoc = new List<CT_EmployeeDocuments>();
            int LastEmployeePKID = 0;
            if (Session["LastEmployeeID"] != null)
            {
                LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else
            {
                LastEmployeePKID = 0;
            }
            listEmpDoc = objdl_CreateUser.GetEmployeeDocumetnsData(LastEmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listEmpDoc), JsonRequestBehavior.AllowGet);
            return result;
        }
        ////------END--------GetEmployeeDocumetnsData--------
        public ActionResult DeleteEmployeeDocumetnsById(int Doc_PKIDEmployee)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            returnType = objdl_CreateUser.FnDeleteEmployeeDocumetnsById(Doc_PKIDEmployee).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }
        ////------END---CODE-----Employee Salary SECTION--------
        



        ////------START---CODE-----Employee Salary SECTION--------
        ////------START--------AddEmployeeSalary--------
        public ActionResult AddEmployeeSalary(string hdn_Message)
        {
            CT_EmployeeSalary Obj_EDo = new CT_EmployeeSalary();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeSalary(CT_EmployeeSalary Obj_ESal, string hdn_Message, int? hdn_EmpSalary_PKID, string btn_Submit)
        {
            string returnType = "";

            if (hdn_EmpSalary_PKID != 0)
            {
                Obj_ESal.Sal_PKID = Convert.ToInt32(hdn_EmpSalary_PKID);
            }

            if (Session["LastEmployeeID"] != null)
            {
                Obj_ESal.Employee_PKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else
            {
                Obj_ESal.Employee_PKID = 0;
            }

            Obj_ESal.CreatedBy = Convert.ToInt32(Session["EmployeePKID"]);


            returnType = objdl_CreateUser.FnAddEmployeeSalary(Obj_ESal);
            ViewBag.Submit = btn_Submit;

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
        public ActionResult GetEmployeeSalaryData()
        {
            JsonResult result = new JsonResult();
            

            CT_EmployeeSalary objExp = new CT_EmployeeSalary();
            List<CT_EmployeeSalary> listEmpDoc = new List<CT_EmployeeSalary>();
            int LastEmployeePKID = 0;
            if (Session["LastEmployeeID"] != null)
            {
                LastEmployeePKID = Convert.ToInt32(Session["LastEmployeeID"]);
            }
            else
            {
                LastEmployeePKID = 0;
            }
            listEmpDoc = objdl_CreateUser.GetEmployeeSalaryData(LastEmployeePKID);
            result = this.Json(JsonConvert.SerializeObject(listEmpDoc), JsonRequestBehavior.AllowGet);
            return result;
        }
        public ActionResult DeleteEmployeeSalaryById(int Sal_PKIDEmployee)
        {
            string returnType = "";
            JsonResult result = new JsonResult();
            returnType = objdl_CreateUser.FnDeleteEmployeeSalaryById(Sal_PKIDEmployee).ToString();
            result = this.Json(JsonConvert.SerializeObject(returnType), JsonRequestBehavior.AllowGet);
            return result;
        }

        



        ////------END--------AddEmployeeSalary--------
        ////------END---CODE-----Employee Salary SECTION--------
    }
}