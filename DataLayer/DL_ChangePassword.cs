using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_ChangePassword : DL_Base
    {

        public string FnChangePassword(CT_ChangePassword obj_CT_ChgPass)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("sp_ChangePassword", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeePKID", obj_CT_ChgPass.EmployeePKID);
                        cmd.Parameters.AddWithValue("@CurrentPassword", obj_CT_ChgPass.CurrentPassword);
                        cmd.Parameters.AddWithValue("@NewPassword", obj_CT_ChgPass.NewPassword);
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