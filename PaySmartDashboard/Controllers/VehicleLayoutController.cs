using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Tracing;


namespace PaySmartDashboard.Controllers
{
    public class VehicleLayoutController : ApiController
    {

        [HttpGet]
        [Route("api/VehicleLayout/GetVehicleLayout")]
        public DataTable GetVehicleLayout(int rows, int col)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetvehicleLayout";

            cmd.Parameters.Add("@Rows", SqlDbType.Int).Value = rows;
            cmd.Parameters.Add("@col", SqlDbType.Int).Value = col;
            cmd.Connection = conn;

           
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(dt);           

            return dt;
        }

        [HttpPost]
        [Route("api/VehicleLayout/saveVehicleLayout")]
        public HttpResponseMessage saveVehicleLayout(IEnumerable<VehicleLayout> vcList)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveVehicleLayout credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelVehicleLayout";
            cmd.Connection = conn;
            conn.Open();

            try
            {
                foreach (VehicleLayout vc in vcList)
                {
                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@VehicleLayoutTypeId";
                    gsab.SqlDbType = SqlDbType.Int;
                    gsab.Value = vc.VehicleLayoutTypeId;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gsac = new SqlParameter();
                    gsac.ParameterName = "@RowNo";
                    gsac.SqlDbType = SqlDbType.Int;
                    gsac.Value = vc.RowNo;
                    cmd.Parameters.Add(gsac);

                    SqlParameter nvr = new SqlParameter();
                    nvr.ParameterName = "@ColNo";
                    nvr.SqlDbType = SqlDbType.Int;
                    nvr.Value = vc.ColNo;
                    cmd.Parameters.Add(nvr);

                    SqlParameter gsk = new SqlParameter();
                    gsk.ParameterName = "@VehicleTypeId";
                    gsk.SqlDbType = SqlDbType.Int;
                    gsk.Value = vc.VehicleTypeId;
                    cmd.Parameters.Add(gsk);

                    //@needHireVehicle
                    SqlParameter nhv = new SqlParameter();
                    nhv.ParameterName = "@label";
                    nhv.SqlDbType = SqlDbType.VarChar;
                    nhv.Value = vc.label;
                    cmd.Parameters.Add(nhv);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = vc.insupdflag;
                    cmd.Parameters.Add(insupdflag);


                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveVehicleLayout Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveVehicleLayout Credentials completed.");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("api/VehicleLayout/SaveFleetOwnerVehicleLayout")]
        public HttpResponseMessage SaveFleetOwnerVehicleLayout(IEnumerable<FleetOwnerVehicleLayout> FOvcList)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerVehicleLayout credentials....");
            //DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFleetOwnerVehicleLayout";
            cmd.Connection = conn;
            conn.Open();

            //  SqlParameter gsaa = new SqlParameter();                    
            //  gsaa.ParameterName = "@Id";
            //  gsaa.SqlDbType = SqlDbType.Int;         
            //  cmd.Parameters.Add(gsaa);
            try
            {
                foreach (FleetOwnerVehicleLayout vc in FOvcList)
                {
                    SqlParameter gsab1 = new SqlParameter();
                    gsab1.ParameterName = "@VehicleLayoutTypeId";
                    gsab1.SqlDbType = SqlDbType.Int;
                    gsab1.Value = vc.VehicleLayoutTypeId;
                    cmd.Parameters.Add(gsab1);

                    SqlParameter gsac1 = new SqlParameter();
                    gsac1.ParameterName = "@RowNo";
                    gsac1.SqlDbType = SqlDbType.Int;
                    gsac1.Value = vc.RowNo;
                    cmd.Parameters.Add(gsac1);

                    SqlParameter nvr = new SqlParameter();
                    nvr.ParameterName = "@ColNo";
                    nvr.SqlDbType = SqlDbType.Int;
                    nvr.Value = vc.ColNo;
                    cmd.Parameters.Add(nvr);

                    SqlParameter gsk = new SqlParameter();
                    gsk.ParameterName = "@VehicleTypeId";
                    gsk.SqlDbType = SqlDbType.Int;
                    gsk.Value = vc.VehicleTypeId;
                    cmd.Parameters.Add(gsk);

                    //@needHireVehicle
                    SqlParameter nhv1 = new SqlParameter();
                    nhv1.ParameterName = "@label";
                    nhv1.SqlDbType = SqlDbType.VarChar;
                    nhv1.Value = vc.label;
                    cmd.Parameters.Add(nhv1);

                    SqlParameter nhve = new SqlParameter();
                    nhve.ParameterName = "@FleetOwnerId";
                    nhve.SqlDbType = SqlDbType.VarChar;
                    nhve.Value = vc.FleetOwnerId;
                    cmd.Parameters.Add(nhve);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = vc.insupdflag;
                    cmd.Parameters.Add(insupdflag);


                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                }
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveFleetOwnerVehicleLayout Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveFleetOwnerVehicleLayout:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
