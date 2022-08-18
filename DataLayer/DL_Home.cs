using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EmployeePortal.Models;
namespace EmployeePortal.DataLayer
{
    public class DL_Home : DL_Base
    {
        public string FnCreateEmployee(int EmployeePKID, string CheckInOutStatus)
        {
            string returntype = "";

            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_Attendance_In_Out", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        cmd.Parameters.AddWithValue("@CheckInOutStatus", CheckInOutStatus);


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

        public string FnEmployeeCheckInOut(int EmployeePKID)
        {
            string returntype = "";

            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_CheckInOut", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);

                        cmd.Parameters.Add("@CheckIn", SqlDbType.VarChar, 40);
                        cmd.Parameters["@CheckIn"].Direction = ParameterDirection.Output;

                        cmd.Parameters.Add("@CheckOut", SqlDbType.VarChar, 40);
                        cmd.Parameters["@CheckOut"].Direction = ParameterDirection.Output;


                        con.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());
                        returntype = (string)cmd.Parameters["@CheckIn"].Value;
                        returntype += '_';
                        returntype += (string)cmd.Parameters["@CheckOut"].Value;

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

        public string FnGetEmployeeCheckInTime(int EmployeePKID)
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
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeCheckInTime", oSQLConn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);


                        cmd.Parameters.Add("@CheckOut", SqlDbType.VarChar, 40);
                        cmd.Parameters["@CheckOut"].Direction = ParameterDirection.Output;


                        oSQLConn.Open();
                        Convert.ToString(cmd.ExecuteNonQuery());

                        if (cmd.Parameters["@CheckOut"].Value != DBNull.Value)
                        {
                            returntype = (string)cmd.Parameters["@CheckOut"].Value;
                        }
                        else
                        {
                            returntype = "NOT Checked In";
                        }

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





        public List<CT_EmployeeAttendance> FnGetEmployeeAttendanceWholeMonth(int EmployeePKID)
        {
            List<CT_EmployeeAttendance> CT_EmployeeAttendance_list = new List<CT_EmployeeAttendance>();
            try
            {
                var oSQLConn = new
            SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString());
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetAttendanceWholeMonth", oSQLConn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_EmployeeAttendance obj = new CT_EmployeeAttendance();
                            obj.Att_PKID = Convert.ToInt32(reader["Att_PKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.LogInTime = reader["LogInTime"].ToString();
                            obj.Weekday = reader["Weekday"].ToString();
                            obj.LogoutTime = reader["LogoutTime"].ToString();
                            obj.Month = reader["Month"].ToString();


                            CT_EmployeeAttendance_list.Add(obj);
                        }
                        return CT_EmployeeAttendance_list;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CT_PostNewJobs> Get_HR_PostedNewJobs(int EmployeePKID)
        {
            List<CT_PostNewJobs> CT_PostNewJobs_list = new List<CT_PostNewJobs>();
            try
            {
                var oSQLConn = new
            SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString());
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("Get_HR_PostedNewJobs", oSQLConn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_PostNewJobs obj = new CT_PostNewJobs();
                            obj.PoJob_PKID = Convert.ToInt32(reader["PoJob_PKID"].ToString());
                            obj.DepartmenName =reader["DepartmenName"].ToString();
                            obj.Designation = reader["Designation"].ToString();
                            obj.Experience  = reader["Experience"].ToString();
                            obj.Description = reader["Description"].ToString();
                            obj.Note = reader["Note"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));
                            obj.ResumeStatus = reader["ResumeStatus"].ToString();
                            CT_PostNewJobs_list.Add(obj);
                        }
                        return CT_PostNewJobs_list;
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public string UploadReferenceResume(int EmployeePKID,string ResumeFileName,int hdn_Job_PKID)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_UploadReferenceResume", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        cmd.Parameters.AddWithValue("@ReferenceResumeName", ResumeFileName);
                        cmd.Parameters.AddWithValue("@Job_PKID", hdn_Job_PKID);
                        //-----------------------------------------------------------------------------
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