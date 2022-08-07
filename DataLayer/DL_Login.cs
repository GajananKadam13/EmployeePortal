using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_Login : DL_Base
    {
        //public string FnCheckLogin(CT_Login obj_CT_Log)
        //{
        //    string returntype = "";
        //    using (con)
        //    {
        //        using (cmd = new System.Data.SqlClient.SqlCommand("sp_CheckLogin", con))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@userid", obj_CT_Log.UserName);
        //            cmd.Parameters.AddWithValue("@password", obj_CT_Log.Password);
        //            cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
        //            cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
        //            con.Open();
        //            Convert.ToString(cmd.ExecuteNonQuery());
        //            returntype = (string)cmd.Parameters["@msg"].Value;
        //            con.Close();


        //        }
        //    }

        //    return returntype;

        //}



        public DataTable FnCheckLogin(CT_Login obj_CT_Log)
        {
            DataTable dt = new DataTable();
            try
            {

                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_CheckLogin", con))
                    {
                        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@userid", obj_CT_Log.UserName);
                        //cmd.Parameters.AddWithValue("@password", obj_CT_Log.Password);
                        //cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        //cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                        //con.Open();
                        //Convert.ToString(cmd.ExecuteNonQuery());
                        //returntype = (string)cmd.Parameters["@msg"].Value;
                        //con.Close();

                       
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.Parameters.AddWithValue("@CompanyEmail", obj_CT_Log.UserName);
                        cmd.Parameters.AddWithValue("@Password", obj_CT_Log.Password);
                        adr = new SqlDataAdapter(cmd);
                        adr.Fill(dt);
                        return dt;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<CT_ResetPassword> FnGetEmployeesForResetPassword()
        {
            List<CT_ResetPassword> CT_ResetPassword_list = new List<CT_ResetPassword>();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeForResetPassword", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_ResetPassword obj = new CT_ResetPassword();
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.CompanyEmail = reader["CompanyEmail"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.LastName = reader["LastName"].ToString();
                            obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                            obj.DateOfBirthFormat = Convert.ToString(obj.DateOfBirth.Date.ToString("yyyy/MM/dd"));
                            obj.Gender = reader["Gender"].ToString();
                            obj.Password = reader["Password"].ToString();
                            CT_ResetPassword_list.Add(obj);
                        }

                        return CT_ResetPassword_list;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CT_ResetPassword> FnSearchEmployee_ForResetPassword(string searchEmployee)
        {
            List<CT_ResetPassword> CT_ResetPassword_list = new List<CT_ResetPassword>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_SearchEmployee_ForResetPassword", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@searchEmployee", searchEmployee);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_ResetPassword obj = new CT_ResetPassword();
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.CompanyEmail = reader["CompanyEmail"].ToString();
                            obj.FirstName = reader["FirstName"].ToString();
                            obj.LastName = reader["LastName"].ToString();
                            obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                            obj.DateOfBirthFormat = Convert.ToString(obj.DateOfBirth.Date.ToString("yyyy/MM/dd"));
                            obj.Gender = reader["LastName"].ToString();
                            obj.Password = reader["Password"].ToString();
                            CT_ResetPassword_list.Add(obj);
                        }

                        return CT_ResetPassword_list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string FnEmployeesResetPassword(int EmployeePKID)
        {
            string returntype = "";
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_EmployeesResetPassword", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                      
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 40);
                        cmd.Parameters["@msg"].Direction = ParameterDirection.Output;

                        oSQLConn.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@msg"].Value;
                        oSQLConn.Close();
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