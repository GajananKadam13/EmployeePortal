using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_ApproveRejectLeavesHR : DL_Base
    {
        public List<CT_Leave> GetEmployeeApplyLeaveApproveRejectHR(int EmployeePKID)
        {
            List<CT_Leave> CT_Leave_List = new List<CT_Leave>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("GetEmployeeApplyLeaveApproveRejectHR", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_Leave obj = new CT_Leave();
                            obj.EmployeeName = reader["EmployeeName"].ToString();
                            obj.LeavePKID = Convert.ToInt32(reader["LeavePKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());

                            if (reader["LeaveType"].ToString() == "1")
                            {
                                obj.Leavetype = "Loss Of Pay";
                            }
                            if (reader["LeaveType"].ToString() == "2")
                            {
                                obj.Leavetype = "Casual Leave";
                            }
                            if (reader["LeaveType"].ToString() == "3")
                            {
                                obj.Leavetype = "Comp - Off";
                            }
                            if (reader["LeaveType"].ToString() == "4")
                            {
                                obj.Leavetype = "Sick Leave";
                            }
                            if (reader["LeaveType"].ToString() == "5")
                            {
                                obj.Leavetype = "Recreational Leave";
                            }
                            obj.Fromdate = Convert.ToDateTime(reader["FromDate"].ToString());
                            obj.FromdateFormat = Convert.ToString(obj.Fromdate.Date.ToString("yyyy/MM/dd"));
                            obj.Todate = Convert.ToDateTime(reader["ToDate"].ToString());
                            obj.TodateFormat = Convert.ToString(obj.Todate.Date.ToString("yyyy/MM/dd"));
                            obj.ContactDetails = reader["ContactDetails"].ToString();
                            obj.Reason = reader["Reason"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));

                            obj.ManagerApproveRejectStatus = reader["ManagerApproveRejectStatus"].ToString();
                            obj.ManagerApproveRejectComment = reader["ManagerApproveRejectComment"].ToString();
                            obj.HRApproveRejectStatus = reader["HRApproveRejectStatus"].ToString();
                            obj.HRApproveRejectComment = reader["HRApproveRejectComment"].ToString();
                            CT_Leave_List.Add(obj);
                        }
                        return CT_Leave_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<CT_Leave> GetEmployeeParticularLeavesHR(int LeavePKID)
        {
            List<CT_Leave> CT_Leave_List = new List<CT_Leave>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("GetEmployeeParticularLeavesHR", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LeavePKID", LeavePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_Leave obj = new CT_Leave();
                            obj.LeavePKID = Convert.ToInt32(reader["LeavePKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());

                            if (reader["LeaveType"].ToString() == "1")
                            {
                                obj.Leavetype = "Loss Of Pay";
                            }
                            if (reader["LeaveType"].ToString() == "2")
                            {
                                obj.Leavetype = "Casual Leave";
                            }
                            if (reader["LeaveType"].ToString() == "3")
                            {
                                obj.Leavetype = "Comp - Off";
                            }
                            if (reader["LeaveType"].ToString() == "4")
                            {
                                obj.Leavetype = "Sick Leave";
                            }
                            if (reader["LeaveType"].ToString() == "5")
                            {
                                obj.Leavetype = "Recreational Leave";
                            }
                            obj.Fromdate = Convert.ToDateTime(reader["FromDate"].ToString());
                            obj.FromdateFormat = Convert.ToString(obj.Fromdate.Date.ToString("yyyy/MM/dd"));
                            obj.Todate = Convert.ToDateTime(reader["ToDate"].ToString());
                            obj.TodateFormat = Convert.ToString(obj.Todate.Date.ToString("yyyy/MM/dd"));
                            obj.ContactDetails = reader["ContactDetails"].ToString();
                            obj.Reason = reader["Reason"].ToString();
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));

                            obj.ManagerApproveRejectStatus = reader["ManagerApproveRejectStatus"].ToString();
                            obj.ManagerApproveRejectComment = reader["ManagerApproveRejectComment"].ToString();
                            obj.HRApproveRejectStatus = reader["HRApproveRejectStatus"].ToString();
                            obj.HRApproveRejectComment = reader["HRApproveRejectComment"].ToString();
                            CT_Leave_List.Add(obj);
                        }
                        return CT_Leave_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ApproveRejectLeavesByHR(string Comment, string ddlApproveReject, int hdn_LeavePKID)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_ApproveRejectLeavesByHR", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LeavePKID", hdn_LeavePKID);
                        cmd.Parameters.AddWithValue("@ddlApproveReject", ddlApproveReject);
                        cmd.Parameters.AddWithValue("@Comment", Comment);
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