
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Tracing;
using PaySmartDashboard.Models;
using PaySmartDashboard;

namespace SmartTicketDashboard.Controllers
{
    public class FleetOwnerVehicleScheduleController : ApiController
    {
        [HttpGet]
        [Route("api/FleetOwnerVehicleSchedule/getFORVehicleSchedule")]
        public DataTable getFORVehicleSchedule(int fleetownerid, int routeid, int vehicleId)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getFORVehicleSchedule credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getFORVehicleSchedule";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            SqlParameter fo = new SqlParameter();
            fo.ParameterName = "@fleetownerId";
            fo.SqlDbType = SqlDbType.Int;
            fo.Value = fleetownerid;
            cmd.Parameters.Add(fo);

            SqlParameter fsc = new SqlParameter();
            fsc.ParameterName = "@vehicleId";
            fsc.SqlDbType = SqlDbType.Int;
            fsc.Value = vehicleId;
            cmd.Parameters.Add(fsc);

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getFORVehicleSchedule Credentials completed.");
            return Tbl;
        }

        [HttpPost]
        [Route("api/FleetOwnerVehicleSchedule/saveFORSchedule")]
        public HttpResponseMessage saveFORSchedule(FORouteFleetSchedule FVS)
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFORSchedule credentials....");

            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFORouteFleetSchedule";
                cmd.Connection = conn;

                conn.Open();
                List<VehicleSchedule> vSchedList = FVS.VSchedule;

                foreach (VehicleSchedule n in vSchedList)
                {
                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@VehicleId ";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = FVS.VehicleId;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@RouteId";
                    gsab.SqlDbType = SqlDbType.Int;
                    gsab.Value = FVS.RouteId;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gsab1 = new SqlParameter();
                    gsab1.ParameterName = "@FleetOwnerId";
                    gsab1.SqlDbType = SqlDbType.Int;
                    gsab1.Value = FVS.FleetOwnerId;
                    cmd.Parameters.Add(gsab1);

                    SqlParameter gsac = new SqlParameter("@StopId", SqlDbType.VarChar);
                    gsac.Value = n.StopId;
                    gsac.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(gsac);

                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@ArrivalHr";
                    gid.SqlDbType = SqlDbType.Int;
                    gid.Value = n.ArrivalHr;
                    cmd.Parameters.Add(gid);

                    SqlParameter stid = new SqlParameter("@DepartureHr", SqlDbType.VarChar);
                    stid.SqlDbType = SqlDbType.Int;
                    stid.Value = n.DepartureHr;
                    cmd.Parameters.Add(stid);


                    SqlParameter engg = new SqlParameter("@Duration", SqlDbType.VarChar);
                    engg.SqlDbType = SqlDbType.Decimal;
                    engg.Value = n.Duration;
                    cmd.Parameters.Add(engg);

                    SqlParameter fuel = new SqlParameter("@ArrivalMin", SqlDbType.VarChar);
                    fuel.SqlDbType = SqlDbType.Int;
                    fuel.Value = n.ArrivalMin;
                    cmd.Parameters.Add(fuel);

                    SqlParameter mntt = new SqlParameter("@DepartureMin", SqlDbType.VarChar);
                    mntt.SqlDbType = SqlDbType.Int;
                    mntt.Value = n.DepartureMin;
                    cmd.Parameters.Add(mntt);

                    SqlParameter chss = new SqlParameter("@ArrivalAMPM", SqlDbType.VarChar);
                    chss.SqlDbType = SqlDbType.VarChar;
                    chss.Value = n.ArrivalAMPM;
                    cmd.Parameters.Add(chss);


                    SqlParameter chss1 = new SqlParameter("@DepartureAmPm", SqlDbType.VarChar);
                    chss1.SqlDbType = SqlDbType.VarChar;
                    chss1.Value = n.DepartureAmPm;
                    cmd.Parameters.Add(chss1);

                    SqlParameter seatc = new SqlParameter("@arrivaltime", SqlDbType.VarChar);
                    seatc.SqlDbType = SqlDbType.DateTime;
                    seatc.Value = n.arrivaltime;
                    cmd.Parameters.Add(seatc);


                    SqlParameter deat = new SqlParameter("@departuretime", SqlDbType.VarChar);
                    deat.SqlDbType = SqlDbType.DateTime;
                    deat.Value = n.departuretime;
                    cmd.Parameters.Add(deat);

                    SqlParameter e3 = new SqlParameter("@insupddelflag ", SqlDbType.VarChar);
                    e3.SqlDbType = SqlDbType.VarChar;
                    e3.Value = n.insupddelflag;
                    cmd.Parameters.Add(e3);

                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFORSchedule Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveFORSchedule:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("api/FleetOwnerVehicleSchedule/getVehicleScheduleList")]
        public DataTable getVehicleScheduleList(int routeid, int vehicleId)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getVehicleScheduleList ....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetScheduleList";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            
            SqlParameter fsc = new SqlParameter();
            fsc.ParameterName = "@fleetId";
            fsc.SqlDbType = SqlDbType.Int;
            fsc.Value = vehicleId;
            cmd.Parameters.Add(fsc);

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@RouteId";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getVehicleScheduleList completed.");
            return Tbl;
        }


        [HttpPost]
        [Route("api/FleetOwnerVehicleSchedule/saveVScheduleList")]
        public HttpResponseMessage saveVScheduleList(FORouteFleetSchedule FVS)
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFORSchedule credentials....");

            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFORouteFleetSchedule";
                cmd.Connection = conn;

                conn.Open();
                List<VehicleSchedule> vSchedList = FVS.VSchedule;

                foreach (VehicleSchedule n in vSchedList)
                {
                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@VehicleId ";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = FVS.VehicleId;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@RouteId";
                    gsab.SqlDbType = SqlDbType.Int;
                    gsab.Value = FVS.RouteId;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gsab1 = new SqlParameter();
                    gsab1.ParameterName = "@FleetOwnerId";
                    gsab1.SqlDbType = SqlDbType.Int;
                    gsab1.Value = FVS.FleetOwnerId;
                    cmd.Parameters.Add(gsab1);

                    SqlParameter gsac = new SqlParameter("@StopId", SqlDbType.VarChar);
                    gsac.Value = n.StopId;
                    gsac.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(gsac);

                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@ArrivalHr";
                    gid.SqlDbType = SqlDbType.Int;
                    gid.Value = n.ArrivalHr;
                    cmd.Parameters.Add(gid);

                    SqlParameter stid = new SqlParameter("@DepartureHr", SqlDbType.VarChar);
                    stid.SqlDbType = SqlDbType.Int;
                    stid.Value = n.DepartureHr;
                    cmd.Parameters.Add(stid);


                    SqlParameter engg = new SqlParameter("@Duration", SqlDbType.VarChar);
                    engg.SqlDbType = SqlDbType.Decimal;
                    engg.Value = n.Duration;
                    cmd.Parameters.Add(engg);

                    SqlParameter fuel = new SqlParameter("@ArrivalMin", SqlDbType.VarChar);
                    fuel.SqlDbType = SqlDbType.Int;
                    fuel.Value = n.ArrivalMin;
                    cmd.Parameters.Add(fuel);

                    SqlParameter mntt = new SqlParameter("@DepartureMin", SqlDbType.VarChar);
                    mntt.SqlDbType = SqlDbType.Int;
                    mntt.Value = n.DepartureMin;
                    cmd.Parameters.Add(mntt);

                    SqlParameter chss = new SqlParameter("@ArrivalAMPM", SqlDbType.VarChar);
                    chss.SqlDbType = SqlDbType.VarChar;
                    chss.Value = n.ArrivalAMPM;
                    cmd.Parameters.Add(chss);


                    SqlParameter chss1 = new SqlParameter("@DepartureAmPm", SqlDbType.VarChar);
                    chss1.SqlDbType = SqlDbType.VarChar;
                    chss1.Value = n.DepartureAmPm;
                    cmd.Parameters.Add(chss1);

                    SqlParameter seatc = new SqlParameter("@arrivaltime", SqlDbType.VarChar);
                    seatc.SqlDbType = SqlDbType.DateTime;
                    seatc.Value = n.arrivaltime;
                    cmd.Parameters.Add(seatc);


                    SqlParameter deat = new SqlParameter("@departuretime", SqlDbType.VarChar);
                    deat.SqlDbType = SqlDbType.DateTime;
                    deat.Value = n.departuretime;
                    cmd.Parameters.Add(deat);

                    SqlParameter e3 = new SqlParameter("@insupddelflag ", SqlDbType.VarChar);
                    e3.SqlDbType = SqlDbType.VarChar;
                    e3.Value = n.insupddelflag;
                    cmd.Parameters.Add(e3);

                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFORSchedule Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in saveFORSchedule:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
         public void Options()
        {

        }

    }
}
