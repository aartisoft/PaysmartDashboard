using PaySmartDashboard;
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
    public class RoleDetailsController : ApiController
    {
        [HttpGet]
        [Route("api/RoleDetails/GetRoleDetails")]
        public DataSet GetRoleDetails(int roleId)
        {            
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getroledetails credentials....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRoledetails";
            cmd.Connection = conn;

            SqlParameter Aid = new SqlParameter("@roleId",SqlDbType.Int);
            Aid.Value = roleId;
            cmd.Parameters.Add(Aid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getroledetails Credentials completed.");
            // int found = 0;
            return ds;
        }
        [HttpPost]
        public HttpResponseMessage saveroledetails(roledetails b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveroledetails credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
          
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelRoledetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
         
        
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@ObjectName";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.ObjectName;
            cmd.Parameters.Add(ss);


            SqlParameter ssd = new SqlParameter();
            ssd.ParameterName = "@Path";
            ssd.SqlDbType = SqlDbType.VarChar;
            ssd.Value = b.Path;
            cmd.Parameters.Add(ssd);


            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveroledetails Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveroledetails:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {

        }
    }
}
