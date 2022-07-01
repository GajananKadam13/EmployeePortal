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
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_RegisterEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpPkid", obj_CT_Log.EMP_PK_ID);
                        cmd.Parameters.AddWithValue("@FirstName", obj_CT_Log.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", obj_CT_Log.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", obj_CT_Log.LastName);
                        cmd.Parameters.AddWithValue("@Gender", obj_CT_Log.Gender);
                        cmd.Parameters.AddWithValue("@DOB", obj_CT_Log.DOB);
                        cmd.Parameters.AddWithValue("@Nationality", obj_CT_Log.Nationality);
                        cmd.Parameters.AddWithValue("@EmailId", obj_CT_Log.Email);
                        cmd.Parameters.AddWithValue("@Landline", obj_CT_Log.Landline);
                        cmd.Parameters.AddWithValue("@Mobile", obj_CT_Log.Mobile); 
                        cmd.Parameters.AddWithValue("@Country", obj_CT_Log.Country);
                        cmd.Parameters.AddWithValue("@City", obj_CT_Log.City);
                        cmd.Parameters.AddWithValue("@State", obj_CT_Log.State);
                        cmd.Parameters.AddWithValue("@Address", obj_CT_Log.Address); 
                        cmd.Parameters.AddWithValue("@Role", obj_CT_Log.Role);
                        cmd.Parameters.AddWithValue("@UserName", obj_CT_Log.UserName);
                        cmd.Parameters.AddWithValue("@Password", obj_CT_Log.Password);
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

        public  List<CT_CreateEmployee>  FnGetEmployees()
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
                            obj.EMP_PK_ID = Convert.ToInt32(reader["EMP_PK_ID"].ToString());
                            obj.UserName = reader["UserName"].ToString();
                            obj.Password = reader["Password"].ToString();
                            obj.Email = reader["EmailId"].ToString();
                        
                            obj.CreatedBy = reader["CreatedBy"].ToString();
                            obj.CreationDate = reader["CreationDate"].ToString();
                            obj.ModifiedBy = reader["ModifiedBy"].ToString();
                            obj.ModifiedDate = reader["ModifiedDate"].ToString();
                            obj.Status = reader["Status"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.MiddleName = reader["MiddleName"].ToString();
                            obj.LastName = reader["LastName"].ToString();
                            obj.DOB=Convert.ToDateTime(reader["DOB"].ToString());
                            obj.Gender = reader["Gender"].ToString();
                            obj.Nationality = reader["Nationality"].ToString();
                            obj.Landline = reader["Landline"].ToString();
                            obj.Mobile = reader["Mobile"].ToString();
                            obj.Country = reader["Country"].ToString();
                            obj.City = reader["City"].ToString();
                            obj.State = reader["State"].ToString();
                            obj.Address = reader["Address"].ToString();
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
                        cmd.Parameters.AddWithValue("@EMP_PKID", EmployeePKID);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //CT_CreateEmployee obj = new CT_CreateEmployee();
                            obj.EMP_PK_ID = Convert.ToInt32(reader["EMP_PK_ID"].ToString());
                            obj.UserName = reader["UserName"].ToString();
                            obj.Password = reader["Password"].ToString();
                            obj.Email = reader["EmailId"].ToString();

                            obj.CreatedBy = reader["CreatedBy"].ToString();
                            obj.CreationDate = reader["CreationDate"].ToString();
                            obj.ModifiedBy = reader["ModifiedBy"].ToString();
                            obj.ModifiedDate = reader["ModifiedDate"].ToString();
                            obj.Status = reader["Status"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.MiddleName = reader["MiddleName"].ToString();
                            obj.LastName = reader["LastName"].ToString();
                            obj.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                            obj.Gender = reader["Gender"].ToString();
                            obj.Nationality = reader["Nationality"].ToString();
                            obj.Landline = reader["Landline"].ToString();
                            obj.Mobile = reader["Mobile"].ToString();
                            obj.Country = reader["Country"].ToString();
                            obj.City = reader["City"].ToString();
                            obj.State = reader["State"].ToString();
                            obj.Address = reader["Address"].ToString();
                            obj.Role =Convert.ToInt32(reader["Role"].ToString());
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
                        cmd.Parameters.AddWithValue("@EMP_PKID", EmployeePKID);
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
    }
}