using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_Leave : DL_Base
    {
        public List<CT_AddBalanceLeave> GetAllEmployeeBalanceLeave()
        {
            List<CT_AddBalanceLeave> CT_AddBalanceLeave_List = new List<CT_AddBalanceLeave>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetAllEmployeeBalanceLeave", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_AddBalanceLeave obj = new CT_AddBalanceLeave();
                            obj.BalLeavePKID = Convert.ToInt32(reader["BalLeavePKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.EmployeeName = reader["EmployeeName"].ToString();
                            obj.LossOfPay = Convert.ToInt32(reader["LossOfPay"].ToString());
                            obj.CasualLeave = Convert.ToInt32(reader["CasualLeave"].ToString());
                            obj.CompOff = Convert.ToInt32(reader["CompOff"].ToString());
                            obj.SickLeave = Convert.ToInt32(reader["SickLeave"].ToString());
                            obj.RecreationalLeave = Convert.ToInt32(reader["RecreationalLeave"].ToString());
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));
                            CT_AddBalanceLeave_List.Add(obj);
                        }
                        return CT_AddBalanceLeave_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string FnEmployeeBalanceLeave(CT_AddBalanceLeave Obj_Emp_BalLeave)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_EmployeeBalanceLeaveByHR", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BalLeavePKID", Obj_Emp_BalLeave.BalLeavePKID);
                        cmd.Parameters.AddWithValue("@EmployeePKID", Obj_Emp_BalLeave.EmployeePKID);
                        //cmd.Parameters.AddWithValue("@EmployeeName", Obj_Emp_BalLeave.EmployeeName);
                        cmd.Parameters.AddWithValue("@LossOfPay", Obj_Emp_BalLeave.LossOfPay);
                        cmd.Parameters.AddWithValue("@CasualLeave", Obj_Emp_BalLeave.CasualLeave);
                        cmd.Parameters.AddWithValue("@CompOff", Obj_Emp_BalLeave.CompOff);
                        cmd.Parameters.AddWithValue("@SickLeave", Obj_Emp_BalLeave.SickLeave);
                        cmd.Parameters.AddWithValue("@RecreationalLeave", Obj_Emp_BalLeave.RecreationalLeave);
                        cmd.Parameters.AddWithValue("@CreatedBy", Obj_Emp_BalLeave.CreatedBy);

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

        public string DeleteEmployeeBalanceLeaveById(int EmpBal_PKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("DeleteEmployeeBalanceLeaveById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpBal_PKID", EmpBal_PKID);
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

        //===============EMPLOYEE START===========================================

        public string FnApplyLeave(CT_Leave Obj_Emp_Leave)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_ApplyLeave", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LeavePKID", Obj_Emp_Leave.LeavePKID);
                        cmd.Parameters.AddWithValue("@EmployeePKID", Obj_Emp_Leave.EmployeePKID);
                        cmd.Parameters.AddWithValue("@Leavetype", Obj_Emp_Leave.Leavetype);
                        cmd.Parameters.AddWithValue("@FromDate", Obj_Emp_Leave.Fromdate);
                        cmd.Parameters.AddWithValue("@ToDate", Obj_Emp_Leave.Todate);
                        cmd.Parameters.AddWithValue("@ContactDetails", Obj_Emp_Leave.ContactDetails);
                        cmd.Parameters.AddWithValue("@Reason", Obj_Emp_Leave.Reason);


                        //cmd.Parameters.AddWithValue("@ManagerApproveRejectStatus", Obj_Emp_Leave.ManagerApproveRejectStatus);
                        //cmd.Parameters.AddWithValue("@ManagerApproveRejectComment", Obj_Emp_Leave.ManagerApproveRejectComment);
                        //cmd.Parameters.AddWithValue("@HRApproveRejectStatus", Obj_Emp_Leave.HRApproveRejectStatus);
                        //cmd.Parameters.AddWithValue("@HRApproveRejectComment", Obj_Emp_Leave.HRApproveRejectComment);

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



        public List<CT_AddBalanceLeave> CheckTotalLeaveBalance(int EmployeePKID)
        {
            List<CT_AddBalanceLeave> CT_AddBalanceLeave_List = new List<CT_AddBalanceLeave>();
            try
            {
                var oSQLConn = new
SqlConnection(
System.Configuration.ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString()
);
                using (oSQLConn)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_CheckTotalLeaveBalance", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
                        oSQLConn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CT_AddBalanceLeave obj = new CT_AddBalanceLeave();
                            obj.BalLeavePKID = Convert.ToInt32(reader["BalLeavePKID"].ToString());
                            obj.EmployeePKID = Convert.ToInt32(reader["EmployeePKID"].ToString());
                            obj.EmployeeName = reader["EmployeeName"].ToString();
                            obj.LossOfPay = Convert.ToInt32(reader["LossOfPay"].ToString());
                            obj.CasualLeave = Convert.ToInt32(reader["CasualLeave"].ToString());
                            obj.CompOff = Convert.ToInt32(reader["CompOff"].ToString());
                            obj.SickLeave = Convert.ToInt32(reader["SickLeave"].ToString());
                            obj.RecreationalLeave = Convert.ToInt32(reader["RecreationalLeave"].ToString());
                            obj.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());
                            obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                            obj.CreatedOnFormat = Convert.ToString(obj.CreatedOn.Date.ToString("yyyy/MM/dd"));
                            CT_AddBalanceLeave_List.Add(obj);
                        }
                        return CT_AddBalanceLeave_List;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<CT_Leave> GetEmployeeApplyLeave(int EmployeePKID)
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
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetEmployeeApplyLeave", oSQLConn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", EmployeePKID);
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



        public string DeleteEmployeeLeaveById(int EmpLeavePKID)
        {
            string returntype = "";
            CT_CreateEmployee obj = new CT_CreateEmployee();
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_DeleteEmployeeLeaveById", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpLeavePKID", EmpLeavePKID);
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