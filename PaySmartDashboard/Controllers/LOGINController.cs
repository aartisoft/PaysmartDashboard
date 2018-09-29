using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace PaySmartDashboard.Controllers
{
    public class LOGINController : ApiController
    {
        [HttpPost]

        public DataTable ValidateCredentials(UserLogin u)
        {

            DataTable Tbl = new DataTable();
            //LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
                string username = u.LoginInfo;
                string pwd = u.Passkey;


                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validating credentials....");

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString = "Data Source=localhost;Initial Catalog=POSDashboard;UserID=admin;Password=admin";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateCredentials";

                cmd.Connection = conn;

                SqlParameter lUserName = new SqlParameter("@logininfo", SqlDbType.VarChar, 50);
                lUserName.Value = username;
                lUserName.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(lUserName);


                SqlParameter lPassword = new SqlParameter("@passkey", SqlDbType.VarChar, 50);
                lPassword.Value = pwd;
                lPassword.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(lPassword);
                //System.Threading.Thread.Sleep(10000);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Tbl);

                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validate Credentials completed.");
            }
            catch (Exception ex)
            {
                throw ex;
                //traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "Validate Credentials error:." + ex.Message);
            }
            return Tbl;

        }
    }
}
