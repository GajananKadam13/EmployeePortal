using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortal.DataLayer;
using EmployeePortal.Models;
using Newtonsoft.Json;

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
        public ActionResult Index(CT_PostNewJobs objPost, string btn_Submit, int ?hdn_PostedJob_PKID)
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



    }
}