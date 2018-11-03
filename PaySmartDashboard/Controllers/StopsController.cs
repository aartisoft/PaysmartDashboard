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
    public class StopsController : ApiController
    {
        [HttpGet]
        public DataTable GetStops()//Main Method
        {


            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetStops credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetStops";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetStops Credentials completed.");
            
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage saveStops(stops s)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveStops credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdelStops";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter sId = new SqlParameter("@Id", SqlDbType.Int);
                sId.Value = s.Id;
                cmd.Parameters.Add(sId);

                SqlParameter sName = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                sName.Value = s.Name;
                cmd.Parameters.Add(sName);
                SqlParameter sDescription = new SqlParameter("@Description", SqlDbType.VarChar, 50);
                sDescription.Value = s.Description;
                cmd.Parameters.Add(sDescription);
                SqlParameter Code = new SqlParameter("@Code", SqlDbType.VarChar, 50);
                Code.Value = s.Code;
                cmd.Parameters.Add(Code);
                SqlParameter sActive = new SqlParameter("@Active", SqlDbType.Int);
                sActive.Value = s.Active;
                cmd.Parameters.Add(sActive);

                SqlParameter srcLat = new SqlParameter("@latitude", SqlDbType.VarChar, 15);
                srcLat.Value = s.srcLat;
                cmd.Parameters.Add(srcLat);

                SqlParameter srcLon = new SqlParameter("@longitude", SqlDbType.VarChar, 15);
                srcLon.Value = s.srcLon;
                cmd.Parameters.Add(srcLon);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = s.insupdflag;
                cmd.Parameters.Add(insupdflag);


                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveStops Credentials completed.");
            
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveStops:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {

        }
    }
}
