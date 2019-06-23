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

namespace SmartTicketDashboard.Controllers
{
    public class FleetOwnerRouteDetailsController : ApiController
    {
        [HttpGet]
        public DataSet GetFleetOwnerRouteDetails(int fleetOwnerId, int routeid)
        {
            // DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetOwnerRouteDetails credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetownerRouteDetails";
            cmd.Connection = conn;

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            SqlParameter fid = new SqlParameter();
            fid.ParameterName = "@fleetOwnerId";
            fid.SqlDbType = SqlDbType.Int;
            fid.Value = fleetOwnerId;
            cmd.Parameters.Add(fid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            // Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetOwnerRouteDetails Credentials completed.");
            
            // int found = 0;
            return ds;
        }


        [HttpPost]
        public HttpResponseMessage SaveFleetOwnerRouteDetails(IEnumerable<RouteDetails> routestops)
       {

           LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerRouteDetails credentials....");
 
            SqlConnection conn = new SqlConnection();
            try
            {


            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFleetOwnerRouteStops";
            cmd.Connection = conn;
            conn.Open();

            foreach (RouteDetails s in routestops)
            {

                SqlParameter ba = new SqlParameter("@RouteId", SqlDbType.Int);
                ba.Value = s.RouteId;
                cmd.Parameters.Add(ba);

                SqlParameter bb = new SqlParameter("@StopId", SqlDbType.Int);
                bb.Value = s.stopId;
                cmd.Parameters.Add(bb);

                SqlParameter fo = new SqlParameter("@FleetOwnerId", SqlDbType.Int);
                fo.Value = s.FleetOwnerId;
                cmd.Parameters.Add(fo);

                SqlParameter insupdflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar, 1);
                insupdflag.Value = s.insupddelflag;
                cmd.Parameters.Add(insupdflag);

                cmd.ExecuteScalar();

                cmd.Parameters.Clear();

            }
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerRouteDetails Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveFleetOwnerRouteDetails:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
       }

        public void Options() { }

    }
}

  