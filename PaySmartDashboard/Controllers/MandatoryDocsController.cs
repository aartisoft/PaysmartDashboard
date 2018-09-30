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
    public class MandatoryDocsController : ApiController
    {
        [HttpGet]
        [Route("api/GetMandatoryUserDocs")]
        public DataTable GetMandUserDocs(int ctryId, int utId, int vgrpId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryUserDocs ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMandatoryUserDocs";
            cmd.Parameters.Add("@countryid", SqlDbType.Int).Value = ctryId;
            cmd.Parameters.Add("@utId", SqlDbType.Int).Value = utId;
            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vgrpId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryUserDocs completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SaveMandatoryUserDocs")]
        public DataTable SaveMandUserDocs(IEnumerable<MandUserDocs> UserDocs)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelMandatoryUserDocs";
                cmd.Connection = conn;
                conn.Open();

                foreach (MandUserDocs mud in UserDocs)
                {
                    SqlParameter flag = new SqlParameter();
                    flag.ParameterName = "@flag";
                    flag.SqlDbType = SqlDbType.VarChar;
                    flag.Value = mud.flag;
                    cmd.Parameters.Add(flag);

                    SqlParameter id = new SqlParameter();
                    id.ParameterName = "@Id";
                    id.SqlDbType = SqlDbType.Int;
                    id.Value = mud.Id;
                    cmd.Parameters.Add(id);

                    SqlParameter DocTId = new SqlParameter();
                    DocTId.ParameterName = "@DocTypeId";
                    DocTId.SqlDbType = SqlDbType.Int;
                    DocTId.Value = mud.DocTypeId;
                    cmd.Parameters.Add(DocTId);

                    SqlParameter FileCont = new SqlParameter();
                    FileCont.ParameterName = "@FileContent";
                    FileCont.SqlDbType = SqlDbType.VarChar;
                    FileCont.Value = mud.FileContent;
                    cmd.Parameters.Add(FileCont);

                    SqlParameter isMand = new SqlParameter();
                    isMand.ParameterName = "@IsMandatory";
                    isMand.SqlDbType = SqlDbType.Int;
                    isMand.Value = mud.IsMandatory;
                    cmd.Parameters.Add(isMand);

                    SqlParameter ctrid = new SqlParameter();
                    ctrid.ParameterName = "@Countryid";
                    ctrid.SqlDbType = SqlDbType.Int;
                    ctrid.Value = mud.Countryid;
                    cmd.Parameters.Add(ctrid);

                    SqlParameter ustid = new SqlParameter();
                    ustid.ParameterName = "@UserTypeId";
                    ustid.SqlDbType = SqlDbType.Int;
                    ustid.Value = mud.UserTypeId;
                    cmd.Parameters.Add(ustid);

                    SqlParameter vgrpId = new SqlParameter();
                    vgrpId.ParameterName = "@VehicleGroupId";
                    vgrpId.SqlDbType = SqlDbType.Int;
                    vgrpId.Value = mud.VehicleGroupId;
                    cmd.Parameters.Add(vgrpId);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandUserDocs  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandUserDocs:" + ex.Message);
                throw ex;
            }
            return dt;
        }

        [HttpGet]
        [Route("api/GetMandatoryVehicleDocs")]
        public DataTable GetMandVehicleDocs(int ctryId, int vgId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryVehicleDocs ....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMandatoryVehicleDocs";
            cmd.Parameters.Add("@countryid", SqlDbType.Int).Value = ctryId;
            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vgId;
            cmd.Connection = conn;

            //DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            //Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetMandatoryVehicleDocs completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/SaveMandatoryVehicleDocs")]
        public DataTable SaveMandVehicleDocs(IEnumerable<MandVehicleDocs> VehicleDocs)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandVehicleDocs ...");

            //connect to database
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelMandatoryVehicleDocs";
                cmd.Connection = conn;
                conn.Open();


                foreach (MandVehicleDocs mvd in VehicleDocs)
                {
                    SqlParameter flag = new SqlParameter();
                    flag.ParameterName = "@flag";
                    flag.SqlDbType = SqlDbType.VarChar;
                    flag.Value = mvd.flag;
                    cmd.Parameters.Add(flag);

                    SqlParameter id = new SqlParameter();
                    id.ParameterName = "@Id";
                    id.SqlDbType = SqlDbType.Int;
                    id.Value = mvd.Id;
                    cmd.Parameters.Add(id);

                    SqlParameter DocTId = new SqlParameter();
                    DocTId.ParameterName = "@DocTypeId";
                    DocTId.SqlDbType = SqlDbType.Int;
                    DocTId.Value = mvd.DocTypeId;
                    cmd.Parameters.Add(DocTId);

                    SqlParameter FileCont = new SqlParameter();
                    FileCont.ParameterName = "@FileContent";
                    FileCont.SqlDbType = SqlDbType.VarChar;
                    FileCont.Value = mvd.FileContent;
                    cmd.Parameters.Add(FileCont);

                    SqlParameter isMand = new SqlParameter();
                    isMand.ParameterName = "@IsMandatory";
                    isMand.SqlDbType = SqlDbType.Int;
                    isMand.Value = mvd.IsMandatory;
                    cmd.Parameters.Add(isMand);

                    SqlParameter ctrid = new SqlParameter();
                    ctrid.ParameterName = "@Countryid";
                    ctrid.SqlDbType = SqlDbType.Int;
                    ctrid.Value = mvd.Countryid;
                    cmd.Parameters.Add(ctrid);

                    SqlParameter vgrid = new SqlParameter();
                    vgrid.ParameterName = "@VehicleGroupId";
                    vgrid.SqlDbType = SqlDbType.Int;
                    vgrid.Value = mvd.VehicleGroupId;
                    cmd.Parameters.Add(vgrid);
                    //DataSet ds = new DataSet();
                    //SqlDataAdapter db = new SqlDataAdapter(cmd);
                    //db.Fill(ds);
                    // Tbl = Tables[0];
                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveMandVehiclerDocs  completed.");

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveMandVehicleDocs:" + ex.Message);
                throw ex;
            }
            return dt;
        }
    }
}
