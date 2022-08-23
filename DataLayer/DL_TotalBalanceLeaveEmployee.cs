using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_TotalBalanceLeaveEmployee :DL_Base
    {
        public List<CT_AddBalanceLeave>  GetCurrentEmployeeBalanceLeave(int EmployeePKID)
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
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_GetAllCurrentEmployeeBalanceLeave", oSQLConn))
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
    }
}