using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_UploadResume :DL_Base
    {
        public string FnAddUploadResume(CT_UploadResume Obj_CT_UploadResume_Obj)
        {
            string returntype = "";
            try
            {
                using (con)
                {
                    using (cmd = new System.Data.SqlClient.SqlCommand("SP_AddUploadResume", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmployeePKID", Obj_CT_UploadResume_Obj.EmployeePKID);
                        cmd.Parameters.AddWithValue("@Resume", Obj_CT_UploadResume_Obj.Resume);
                        cmd.Parameters.AddWithValue("@CreatedOn", Obj_CT_UploadResume_Obj.CreatedOn);
                        cmd.Parameters.AddWithValue("@Status", Obj_CT_UploadResume_Obj.Status);

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