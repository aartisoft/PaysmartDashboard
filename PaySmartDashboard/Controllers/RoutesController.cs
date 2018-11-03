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
    public class RoutesController : ApiController
    {
        [HttpGet]
        [Route("api/Routes/GetRoutes")]
        public DataTable GetRoutes()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetRoutes credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRoutes";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetRoutes Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage saveRoutes(Routes r)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveRoutes credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelRoutes";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@Id";
                cid.SqlDbType = SqlDbType.Int;
                cid.Value = Convert.ToString(r.Id);
                cmd.Parameters.Add(cid);

                SqlParameter broute = new SqlParameter();
                broute.ParameterName = "@RouteName";
                broute.SqlDbType = SqlDbType.VarChar;
                broute.Value = r.RouteName;
                cmd.Parameters.Add(broute);

                SqlParameter acode = new SqlParameter();
                acode.ParameterName = "@Code";
                acode.SqlDbType = SqlDbType.VarChar;
                acode.Value = r.Code;
                cmd.Parameters.Add(acode);

                SqlParameter ddes = new SqlParameter();
                ddes.ParameterName = "@Distance";
                ddes.SqlDbType = SqlDbType.Decimal;
                ddes.Value = r.Distance;
                cmd.Parameters.Add(ddes);


                SqlParameter gact = new SqlParameter();
                gact.ParameterName = "@Active";
                gact.SqlDbType = SqlDbType.Int;
                gact.Value = r.Active;
                cmd.Parameters.Add(gact);

                SqlParameter ii = new SqlParameter();
                ii.ParameterName = "@Description";
                ii.SqlDbType = SqlDbType.VarChar;
                ii.Value = r.Description;
                cmd.Parameters.Add(ii);

                SqlParameter ff = new SqlParameter();
                ff.ParameterName = "@SourceId";
                ff.SqlDbType = SqlDbType.Int;
                ff.Value = r.SourceId;
                cmd.Parameters.Add(ff);

                SqlParameter hh = new SqlParameter();
                hh.ParameterName = "@DestinationId";
                hh.SqlDbType = SqlDbType.Int;
                hh.Value = r.DestinationId;
                cmd.Parameters.Add(hh);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveRoutes Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveRoutes:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {

        }

    }
}
