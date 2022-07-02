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
                        cmd.Parameters.AddWithValue("@PersonalEmail", obj_CT_Log.UserName);
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
    }
}