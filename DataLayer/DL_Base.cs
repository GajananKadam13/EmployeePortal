using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeePortal.DataLayer
{
    public class DL_Base
    {
        public static string ConStr = ConfigurationManager.ConnectionStrings["Con_EMP_PORT"].ToString();
        public SqlCommand cmd;
        public SqlConnection con;
        public SqlDataAdapter adr;
        public SqlDataReader reader;

        public DL_Base()
        {
            con = new SqlConnection(ConStr);
        }
    }
}