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
    public class FleetOwnerRouteFareController : ApiController
    {
        [HttpGet]
        public DataSet GetFOVehicleFareConfig(int vehicleId, int routeId)
        {
            DataSet Tbl = new DataSet();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFOVehicleFareConfig credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFOVehicleFareConfig";
            cmd.Connection = conn;

            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@vehicleid";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = vehicleId;
            cmd.Parameters.Add(ccd);

            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@routeId";
            rid.SqlDbType = SqlDbType.Int;
            rid.Value = routeId;

            cmd.Parameters.Add(rid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFOVehicleFareConfig Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage saveFleetOwnerRoutefare(FORouteFareConfig RouteFareConfig)
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFleetOwnerRoutefare credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelFORouteFare";
                cmd1.Connection = conn;
                conn.Open();

                SqlParameter vid1 = new SqlParameter();
                vid1.ParameterName = "@VehicleId";
                vid1.SqlDbType = SqlDbType.Int;
                vid1.Value = RouteFareConfig.VehicleId;
                cmd1.Parameters.Add(vid1);

                SqlParameter ccd1 = new SqlParameter();
                ccd1.ParameterName = "@RouteId";
                ccd1.SqlDbType = SqlDbType.Int;
                ccd1.Value = RouteFareConfig.RouteId;
                cmd1.Parameters.Add(ccd1);

                SqlParameter pu = new SqlParameter();
                pu.ParameterName = "@PricingTypeId";
                pu.SqlDbType = SqlDbType.Int;
                pu.Value = RouteFareConfig.PriceTypeId;
                cmd1.Parameters.Add(pu);

                SqlParameter pup1 = new SqlParameter();
                pup1.ParameterName = "@UnitPrice";
                pup1.SqlDbType = SqlDbType.Decimal;
                pup1.Value = RouteFareConfig.UnitPrice;
                cmd1.Parameters.Add(pup1);

                SqlParameter amt = new SqlParameter();
                amt.ParameterName = "@Amount";
                amt.SqlDbType = SqlDbType.Decimal;
                amt.Value = RouteFareConfig.Amount;
                cmd1.Parameters.Add(amt);

                SqlParameter fd1 = new SqlParameter();
                fd1.ParameterName = "@FromDate";
                fd1.SqlDbType = SqlDbType.DateTime;
                fd1.Value = RouteFareConfig.FromDate;
                cmd1.Parameters.Add(fd1);

                SqlParameter td1 = new SqlParameter();
                td1.ParameterName = "@ToDate";
                td1.SqlDbType = SqlDbType.DateTime;
                td1.Value = RouteFareConfig.ToDate;
                cmd1.Parameters.Add(td1);

                SqlParameter sid = new SqlParameter();
                sid.ParameterName = "@SourceId";
                sid.SqlDbType = SqlDbType.Int;
                sid.Value = RouteFareConfig.SourceId;
                cmd1.Parameters.Add(sid);

                SqlParameter did = new SqlParameter();
                did.ParameterName = "@DestinationId";
                did.SqlDbType = SqlDbType.Int;
                did.Value = RouteFareConfig.DestinationId;
                cmd1.Parameters.Add(did);

                cmd1.ExecuteScalar();


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFleetOwnerRouteFare";
                cmd.Connection = conn;


                List<FORouteFare> fareList = null;
                if (RouteFareConfig.routeFare != null && RouteFareConfig.routeFare.Count > 0)
                {
                    fareList = RouteFareConfig.routeFare;
                }


                foreach (FORouteFare b in fareList)
                {
                    SqlParameter ccd = new SqlParameter();
                    ccd.ParameterName = "@RouteId";
                    ccd.SqlDbType = SqlDbType.Int;
                    ccd.Value = b.RouteId;
                    cmd.Parameters.Add(ccd);

                    SqlParameter ccdf = new SqlParameter();
                    ccdf.ParameterName = "@FromStopId";
                    ccdf.SqlDbType = SqlDbType.Int;
                    ccdf.Value = b.FromStopId;
                    cmd.Parameters.Add(ccdf);

                    SqlParameter ccdff = new SqlParameter();
                    ccdff.ParameterName = "@ToStopId";
                    ccdff.SqlDbType = SqlDbType.Int;
                    ccdff.Value = b.ToStopId;
                    cmd.Parameters.Add(ccdff);

                    SqlParameter cname = new SqlParameter();
                    cname.ParameterName = "@VehicleTypeId";
                    cname.SqlDbType = SqlDbType.VarChar;
                    cname.Value = b.VehicleTypeId;
                    cmd.Parameters.Add(cname);


                    SqlParameter dd = new SqlParameter();
                    dd.ParameterName = "@Distance";
                    dd.SqlDbType = SqlDbType.Decimal;
                    dd.Value = b.Distance;
                    cmd.Parameters.Add(dd);

                    SqlParameter pup = new SqlParameter();
                    pup.ParameterName = "@PerUnitPrice";
                    pup.SqlDbType = SqlDbType.Decimal;
                    pup.Value = b.PerUnitPrice;
                    cmd.Parameters.Add(pup);

                    SqlParameter pupa = new SqlParameter();
                    pupa.ParameterName = "@Amount";
                    pupa.SqlDbType = SqlDbType.Decimal;
                    pupa.Value = b.Amount;
                    cmd.Parameters.Add(pupa);

                    SqlParameter dda = new SqlParameter();
                    dda.ParameterName = "@FareTypeId";
                    dda.SqlDbType = SqlDbType.Int;
                    dda.Value = b.FareTypeId;
                    cmd.Parameters.Add(dda);


                    SqlParameter aa = new SqlParameter();
                    aa.ParameterName = "@Active";
                    aa.SqlDbType = SqlDbType.Int;
                    aa.Value = b.Active;
                    cmd.Parameters.Add(aa);

                    SqlParameter fd = new SqlParameter();
                    fd.ParameterName = "@FromDate";
                    fd.SqlDbType = SqlDbType.DateTime;
                    fd.Value = b.FromDate;
                    cmd.Parameters.Add(fd);


                    SqlParameter td = new SqlParameter();
                    td.ParameterName = "@ToDate";
                    td.SqlDbType = SqlDbType.DateTime;
                    td.Value = b.ToDate;
                    cmd.Parameters.Add(td);


                    SqlParameter vid = new SqlParameter();
                    vid.ParameterName = "@VehicleId";
                    vid.SqlDbType = SqlDbType.Int;
                    vid.Value = b.VehicleId;
                    cmd.Parameters.Add(vid);


                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }
                //connect to database
                conn.Close();

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFleetOwnerRoutefare Credentials completed.");
                // int found = 0;
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {

        }
    }
}
