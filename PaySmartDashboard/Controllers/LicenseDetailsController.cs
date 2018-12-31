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
    public class LicenseDetailsController : ApiController
    {
        [HttpGet]
        public DataTable getLicenseDetails(int catId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getLicenseDetails credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseDetails";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@ltypeId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = catId;
            cmd.Parameters.Add(Gid);

           
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getLicenseDetails Credentials completed.");

            // int found = 0;
            return Tbl;
        }
   
        [HttpPost]
        public HttpResponseMessage SaveLicenseDetails(LicenseDetails b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseDetails credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelLicenseDetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@LicenseTypeId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToString(b.LicenseTypeId);
            cmd.Parameters.Add(lid);           
           
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@FeatureTypeId";
            nn.SqlDbType = SqlDbType.Int;
            nn.Value = b.FeatureTypeId;
            cmd.Parameters.Add(nn);

             SqlParameter nm = new SqlParameter();
            nm.ParameterName = "@FeatureLabel";
            nm.SqlDbType = SqlDbType.VarChar;
            nm.Value = b.FeatureLabel;
            cmd.Parameters.Add(nm);

             SqlParameter mn = new SqlParameter();
            mn.ParameterName = "@FeatureValue";
            mn.SqlDbType = SqlDbType.VarChar;
            mn.Value = b.FeatureValue;
            cmd.Parameters.Add(mn);

            SqlParameter ln = new SqlParameter();
            ln.ParameterName = "@LabelClass";
            ln.SqlDbType = SqlDbType.VarChar;
            ln.Value = b.LabelClass;
            cmd.Parameters.Add(ln);

            SqlParameter gsac = new SqlParameter("@fromDate", SqlDbType.DateTime);
            gsac.Value = b.fromDate;
            cmd.Parameters.Add(gsac);


            SqlParameter gsacd = new SqlParameter("@toDate", SqlDbType.DateTime);
            gsacd.Value = b.toDate;
            cmd.Parameters.Add(gsacd);


            SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
            flag.Value = b.insupddelflag;
            cmd.Parameters.Add(flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
           
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseDetails Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicenseDetails:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("api/License/GetLicenseTypes")]
        public DataTable GetLicenseTypes(int catid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseTypes credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseTypes";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@licenseCategoryId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = catid;
            cmd.Parameters.Add(Gid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseTypes Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/License/SaveLicenseType")]
        public HttpResponseMessage SaveLicenseTypes(LicenseTypes b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseTypes credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdLicenseTypes";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "@Id";
                Aid.SqlDbType = SqlDbType.Int;
                Aid.Value = Convert.ToString(b.Id);
                cmd.Parameters.Add(Aid);

                SqlParameter lid = new SqlParameter();
                lid.ParameterName = "@LicenseCatId";
                lid.SqlDbType = SqlDbType.Int;
                lid.Value = Convert.ToString(b.LicenseCategoryId);
                cmd.Parameters.Add(lid);

                SqlParameter ss = new SqlParameter();
                ss.ParameterName = "@LicenseType";
                ss.SqlDbType = SqlDbType.VarChar;
                ss.Value = b.LicenseType;
                cmd.Parameters.Add(ss);

                SqlParameter ii = new SqlParameter();
                ii.ParameterName = "@Description";
                ii.SqlDbType = SqlDbType.VarChar;
                ii.Value = b.Desc;

                cmd.Parameters.Add(ii);
                SqlParameter ll = new SqlParameter();
                ll.ParameterName = "@Active";
                ll.SqlDbType = SqlDbType.VarChar;
                ll.Value = b.Active;

                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseTypes Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicenseTypes:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }


        [HttpPost]
        [Route("api/License/SaveLicenseConfigDetails")]
        public HttpResponseMessage SaveLicenseConfigDetails(LicenseTypes b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseConfigDetails....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdLicenseConfigDetails";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "@Id";
                Aid.SqlDbType = SqlDbType.Int;
                Aid.Value = Convert.ToString(b.Id);
                cmd.Parameters.Add(Aid);

                SqlParameter lid = new SqlParameter();
                lid.ParameterName = "@LicenseCatId";
                lid.SqlDbType = SqlDbType.Int;
                lid.Value = Convert.ToString(b.LicenseCategoryId);
                cmd.Parameters.Add(lid);

                SqlParameter ss = new SqlParameter();
                ss.ParameterName = "@LicenseType";
                ss.SqlDbType = SqlDbType.VarChar;
                ss.Value = b.LicenseType;
                cmd.Parameters.Add(ss);

                SqlParameter ii = new SqlParameter();
                ii.ParameterName = "@Description";
                ii.SqlDbType = SqlDbType.VarChar;
                ii.Value = b.Desc;

                cmd.Parameters.Add(ii);
                SqlParameter ll = new SqlParameter();
                ll.ParameterName = "@Active";
                ll.SqlDbType = SqlDbType.VarChar;
                ll.Value = b.Active;

                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseConfigDetails completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicenseTypes:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("api/License/GetLicenseConfigDetails")]
        public DataTable GetLicenseConfigDetails(int licTypeId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseConfigDetails ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseConfigDetails";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@ltypeId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = licTypeId;
            cmd.Parameters.Add(Gid);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseConfigDetails completed.");

            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        [Route("api/License/GetLicenceCatergories")]
        public DataSet GetLicenceCatergories()
        {
            DataSet Tbl = new DataSet();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenceCatergories ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenceCatergories";
            cmd.Connection = conn;

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenceCatergories completed.");

            // int found = 0;
            return Tbl;
        }
    }
}

