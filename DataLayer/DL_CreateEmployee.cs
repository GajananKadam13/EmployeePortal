using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using EmployeePortal.Models;

namespace EmployeePortal.DataLayer
{
    public class DL_CreateEmployee : DL_Base
    {
        public string FnCreateEmployee(CT_CreateEmployee obj_CT_Log)
        {
            string returntype = "";
            int returntype2 = 0;

            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_CreateEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", obj_CT_Log.EmployeePKID);
                        cmd.Parameters.AddWithValue("@ProfilePictureName", obj_CT_Log.ProfilePictureName);
                        cmd.Parameters.AddWithValue("@FirstName", obj_CT_Log.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", obj_CT_Log.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", obj_CT_Log.LastName);
                        cmd.Parameters.AddWithValue("@Phone", obj_CT_Log.Phone);
                        cmd.Parameters.AddWithValue("@PersonalEmail", obj_CT_Log.PersonalEmail);
                        cmd.Parameters.AddWithValue("@DateOfBirth", obj_CT_Log.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", obj_CT_Log.Gender);
                        cmd.Parameters.AddWithValue("@MaritalStatus", obj_CT_Log.MaritalStatus);
                        cmd.Parameters.AddWithValue("@Description", obj_CT_Log.Description);
                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@EmployeeEnrollmentID", obj_CT_Log.EmployeeEnrollmentID);
                        cmd.Parameters.AddWithValue("@DateofJoining", obj_CT_Log.DateofJoining);
                        cmd.Parameters.AddWithValue("@CompanyEmail", obj_CT_Log.CompanyEmail);
                        cmd.Parameters.AddWithValue("@Department", obj_CT_Log.Department);
                        cmd.Parameters.AddWithValue("@Designation", obj_CT_Log.Designation);
                        cmd.Parameters.AddWithValue("@ReportingEmployee", obj_CT_Log.ReportingEmployee);
                        cmd.Parameters.AddWithValue("@TypeofEmployee", obj_CT_Log.TypeofEmployee);
                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@AddressLine1", obj_CT_Log.AddressLine1);
                        cmd.Parameters.AddWithValue("@AddressLine2", obj_CT_Log.AddressLine2);
                        cmd.Parameters.AddWithValue("@City", obj_CT_Log.City);
                        cmd.Parameters.AddWithValue("@State", obj_CT_Log.State);
                        cmd.Parameters.AddWithValue("@ZipCode", obj_CT_Log.ZipCode);
                        cmd.Parameters.AddWithValue("@Country", obj_CT_Log.Country);
                        cmd.Parameters.AddWithValue("@Role", obj_CT_Log.Role);
                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@CreatedBy", obj_CT_Log.CreatedBy);


                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@LastEmployeePKID", SqlDbType.Int);
                        cmd.Parameters["@LastEmployeePKID"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value + '_' + cmd.Parameters["@LastEmployeePKID"].Value;
                        //returntype2 =Convert.ToInt32(cmd.Parameters["@LastEmployeePKID"].Value);

                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<CT_CreateEmployee> FnGetEmployees()
        {
            List<CT_CreateEmployee> CT_CreateEmployee_list = new List<CT_CreateEmployee>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployee", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_CreateEmployee obj = new CT_CreateEmployee();
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.ProfilePictureName = reader["ProfilePictureName"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.MiddleName = reader["MiddleName"].ToString();

                            obj.LastName = reader["LastName"].ToString();
                            obj.Phone = reader["Phone"].ToString();
                            obj.PersonalEmail = reader["PersonalEmail"].ToString();
                            obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                            obj.DateOfBirthFormat = Convert.ToString(obj.DateOfBirth.Date.ToString("yyyy/MM/dd"));
                            obj.Gender = reader["Gender"].ToString();
                            obj.MaritalStatus = reader["MaritalStatus"].ToString();
                            obj.Description = reader["Description"].ToString();
                            obj.EmployeeEnrollmentID = reader["EmployeeEnrollmentID"].ToString();
                            obj.DateofJoining = Convert.ToDateTime(reader["DateofJoining"].ToString());
                            obj.CompanyEmail = reader["CompanyEmail"].ToString();
                            obj.Department = reader["Department"].ToString();
                            obj.Designation = reader["Designation"].ToString();
                            obj.ReportingEmployee = reader["ReportingEmployee"].ToString();
                            obj.TypeofEmployee = reader["TypeofEmployee"].ToString();
                            obj.AddressLine1 = reader["AddressLine1"].ToString();
                            obj.AddressLine2 = reader["AddressLine2"].ToString();
                            obj.City = reader["City"].ToString();

                            obj.State = reader["State"].ToString();
                            obj.ZipCode = reader["ZipCode"].ToString();
                            obj.Country = reader["Country"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();
                            obj.Password = reader["Password"].ToString();

                            obj.EducationStatus = reader["EducationStatus"].ToString();
                            obj.ExperienceStatus = reader["ExperienceStatus"].ToString();
                            obj.DocumentsStatus = reader["DocumentsStatus"].ToString();
                            obj.SalaryStatus = reader["SalaryStatus"].ToString();

                            CT_CreateEmployee_list.Add(obj);
                        }

                        return CT_CreateEmployee_list;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public string FnDeleteEmployeeById(int EmployeePKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("DeleteEmployeebyId", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();

                    }

                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }





        public CT_CreateEmployee FnGetEmployeesById(int EmployeePKID)
        {
            CT_CreateEmployee obj = new CT_CreateEmployee();
            
            List<CT_EmployeeEducation> CT_EmployeeEducationlist = new List<CT_EmployeeEducation>();
            List<CT_EmployeeExperience> CT_EmployeeExperiencelist = new List<CT_EmployeeExperience>();
            List<CT_EmployeeDocuments> CT_EmployeeDocumentslist = new List<CT_EmployeeDocuments>();
            


            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        
                            while (reader.Read())
                            {
                                obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                                obj.ProfilePictureName = reader["ProfilePictureName"].ToString();
                                obj.FirstName = reader["FirstName"].ToString();
                                obj.MiddleName = reader["MiddleName"].ToString();

                                obj.LastName = reader["LastName"].ToString();
                                obj.Phone = reader["Phone"].ToString();
                                obj.PersonalEmail = reader["PersonalEmail"].ToString();
                                obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                                obj.Gender = reader["Gender"].ToString();
                                obj.MaritalStatus = reader["MaritalStatus"].ToString();
                                obj.Description = reader["Description"].ToString();
                                obj.EmployeeEnrollmentID = reader["EmployeeEnrollmentID"].ToString();
                                obj.DateofJoining = Convert.ToDateTime(reader["DateofJoining"].ToString());
                                obj.CompanyEmail = reader["CompanyEmail"].ToString();
                                obj.Department = reader["Department"].ToString();
                                obj.Designation = reader["Designation"].ToString();
                                obj.ReportingEmployee = reader["ReportingEmployee"].ToString();
                                obj.TypeofEmployee = reader["TypeofEmployee"].ToString();
                                obj.AddressLine1 = reader["AddressLine1"].ToString();
                                obj.AddressLine2 = reader["AddressLine2"].ToString();
                                obj.City = reader["City"].ToString();

                                obj.State = reader["State"].ToString();
                                obj.ZipCode = reader["ZipCode"].ToString();
                                obj.Country = reader["Country"].ToString();
                                obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                                obj.Status = reader["Status"].ToString();
                                obj.Password = reader["Password"].ToString();



                                //-----------------------------------------------------------------------------------------------

                                
                            }

                        reader.NextResult();
                        while (reader.Read())
                        {
                            //############################################################
                            //==============Education===================================
                            CT_EmployeeEducation CT_EmployeeOb = new CT_EmployeeEducation();
                            int VarDegree=Convert.ToInt32(reader["Degree"].ToString());
                            if (VarDegree == 1)
                            {
                                CT_EmployeeOb.Degree = "Bachelor of Engineering";
                            }
                            if (VarDegree == 2)
                            {
                                CT_EmployeeOb.Degree = "Masters of Engineering";
                            }
                            if (VarDegree == 3)
                            {
                                CT_EmployeeOb.Degree = "Master of Computer Applications";
                            }
                            if (VarDegree == 4)
                            {
                                CT_EmployeeOb.Degree = "Bachelors of Business Administration";
                            }
                            if (VarDegree == 5)
                            {
                                CT_EmployeeOb.Degree = "Masters of Business Administration";
                            }
                            if (VarDegree == 6)
                            {
                                CT_EmployeeOb.Degree = "Bachelor of Arts";
                            }
                            if (VarDegree == 7)
                            {
                                CT_EmployeeOb.Degree = "Bachelor of Commerce";
                            }
                            if (VarDegree == 8)
                            {
                                CT_EmployeeOb.Degree = "Masters of Commerce";
                            }
                            if (VarDegree == 9)
                            {
                                CT_EmployeeOb.Degree = "HSC";
                            }
                            if (VarDegree == 10)
                            {
                                CT_EmployeeOb.Degree = "SSC";
                            }

                           
                            CT_EmployeeOb.Specialization = reader["Specialization"].ToString();
                            CT_EmployeeOb.PassingYear =Convert.ToDateTime(reader["PassingYear"].ToString());
                            CT_EmployeeOb.Institute = reader["Institute"].ToString();
                            CT_EmployeeOb.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            CT_EmployeeOb.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            CT_EmployeeOb.Percentage = reader["Percentage"].ToString();

                            //==============Education===================================
                            CT_EmployeeEducationlist.Add(CT_EmployeeOb);
                        }
                        obj.CT_EmployeeEducationlist = CT_EmployeeEducationlist;

                        reader.NextResult();
                        while (reader.Read())
                        {
                            //############################################################
                            //=================Experience================================
                            CT_EmployeeExperience CT_EmployeeExpObj = new CT_EmployeeExperience();
                            CT_EmployeeExpObj.Organization = reader["Organization"].ToString();
                            CT_EmployeeExpObj.ExperienceDesignation = reader["ExperienceDesignation"].ToString();
                            CT_EmployeeExpObj.StartDate = Convert.ToDateTime(reader["ExperienceStartDate"].ToString());
                            CT_EmployeeExpObj.EndDate = Convert.ToDateTime(reader["ExperienceEndDate"].ToString());
                            CT_EmployeeExpObj.StartSalary = reader["StartSalary"].ToString();
                            CT_EmployeeExpObj.EndSalary = reader["EndSalary"].ToString();
                            CT_EmployeeExpObj.Reason = reader["Reason"].ToString();
                            //=================Experience================================
                            CT_EmployeeExperiencelist.Add(CT_EmployeeExpObj);
                        }
                        obj.CT_EmployeeExperiencelist = CT_EmployeeExperiencelist;
                        reader.NextResult();
                        while (reader.Read())
                        {
                            //############################################################
                            //===============Documents==================================
                            CT_EmployeeDocuments CT_EmployeeDocumentsObj = new CT_EmployeeDocuments();
                            CT_EmployeeDocumentsObj.DocumentName = reader["DocumentName"].ToString();
                            //===============Documents==================================
                            CT_EmployeeDocumentslist.Add(CT_EmployeeDocumentsObj);
                        }
                        obj.CT_EmployeeDocumentslist = CT_EmployeeDocumentslist;
                        reader.NextResult();
                        while (reader.Read())
                        {
                            //############################################################
                            //===============Salary==================================
                            obj.BasicSalary = reader["BasicSalary"].ToString();
                            obj.HouseRentAllowences = reader["HouseRentAllowences"].ToString();
                            obj.ConveyanceAllowences = reader["ConveyanceAllowences"].ToString();
                            obj.MedicalAllowences = reader["MedicalAllowences"].ToString();
                            obj.SpecialAllowences = reader["SpecialAllowences"].ToString();
                            obj.GrossSalary = reader["GrossSalary"].ToString();
                            obj.EPF = reader["EPF"].ToString();
                            obj.HealthInsuranceESI = reader["HealthInsuranceESI"].ToString();
                            obj.NetPay = reader["NetPay"].ToString();
                            //===============Salary==================================
                        }


                        return obj;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public CT_CreateEmployee FnGetEmployeesByIdForEdit(int EmployeePKID)
        {
            CT_CreateEmployee obj = new CT_CreateEmployee();

            List<CT_EmployeeEducation> CT_EmployeeEducationlist = new List<CT_EmployeeEducation>();
            List<CT_EmployeeExperience> CT_EmployeeExperiencelist = new List<CT_EmployeeExperience>();
            List<CT_EmployeeDocuments> CT_EmployeeDocumentslist = new List<CT_EmployeeDocuments>();



            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeByIdForEdit", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        con.Open();
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.ProfilePictureName = reader["ProfilePictureName"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.MiddleName = reader["MiddleName"].ToString();

                            obj.LastName = reader["LastName"].ToString();
                            obj.Phone = reader["Phone"].ToString();
                            obj.PersonalEmail = reader["PersonalEmail"].ToString();
                            obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                            obj.Gender = reader["Gender"].ToString();
                            obj.MaritalStatus = reader["MaritalStatus"].ToString();
                            obj.Description = reader["Description"].ToString();
                            obj.EmployeeEnrollmentID = reader["EmployeeEnrollmentID"].ToString();
                            obj.DateofJoining = Convert.ToDateTime(reader["DateofJoining"].ToString());
                            obj.CompanyEmail = reader["CompanyEmail"].ToString();
                            obj.Department = reader["Department"].ToString();
                            obj.Designation = reader["Designation"].ToString();
                            obj.ReportingEmployee = reader["ReportingEmployee"].ToString();
                            obj.TypeofEmployee = reader["TypeofEmployee"].ToString();
                            obj.AddressLine1 = reader["AddressLine1"].ToString();
                            obj.AddressLine2 = reader["AddressLine2"].ToString();
                            obj.City = reader["City"].ToString();

                            obj.State = reader["State"].ToString();
                            obj.ZipCode = reader["ZipCode"].ToString();
                            obj.Country = reader["Country"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();
                            obj.Password = reader["Password"].ToString();
                            obj.Role = reader["Role"].ToString();


                            //-----------------------------------------------------------------------------------------------
                        }



                        return obj;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        //-----START-----Employee Education Part-------------------------------------
        public string FnAddEmployeeEducation(CT_EmployeeEducation Obj_Emp_Edu)
        {
            string returntype = "";

            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddEmployeeEducation", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Edu_PKID", Obj_Emp_Edu.Edu_PKID);
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", Obj_Emp_Edu.LastEmployeePKID);
                        cmd.Parameters.AddWithValue("@Degree", Obj_Emp_Edu.Degree);
                        cmd.Parameters.AddWithValue("@Specialization", Obj_Emp_Edu.Specialization);
                        cmd.Parameters.AddWithValue("@PassingYear", Obj_Emp_Edu.PassingYear);
                        cmd.Parameters.AddWithValue("@Institute", Obj_Emp_Edu.Institute);
                        cmd.Parameters.AddWithValue("@StartDate", Obj_Emp_Edu.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Obj_Emp_Edu.EndDate);
                        cmd.Parameters.AddWithValue("@Percentage", Obj_Emp_Edu.Percentage);


                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_Emp_Edu.CreatedBy);


                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }




        public List<CT_EmployeeEducation> GetEmployeeEducationData(int LastEmployeePKID)
        {
            List<CT_EmployeeEducation> CT_EmployeeEducation_List = new List<CT_EmployeeEducation>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeEducation", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeEducation obj = new CT_EmployeeEducation ();
                            obj.Edu_PKID = Convert.ToInt32(reader["Edu_PKID"].ToString());
                            obj.LastEmployeePKID = Convert.ToInt32(reader["Employee_PKID"].ToString());

                            int valDegree =Convert.ToInt32(reader["Degree"].ToString());
                            obj.Degree =reader["Degree"].ToString();
                            if (valDegree==1)
                            {
                                obj.DegreeText = "Bachelor of Engineering";
                            }
                            if (valDegree == 2)
                            {
                                obj.DegreeText = "Masters of Engineering";
                            }
                            if (valDegree == 3)
                            {
                                obj.DegreeText = "Master of Computer Applications";
                            }
                            if (valDegree == 4)
                            {
                                obj.DegreeText = "Bachelors of Business Administration";
                            }
                            if (valDegree == 5)
                            {
                                obj.DegreeText = "Masters of Business Administration";
                            }
                            if (valDegree == 6)
                            {
                                obj.DegreeText = "Bachelor of Arts";
                            }
                            if (valDegree == 7)
                            {
                                obj.DegreeText = "Bachelor of Commerce";
                            }
                            if (valDegree == 8)
                            {
                                obj.DegreeText = "Masters of Commerce";
                            }
                            if (valDegree == 9)
                            {
                                obj.DegreeText = "HSC";
                            }
                            if (valDegree == 10)
                            {
                                obj.DegreeText = "SSC";
                            }


                            int valSpecialization = Convert.ToInt32(reader["Specialization"].ToString());
                            obj.Specialization = reader["Specialization"].ToString();
                            if (valSpecialization == 1)
                            {
                                obj.SpecializationText = "Bachelor of Engineering";
                            }
                            if (valSpecialization == 2)
                            {
                                obj.SpecializationText = "Masters of Engineering";
                            }
                            if (valSpecialization == 3)
                            {
                                obj.SpecializationText = "Master of Computer Applications";
                            }
                            if (valSpecialization == 4)
                            {
                                obj.SpecializationText = "Bachelors of Business Administration";
                            }
                            if (valSpecialization == 5)
                            {
                                obj.SpecializationText = "Masters of Business Administration";
                            }
                            if (valSpecialization == 6)
                            {
                                obj.SpecializationText = "Bachelor of Arts";
                            }
                            if (valSpecialization == 7)
                            {
                                obj.SpecializationText = "Bachelor of Commerce";
                            }
                            if (valSpecialization == 8)
                            {
                                obj.SpecializationText = "Masters of Commerce";
                            }
                            if (valSpecialization == 9)
                            {
                                obj.SpecializationText = "HSC";
                            }
                            if (valSpecialization == 10)
                            {
                                obj.SpecializationText = "SSC";
                            }

                            obj.PassingYear = Convert.ToDateTime(reader["PassingYear"].ToString());
                            obj.PassingYearFormat = Convert.ToString(obj.PassingYear.Date.ToString("yyyy/MM/dd"));
                            obj.Institute = reader["Institute"].ToString();
                            obj.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            obj.StartDateFormat = Convert.ToString(obj.StartDate.Date.ToString("yyyy/MM/dd"));
                            obj.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            obj.EndDateFormat = Convert.ToString(obj.EndDate.Date.ToString("yyyy/MM/dd"));

                            obj.Percentage = reader["Percentage"].ToString();

                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            //Convert.ToString(obj.PassingYear.Date.ToString("yyyy/MM/dd"));

                            //----------------------------------
                            CT_EmployeeEducation_List.Add(obj);
                        }

                        return CT_EmployeeEducation_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //------END---------------------------------------------------

        //-----------START CODE Experience-------------------------------------------

        public string FnAddEmployeeExperience(CT_EmployeeExperience Obj_Emp_Exp)
        {
            string returntype = "";

            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddEmployeeExperience", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Exp_PKID", Obj_Emp_Exp.Exp_PKID);
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", Obj_Emp_Exp.LastEmployeePKID);
                        cmd.Parameters.AddWithValue("@Organization", Obj_Emp_Exp.Organization);
                        cmd.Parameters.AddWithValue("@ExperienceDesignation", Obj_Emp_Exp.ExperienceDesignation);
                        cmd.Parameters.AddWithValue("@StartDate", Obj_Emp_Exp.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", Obj_Emp_Exp.EndDate);
                        cmd.Parameters.AddWithValue("@StartSalary", Obj_Emp_Exp.StartSalary);
                        cmd.Parameters.AddWithValue("@EndSalary", Obj_Emp_Exp.EndSalary);
                        cmd.Parameters.AddWithValue("@Reason", Obj_Emp_Exp.Reason);


                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_Emp_Exp.CreatedBy);


                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //-----------END CODE Experience-------------------------------------------



        //------------------------------------------------------------
        public List<CT_EmployeeEducation> FnGetEmployeesEducation(int LastEmployeePKID)
        {
            List<CT_EmployeeEducation> CT_EmployeeEducation_list = new List<CT_EmployeeEducation>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeEducation", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeEducation obj = new CT_EmployeeEducation();
                            obj.Edu_PKID = Convert.ToInt32(reader["Edu_PKID"].ToString());
                            obj.Employee_PKID = Convert.ToInt32(reader["Employee_PKID"].ToString());
                            obj.Degree = reader["Degree"].ToString();
                            obj.Specialization = reader["Specialization"].ToString();

                            obj.PassingYear = Convert.ToDateTime(reader["PassingYear"].ToString());
                            obj.PassingYearFormat = Convert.ToString(obj.PassingYear.Date.ToString("yyyy/MM/dd"));
                            obj.Institute = reader["Institute"].ToString();
                            obj.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            obj.StartDateFormat = Convert.ToString(obj.StartDate.Date.ToString("yyyy/MM/dd"));

                            obj.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            obj.EndDateFormat = Convert.ToString(obj.EndDate.Date.ToString("yyyy/MM/dd"));
                            obj.Percentage = reader["Percentage"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();

                            //----------------------------------
                            if (obj.Degree == "1")
                            {
                                obj.DegreeText = "Bachelor of Engineering";
                            }
                            if (obj.Degree == "2")
                            {
                                obj.DegreeText = "Masters of Engineering";
                            }
                            if (obj.Degree == "3")
                            {
                                obj.DegreeText = "Master of Computer Applications";
                            }
                            if (obj.Degree == "4")
                            {
                                obj.DegreeText = "Bachelors of Business Administration";
                            }
                            if (obj.Degree == "5")
                            {
                                obj.DegreeText = "Masters of Business Administration";
                            }
                            if (obj.Degree == "6")
                            {
                                obj.DegreeText = "Bachelor of Arts";
                            }
                            if (obj.Degree == "7")
                            {
                                obj.DegreeText = "Bachelor of Commerce";
                            }
                            if (obj.Degree == "8")
                            {
                                obj.DegreeText = "Masters of Commerce";
                            }
                            if (obj.Degree == "9")
                            {
                                obj.DegreeText = "HSC";
                            }
                            if (obj.Degree == "10")
                            {
                                obj.DegreeText = "SSC";
                            }


                            //------Specilization-------------

                            if (obj.Specialization == "1")
                            {
                                obj.SpecializationText = "Bachelor of Engineering";
                            }
                            if (obj.Specialization == "2")
                            {
                                obj.SpecializationText = "Masters of Engineering";
                            }
                            if (obj.Specialization == "3")
                            {
                                obj.SpecializationText = "Master of Computer Applications";
                            }
                            if (obj.Specialization == "4")
                            {
                                obj.SpecializationText = "Bachelors of Business Administration";
                            }
                            if (obj.Specialization == "5")
                            {
                                obj.SpecializationText = " Masters of Business Administration";
                            }
                            if (obj.Specialization == "6")
                            {
                                obj.SpecializationText = "Bachelor of Arts";
                            }
                            if (obj.Specialization == "7")
                            {
                                obj.SpecializationText = "Bachelor of Commerce";
                            }
                            if (obj.Specialization == "8")
                            {
                                obj.SpecializationText = "Masters of Commerce";
                            }
                            if (obj.Specialization == "9")
                            {
                                obj.SpecializationText = "HSC";
                            }
                            if (obj.Specialization == "10")
                            {
                                obj.SpecializationText = "SSC";
                            }

                            //----------------------------------

                            CT_EmployeeEducation_list.Add(obj);
                        }

                        return CT_EmployeeEducation_list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public CT_EmployeeEducation FnGetEmployeesEducationById(int? Edu_PKID)
        {
            CT_EmployeeEducation CT_EmployeeEducation_Obj = new CT_EmployeeEducation();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeEducationById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Edu_PKID", Edu_PKID);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        CT_EmployeeEducation obj = new CT_EmployeeEducation();
                        while (reader.Read())
                        {

                            obj.Edu_PKID = Convert.ToInt32(reader["Edu_PKID"].ToString());
                            obj.Employee_PKID = Convert.ToInt32(reader["Employee_PKID"].ToString());
                            obj.Degree = reader["Degree"].ToString();
                            obj.Specialization = reader["Specialization"].ToString();

                            obj.PassingYear = Convert.ToDateTime(reader["PassingYear"].ToString());
                            obj.PassingYearFormat = Convert.ToString(obj.PassingYear.Date.ToString("dd/M/yyyy"));
                            obj.Institute = reader["Institute"].ToString();
                            obj.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            obj.StartDateFormat = Convert.ToString(obj.StartDate.Date.ToString("dd/M/yyyy"));

                            obj.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            obj.EndDateFormat = Convert.ToString(obj.EndDate.Date.ToString("dd/M/yyyy"));
                            obj.Percentage = reader["Percentage"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();


                            // CT_EmployeeEducation_list.Add(obj);

                        }
                        return obj;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //-----------------------------------------------------------


        public List<CT_CreateEmployee> FnSearchEmployee(string searchEmployee)
        {
            List<CT_CreateEmployee> CT_CreateEmployee_list = new List<CT_CreateEmployee>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_SearchEmployee", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@searchEmployee", searchEmployee);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_CreateEmployee obj = new CT_CreateEmployee();
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.ProfilePictureName = reader["ProfilePictureName"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.MiddleName = reader["MiddleName"].ToString();

                            obj.LastName = reader["LastName"].ToString();
                            obj.Phone = reader["Phone"].ToString();
                            obj.PersonalEmail = reader["PersonalEmail"].ToString();
                            obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                            obj.Gender = reader["Gender"].ToString();
                            obj.MaritalStatus = reader["MaritalStatus"].ToString();
                            obj.Description = reader["Description"].ToString();
                            obj.EmployeeEnrollmentID = reader["EmployeeEnrollmentID"].ToString();
                            obj.DateofJoining = Convert.ToDateTime(reader["DateofJoining"].ToString());
                            obj.CompanyEmail = reader["CompanyEmail"].ToString();
                            obj.Department = reader["Department"].ToString();
                            obj.Designation = reader["Designation"].ToString();
                            obj.ReportingEmployee = reader["ReportingEmployee"].ToString();
                            obj.TypeofEmployee = reader["TypeofEmployee"].ToString();
                            obj.AddressLine1 = reader["AddressLine1"].ToString();
                            obj.AddressLine2 = reader["AddressLine2"].ToString();
                            obj.City = reader["City"].ToString();

                            obj.State = reader["State"].ToString();
                            obj.ZipCode = reader["ZipCode"].ToString();
                            obj.Country = reader["Country"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();
                            obj.Password = reader["Password"].ToString();

                            obj.EducationStatus = reader["EducationStatus"].ToString();
                            obj.ExperienceStatus = reader["ExperienceStatus"].ToString();
                            obj.DocumentsStatus = reader["DocumentsStatus"].ToString();
                            obj.SalaryStatus = reader["SalaryStatus"].ToString();

                            CT_CreateEmployee_list.Add(obj);
                        }

                        return CT_CreateEmployee_list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //-------START----Employee Experience----------------------------------------
        public List<CT_EmployeeExperience> FnGetEmployeesExperience(int LastEmployeePKID)
        {
            List<CT_EmployeeExperience> CT_EmployeeExperience_List = new List<CT_EmployeeExperience>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeExperience", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeExperience obj = new CT_EmployeeExperience();
                            obj.Exp_PKID = Convert.ToInt32(reader["Exp_PKID"].ToString());
                            obj.LastEmployeePKID = Convert.ToInt32(reader["Employee_PKID"].ToString());

                            obj.Organization =reader["Organization"].ToString();
                            obj.ExperienceDesignation = reader["Designation"].ToString();
                            obj.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            obj.StartDateFormat = Convert.ToString(obj.StartDate.Date.ToString("yyyy/MM/dd"));

                            obj.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            obj.EndDateFormat = Convert.ToString(obj.EndDate.Date.ToString("yyyy/MM/dd"));
                            obj.StartSalary = reader["StartSalary"].ToString();
                            obj.EndSalary = reader["EndSalary"].ToString();
                            obj.Reason = reader["Reason"].ToString();

                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            //Convert.ToString(obj.PassingYear.Date.ToString("yyyy/MM/dd"));

                            //----------------------------------



                            CT_EmployeeExperience_List.Add(obj);
                        }

                        return CT_EmployeeExperience_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string DeleteEmployeeExperienceById(int EmployeePKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("DeleteEmployeeExperienceById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();

                    }

                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string DeleteEmployeeEducationById(int EmployeePKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("DeleteEmployeeEducationById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();

                    }

                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string FnAddEmployeeDocumetns(CT_EmployeeDocuments Obj_Emp_Doc)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddEmployeeDocuments", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Doc_PKID", Obj_Emp_Doc.Doc_PKID);
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", Obj_Emp_Doc.Employee_PKID);
                        cmd.Parameters.AddWithValue("@DocumentName", Obj_Emp_Doc.DocumentName);
                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_Emp_Doc.CreatedBy);

                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public List<CT_EmployeeDocuments> GetEmployeeDocumetnsData(int LastEmployeePKID)
        {
            List<CT_EmployeeDocuments> CT_EmployeeDocuments_List = new List<CT_EmployeeDocuments>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeDocumetnsData", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeDocuments obj = new CT_EmployeeDocuments();
                            obj.Doc_PKID = Convert.ToInt32(reader["Doc_PKID"].ToString());
                            obj.Employee_PKID = Convert.ToInt32(reader["Employee_PKID"].ToString());
                            obj.DocumentName = reader["DocumentName"].ToString();
                            CT_EmployeeDocuments_List.Add(obj);
                        }
                        return CT_EmployeeDocuments_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string FnDeleteEmployeeDocumetnsById(int Doc_PKIDEmployee)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("SpDeleteEmployeeEducationById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Doc_PKIDEmployee", Doc_PKIDEmployee);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();

                    }

                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CT_EmployeeSalary> GetEmployeeSalaryData(int LastEmployeePKID)
        {
            List<CT_EmployeeSalary> CT_EmployeeSalary_List = new List<CT_EmployeeSalary>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeSalaryData", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeSalary obj = new CT_EmployeeSalary();
                            obj.Sal_PKID = Convert.ToInt32(reader["Sal_PKID"].ToString());
                            obj.Employee_PKID = Convert.ToInt32(reader["Employee_PKID"].ToString());
                            obj.BasicSalary = reader["BasicSalary"].ToString();
                            obj.HouseRentAllowences = reader["HouseRentAllowences"].ToString();
                            obj.ConveyanceAllowences =reader["ConveyanceAllowences"].ToString();
                            obj.MedicalAllowences = reader["MedicalAllowences"].ToString();
                            obj.SpecialAllowences = reader["SpecialAllowences"].ToString(); 
                            obj.GrossSalary =reader["GrossSalary"].ToString();
                            obj.EPF = reader["EPF"].ToString();
                            obj.HealthInsurance_ESI = reader["HealthInsuranceESI"].ToString();
                            obj.NetPay =reader["NetPay"].ToString();

                            CT_EmployeeSalary_List.Add(obj);
                        }
                        return CT_EmployeeSalary_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string FnAddEmployeeSalary(CT_EmployeeSalary Obj_Emp_Sal)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_AddEmployeeSalary", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sal_PKID", Obj_Emp_Sal.Sal_PKID);
                        cmd.Parameters.AddWithValue("@Employee_PKID", Obj_Emp_Sal.Employee_PKID);
                        cmd.Parameters.AddWithValue("@BasicSalary", Obj_Emp_Sal.BasicSalary);
                        cmd.Parameters.AddWithValue("@HouseRentAllowences", Obj_Emp_Sal.HouseRentAllowences);
                        cmd.Parameters.AddWithValue("@ConveyanceAllowences", Obj_Emp_Sal.ConveyanceAllowences);
                        cmd.Parameters.AddWithValue("@MedicalAllowences", Obj_Emp_Sal.MedicalAllowences);
                        cmd.Parameters.AddWithValue("@SpecialAllowences", Obj_Emp_Sal.SpecialAllowences);
                        cmd.Parameters.AddWithValue("@GrossSalary", Obj_Emp_Sal.GrossSalary);
                        cmd.Parameters.AddWithValue("@EPF", Obj_Emp_Sal.EPF);
                        cmd.Parameters.AddWithValue("@HealthInsurance_ESI ", Obj_Emp_Sal.HealthInsurance_ESI);
                        cmd.Parameters.AddWithValue("@NetPay ", Obj_Emp_Sal.NetPay);
                        //--------------------------------------------------------------------------
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_Emp_Sal.CreatedBy);

                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();
                    }
                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string FnDeleteEmployeeSalaryById(int Doc_PKIDEmployee)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("SpDeleteEmployeeSalaryById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Sal_EmployeePKID", Doc_PKIDEmployee);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        con.Close();

                    }

                }
                return returntype;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<CT_CreateEmployee> FnForfecth_EmployeeReportee
        {
            get
            {
                List<CT_CreateEmployee> ObjCreateEmployeeModelList = new List<CT_CreateEmployee>();

                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spFetchEmployeeReportee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CT_CreateEmployee Obj_CreateEmployee = new CT_CreateEmployee();

                        Obj_CreateEmployee.EmployeePKID = Convert.ToInt32(rdr["EmployeePKID"].ToString());
                        Obj_CreateEmployee.FirstName = rdr["ReporteeName"].ToString();
                        ObjCreateEmployeeModelList.Add(Obj_CreateEmployee);
                    }
                    con.Close();
                }

                return ObjCreateEmployeeModelList;
            }
        }

    }
}