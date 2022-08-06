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
                        
                        if(cmd.Parameters["@CheckOut"].Value !=DBNull.Value)
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


    }
}