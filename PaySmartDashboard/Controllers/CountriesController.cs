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
    public class CountriesController : ApiController
    {
        [HttpGet]

        public DataTable GetCountries()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCountries ...");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCountries";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCountries completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        public HttpResponseMessage SaveCountries(IEnumerable<Country> countries)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCountries ....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdCountry";
                cmd.Connection = conn;
                conn.Open();

                foreach (Country c in countries)
                {

                    SqlParameter rid = new SqlParameter();
                    rid.ParameterName = "@Id";
                    rid.SqlDbType = SqlDbType.Int;
                    rid.Value = c.Id;
                    cmd.Parameters.Add(rid);

                    SqlParameter cmpid = new SqlParameter();
                    cmpid.ParameterName = "@HasOperations";
                    cmpid.SqlDbType = SqlDbType.Int;
                    cmpid.Value = c.HasOperations;
                    cmd.Parameters.Add(cmpid);


                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCountries completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCountries:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("api/Countries/UpdateCountry")]
        public HttpResponseMessage SaveCountries(Country c)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCountries ....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCOUNTRY";
                cmd.Connection = conn;
                conn.Open();

                SqlParameter flg = new SqlParameter("@flg", SqlDbType.VarChar);
                flg.Value = c.flg;
                cmd.Parameters.Add(flg);

                SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
                Id.Value = c.Id;
                cmd.Parameters.Add(Id);

                SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
                name.Value = c.Name;
                cmd.Parameters.Add(name);

                SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
                code.Value = c.Code;
                cmd.Parameters.Add(code);

                SqlParameter lat = new SqlParameter("@Latitude", SqlDbType.VarChar, 15);
                lat.Value = c.Latitude;
                cmd.Parameters.Add(lat);

                SqlParameter lon = new SqlParameter("@Longitude", SqlDbType.VarChar, 15);
                lon.Value = c.Longitude;
                cmd.Parameters.Add(lon);

                SqlParameter flag = new SqlParameter("@Flag", SqlDbType.VarChar);
                flag.Value = c.Flag;
                cmd.Parameters.Add(flag);

                SqlParameter ho = new SqlParameter("@HasOperations", SqlDbType.VarChar);
                ho.Value = c.HasOperations;
                cmd.Parameters.Add(ho);

                cmd.ExecuteScalar();


                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCountries completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCountries:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}