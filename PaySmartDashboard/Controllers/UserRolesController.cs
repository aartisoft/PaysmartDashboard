using SmartTicketDashboard;
using SmartTicketDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace SmartTicketDashboard.Controllers
{
    public class UserRolesController : ApiController
    {
        [HttpGet]
        public DataTable users()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserRoles credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserRoles";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserRoles Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage roles(userroles b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUserRoles credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelUserRoles";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
            SqlParameter iid = new SqlParameter();
            iid.ParameterName = "@UserId";
            iid.SqlDbType = SqlDbType.Int;
            iid.Value = Convert.ToString(b.UserId);
            cmd.Parameters.Add(iid);
            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@CompanyId";
            ii.SqlDbType = SqlDbType.Int;
            ii.Value = Convert.ToString(b.CompanyId);
            cmd.Parameters.Add(ii);
            SqlParameter rr = new SqlParameter();
            rr.ParameterName = "@RoleId";
            rr.SqlDbType = SqlDbType.Int;
            rr.Value = Convert.ToString(b.RoleId);
            cmd.Parameters.Add(rr);
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Passkey";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.Passkey;
            cmd.Parameters.Add(ss);
            

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUserRoles Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
              }
              catch (Exception ex)
              {
                  if (conn != null && conn.State == ConnectionState.Open)
                  {
                      conn.Close();
                  }
                  string str = ex.Message;
                  traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUserRoles:" + ex.Message);
                  return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
              }
          }
        public void Options()
        {

        }
    }
}
