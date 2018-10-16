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
    public class FleetRoutesController : ApiController
    {
        [HttpPost]
        [Route("api/FleetRoutes/getFleetRoutesList")]
        public DataTable List(FleetRoutes fr)
        {
            DataTable Tb1 = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetRoutesList credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetfleetRoutes";
            cmd.Connection = conn;

            SqlParameter gsa = new SqlParameter();
            gsa.ParameterName = "@routeid";
            gsa.SqlDbType = SqlDbType.Int;
            gsa.Value = fr.RouteId;
            cmd.Parameters.Add(gsa);

            SqlParameter cmpid = new SqlParameter();
            cmpid.ParameterName = "@cmpId";
            cmpid.SqlDbType = SqlDbType.Int;
            cmpid.Value = fr.cmpId;
            cmd.Parameters.Add(cmpid);

            SqlParameter foid = new SqlParameter();
            foid.ParameterName = "@fleetownerId";
            foid.SqlDbType = SqlDbType.Int;
            foid.Value = fr.fleetownerId;
            cmd.Parameters.Add(foid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(Tb1);

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetRoutesList Credentials completed.");
            return Tb1;

        }
        [HttpPost]
        public HttpResponseMessage NewFleetRoutes(FleetRoutes f)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetRoutes credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFleetRoutes";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = f.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@VehicleId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = f.VehicleId;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@RouteId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = f.RouteId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
                gsac.Value = f.EffectiveFrom;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ToDate";
                gid.SqlDbType = SqlDbType.DateTime;
                gid.Value = f.EffectiveTill;
                cmd.Parameters.Add(gid);

                SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
                flag.Value = f.insupddelflag;
                cmd.Parameters.Add(flag);


                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetRoutes Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveNewFleetRoutes:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {
        }

    }
}
