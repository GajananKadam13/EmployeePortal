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
    public class DL_CreateEmployee :DL_Base
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
                            obj.CreatedBy =Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();
                            obj.Password = reader["Password"].ToString();


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
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeEducation", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LastEmployeePKID", LastEmployeePKID);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeEducation obj = new CT_EmployeeEducation();
                            obj.Edu_PKID = Convert.ToInt32(reader["Edu_PKID"].ToString());
                            obj.Employee_PKID = Convert.ToInt32(reader["Employee_PKID"].ToString());
                            obj.Degree = reader["Degree"].ToString();
                            obj.Specialization = reader["Specialization"].ToString();

                            obj.PassingYear = Convert.ToDateTime(reader["PassingYear"].ToString());
                            obj.Institute = reader["Institute"].ToString();
                            obj.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                            obj.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            obj.Percentage = reader["Percentage"].ToString();
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.Status = reader["Status"].ToString();


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

        //-----------------------------------------------------------





        //public string FnCreateEmployee(CT_CreateEmployee obj_CT_Log)
        //{
        //    string returntype = "";
        //    try
        //    {
        //        using (con)
        //        {
        //            using (cmd = new System.Data.SqlClient.SqlCommand("sp_RegisterEmployee", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@EmpPkid", obj_CT_Log.EMP_PK_ID);
        //                cmd.Parameters.AddWithValue("@FirstName", obj_CT_Log.FirstName);
        //                cmd.Parameters.AddWithValue("@MiddleName", obj_CT_Log.MiddleName);
        //                cmd.Parameters.AddWithValue("@LastName", obj_CT_Log.LastName);
        //                cmd.Parameters.AddWithValue("@Gender", obj_CT_Log.Gender);
        //                cmd.Parameters.AddWithValue("@DOB", obj_CT_Log.DOB);
        //                cmd.Parameters.AddWithValue("@Nationality", obj_CT_Log.Nationality);
        //                cmd.Parameters.AddWithValue("@EmailId", obj_CT_Log.Email);
        //                cmd.Parameters.AddWithValue("@Landline", obj_CT_Log.Landline);
        //                cmd.Parameters.AddWithValue("@Mobile", obj_CT_Log.Mobile); 
        //                cmd.Parameters.AddWithValue("@Country", obj_CT_Log.Country);
        //                cmd.Parameters.AddWithValue("@City", obj_CT_Log.City);
        //                cmd.Parameters.AddWithValue("@State", obj_CT_Log.State);
        //                cmd.Parameters.AddWithValue("@Address", obj_CT_Log.Address); 
        //                cmd.Parameters.AddWithValue("@Role", obj_CT_Log.Role);
        //                cmd.Parameters.AddWithValue("@UserName", obj_CT_Log.UserName);
        //                cmd.Parameters.AddWithValue("@Password", obj_CT_Log.Password);
        //                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
        //                cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
        //                con.Open();
        //                Convert.ToString(cmd.ExecuteNonQuery());
        //                returntype = (string)cmd.Parameters["@msg"].Value;
        //                con.Close();

        //            }
        //        }
        //        return returntype;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public  List<CT_CreateEmployee>  FnGetEmployees()
        //{
        //    List<CT_CreateEmployee> CT_CreateEmployee_list = new List<CT_CreateEmployee>();
        //    try
        //    {
        //        using (con)
        //        {
        //            using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployee", con))
        //            {

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                con.Open();
        //                reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    CT_CreateEmployee obj = new CT_CreateEmployee();
        //                    obj.EMP_PK_ID = Convert.ToInt32(reader["EMP_PK_ID"].ToString());
        //                    obj.UserName = reader["UserName"].ToString();
        //                    obj.Password = reader["Password"].ToString();
        //                    obj.Email = reader["EmailId"].ToString();

        //                    obj.CreatedBy = reader["CreatedBy"].ToString();
        //                    obj.CreationDate = reader["CreationDate"].ToString();
        //                    obj.ModifiedBy = reader["ModifiedBy"].ToString();
        //                    obj.ModifiedDate = reader["ModifiedDate"].ToString();
        //                    obj.Status = reader["Status"].ToString();
        //                    obj.FirstName = reader["FirstName"].ToString();
        //                    obj.MiddleName = reader["MiddleName"].ToString();
        //                    obj.LastName = reader["LastName"].ToString();
        //                    obj.DOB=Convert.ToDateTime(reader["DOB"].ToString());
        //                    obj.Gender = reader["Gender"].ToString();
        //                    obj.Nationality = reader["Nationality"].ToString();
        //                    obj.Landline = reader["Landline"].ToString();
        //                    obj.Mobile = reader["Mobile"].ToString();
        //                    obj.Country = reader["Country"].ToString();
        //                    obj.City = reader["City"].ToString();
        //                    obj.State = reader["State"].ToString();
        //                    obj.Address = reader["Address"].ToString();
        //                    CT_CreateEmployee_list.Add(obj);
        //                }

        //                return CT_CreateEmployee_list;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public CT_CreateEmployee FnGetEmployeesById(int EmployeePKID)
        //{
        //    CT_CreateEmployee obj = new CT_CreateEmployee();
        //    try
        //    {
        //        using (con)
        //        {
        //            using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeById", con))
        //            {

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@EMP_PKID", EmployeePKID);
        //                con.Open();
        //                reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    //CT_CreateEmployee obj = new CT_CreateEmployee();
        //                    obj.EMP_PK_ID = Convert.ToInt32(reader["EMP_PK_ID"].ToString());
        //                    obj.UserName = reader["UserName"].ToString();
        //                    obj.Password = reader["Password"].ToString();
        //                    obj.Email = reader["EmailId"].ToString();

        //                    obj.CreatedBy = reader["CreatedBy"].ToString();
        //                    obj.CreationDate = reader["CreationDate"].ToString();
        //                    obj.ModifiedBy = reader["ModifiedBy"].ToString();
        //                    obj.ModifiedDate = reader["ModifiedDate"].ToString();
        //                    obj.Status = reader["Status"].ToString();
        //                    obj.FirstName = reader["FirstName"].ToString();
        //                    obj.MiddleName = reader["MiddleName"].ToString();
        //                    obj.LastName = reader["LastName"].ToString();
        //                    obj.DOB = Convert.ToDateTime(reader["DOB"].ToString());
        //                    obj.Gender = reader["Gender"].ToString();
        //                    obj.Nationality = reader["Nationality"].ToString();
        //                    obj.Landline = reader["Landline"].ToString();
        //                    obj.Mobile = reader["Mobile"].ToString();
        //                    obj.Country = reader["Country"].ToString();
        //                    obj.City = reader["City"].ToString();
        //                    obj.State = reader["State"].ToString();
        //                    obj.Address = reader["Address"].ToString();
        //                    obj.Role =Convert.ToInt32(reader["Role"].ToString());
        //                }
        //                return obj;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

    }
}