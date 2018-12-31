
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using PaySmartDashboard;
using PaySmartDashboard.Models;

namespace PaySmartDashboard.Controllers
{
    public class LicensePaymentsController : ApiController
    {
        [HttpGet]
        [Route("api/GetLicensePayments")]
        public DataTable LicensePayment1()
        
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicensePayments credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getLicensePayments";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicensePayments Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public HttpResponseMessage LicensePayment2(LicensePayments n)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicensePayments credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database
                
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelLicensePayments";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@expiryOn";
                gs.SqlDbType = SqlDbType.DateTime;
                gs.Value = Convert.ToString(n.expiryOn);
                cmd.Parameters.Add(gs);

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = Convert.ToString(n.Id);
                cmd.Parameters.Add(gsa);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@licenseFor";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.licenseFor;
                cmd.Parameters.Add(gid);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@licenseId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = Convert.ToString(n.licenseId);
                cmd.Parameters.Add(gsab);

                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@licenseType";
                gidb.SqlDbType = SqlDbType.VarChar;
                gidb.Value = n.licenseType;
                cmd.Parameters.Add(gidb);

                SqlParameter guid = new SqlParameter();
                guid.ParameterName = "@paidon";
                guid.SqlDbType = SqlDbType.DateTime;
                guid.Value = Convert.ToString(n.paidon);
                cmd.Parameters.Add(guid);

                SqlParameter guida = new SqlParameter();
                guida.ParameterName = "@renewedon";
                guida.SqlDbType = SqlDbType.DateTime;
                guida.Value = Convert.ToString(n.renewedon);
                cmd.Parameters.Add(guida);

                SqlParameter gidbc = new SqlParameter();
                gidbc.ParameterName = "@transId";
                gidbc.SqlDbType = SqlDbType.VarChar;
                gidbc.Value = n.transId;
                cmd.Parameters.Add(gidbc);




                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicensePayments Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicensePayments:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {
        }
       
    }
}
