using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Tracing;
using PaySmartDashboard;
using PaySmartDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class FleetOwnerFareController : ApiController
    {
        [HttpGet]
        public DataSet getRouteFare(int routeId, int fleetownerId)
        {
            DataSet rs = new DataSet();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getRouteFare credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRouteFare";
            cmd.Connection = conn;

            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@RouteId";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = routeId;
            cmd.Parameters.Add(ccd);

            SqlParameter foid = new SqlParameter();
            foid.ParameterName = "@fleetownerId";
            foid.SqlDbType = SqlDbType.Int;
            foid.Value = fleetownerId;
            cmd.Parameters.Add(foid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);

            //prepare the table and sent it to client side

            DataTable result = new DataTable();
            result.Columns.Add("Destination/Rows");

            //add the stops as the columns
            DataTable stops = ds.Tables[1];
            for (int row = 0; row < stops.Rows.Count; row++)
            {
                result.Columns.Add(stops.Rows[row][0].ToString());
            }

            for (int row = 0; row < stops.Rows.Count; row++)
            {
                DataRow dr = result.NewRow();
                dr[0] = stops.Rows[row][0].ToString();
                result.Rows.Add(dr);
            }
            //for each column (stop) iterate and prepare rows
            //the rows will be equal to the columns count

            // int found = 0;
            DataTable dt = stops.Copy();
            rs.Tables.Add(result);
            rs.Tables.Add(dt);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getRouteFare Credentials completed.");
            return rs;
        }
        [HttpPost]
        public HttpResponseMessage saveRouteFare(RouteFare b)
         {
            SqlConnection conn = new SqlConnection();
            LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
                
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveRouteFare credentials....");

            //connect to database
           
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELRouteFare";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = b.Id;
            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@RouteId";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = Convert.ToString(b.RouteId);
            cmd.Parameters.Add(ccd);
            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@VehicleType";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.VehicleType;
            cmd.Parameters.Add(cname);
            SqlParameter ccds = new SqlParameter();
            ccds.ParameterName = "@SourceStopId";
            ccds.SqlDbType = SqlDbType.Int;
            ccds.Value = Convert.ToString(b.SourceStopId);
            cmd.Parameters.Add(ccds);
            SqlParameter ccdsa = new SqlParameter();
            ccdsa.ParameterName = "@DestinationStopId";
            ccdsa.SqlDbType = SqlDbType.Int;
            ccdsa.Value = Convert.ToString(b.DestinationStopId);
            cmd.Parameters.Add(ccdsa);

            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Distance";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Distance;
            cmd.Parameters.Add(dd);
            SqlParameter pup = new SqlParameter();
            pup.ParameterName = "@PerUnitPrice";
            pup.SqlDbType = SqlDbType.Int;
            pup.Value = Convert.ToString(b.PerUnitPrice);
            cmd.Parameters.Add(pup);
            SqlParameter pupa = new SqlParameter();
            pupa.ParameterName = "@Amount";
            pupa.SqlDbType = SqlDbType.Int;
            pupa.Value = Convert.ToString(b.Amount);
            cmd.Parameters.Add(pupa);
            SqlParameter dda = new SqlParameter();
            dda.ParameterName = "@FareType";
            dda.SqlDbType = SqlDbType.VarChar;
            dda.Value = b.FareType;
            cmd.Parameters.Add(dda);


            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Active";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.Active;
            cmd.Parameters.Add(aa);


            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveRouteFare Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveRouteFare:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
         }

        public void Options()
        {

        }
    }
}
