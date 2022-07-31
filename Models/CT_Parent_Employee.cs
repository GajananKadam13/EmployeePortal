using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class CT_Parent_Employee
    {
        CT_CreateEmployee Obj_ct_CreEmp;
        CT_EmployeeEducation Obj_ct_Edu = new CT_EmployeeEducation();
        CT_EmployeeExperience Obj_ct_EmpExp = new CT_EmployeeExperience();
        CT_EmployeeDocuments Obj_ct_EmpDoc = new CT_EmployeeDocuments();
        CT_EmployeeSalary Obj_ct_EmpSal = new CT_EmployeeSalary();
       

    }
}