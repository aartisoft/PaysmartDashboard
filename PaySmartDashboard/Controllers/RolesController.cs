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
    public class RolesController : ApiController
    {

        [HttpGet]
        public DataTable GetCompanyRoles(int companyId)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCompanyRoles credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getCompanyRoles";
            cmd.Connection = conn;

            SqlParameter rolesFlag = new SqlParameter();
            rolesFlag.ParameterName = "@cmpId";
            rolesFlag.SqlDbType = SqlDbType.Int;
            rolesFlag.Value = companyId;
            cmd.Parameters.Add(rolesFlag);

         
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCompanyRoles Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        [Route("api/Roles/GetRoles")]
        public DataTable GetRoles(int allroles)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetRoles credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRoles";
         

            SqlParameter rolesFlag = new SqlParameter();
            rolesFlag.ParameterName = "@allroles";
            rolesFlag.SqlDbType = SqlDbType.Int;
            rolesFlag.Value = allroles;
            cmd.Parameters.Add(rolesFlag);

            cmd.Connection = conn;
                       
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetRoles Credentials completed.");
            return Tbl;
        }


        [HttpPost]
        public HttpResponseMessage saveroles(roles b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveroles credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();

            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelRoles";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter cc = new SqlParameter();
                cc.ParameterName = "@Id";
                cc.SqlDbType = SqlDbType.Int;
                cc.Value = Convert.ToString(b.Id);
                cmd.Parameters.Add(cc);

                SqlParameter cname = new SqlParameter();
                cname.ParameterName = "@Name";
                cname.SqlDbType = SqlDbType.VarChar;
                cname.Value = b.Name;
                cmd.Parameters.Add(cname);

                SqlParameter dd = new SqlParameter();
                dd.ParameterName = "@Description";
                dd.SqlDbType = SqlDbType.VarChar;
                dd.Value = b.Description;
                cmd.Parameters.Add(dd);

                SqlParameter aa = new SqlParameter();
                aa.ParameterName = "@Active";
                aa.SqlDbType = SqlDbType.Int;
                aa.Value = b.Active;
                cmd.Parameters.Add(aa);

                SqlParameter aab = new SqlParameter();
                aab.ParameterName = "@IsPublic";
                aab.SqlDbType = SqlDbType.Int;
                aab.Value = b.IsPublic;
                cmd.Parameters.Add(aab);


                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                // Tbl = Tables[0];
                cmd.ExecuteScalar();
                conn.Close();


                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveroles Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveroles:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {

        }
    }
}
