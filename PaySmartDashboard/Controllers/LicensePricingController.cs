
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
    public class LicensePricingController : ApiController
    {

        [HttpGet]
        public DataTable LicensePricing(int categoryid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicensePricing credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicensePricing";
            cmd.Connection = conn;

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@categoryid";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = categoryid;
            cmd.Parameters.Add(lid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicensePricing Credentials completed.");
            // int found = 0;
            return Tbl;
        }
    
   
        [HttpPost]
        public HttpResponseMessage SaveLicensePricing(LicensePricing b)
       {

           LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicensePricing credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelLicensePricing";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
           
              SqlParameter lid = new SqlParameter();
              lid.ParameterName = "@LicenseId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToString(b.LicenseId);
            cmd.Parameters.Add(lid);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@RenewalFreqTypeId";
            ss.SqlDbType = SqlDbType.Int;
            ss.Value = b.RenewalFreqTypeId;
            cmd.Parameters.Add(ss);

             SqlParameter pid = new SqlParameter();
             pid.ParameterName = "@RenewalFreq";
            pid.SqlDbType = SqlDbType.Int;
            pid.Value = b.RenewalFreq;
            cmd.Parameters.Add(pid);

            SqlParameter sid = new SqlParameter();
            sid.ParameterName = "@UnitPrice";
            sid.SqlDbType = SqlDbType.Decimal;
            sid.Value = b.UnitPrice;
            cmd.Parameters.Add(sid);

            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@todate";
            gid.SqlDbType = SqlDbType.DateTime;
            gid.Value = b.todate;
            cmd.Parameters.Add(gid);

            SqlParameter fid = new SqlParameter();
            fid.ParameterName = "@fromdate";
            fid.SqlDbType = SqlDbType.DateTime;
            fid.Value = b.fromdate;
            cmd.Parameters.Add(fid);


            SqlParameter nActive = new SqlParameter("@insupddelflag", SqlDbType.Char);
            nActive.Value = b.insupddelflag;
            cmd.Parameters.Add(nActive);

            cmd.ExecuteScalar();
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicensePricing Credentials completed.");
             //int found = 0;
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicensePricing:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
       }

        public void Options() { }
    }
}


  