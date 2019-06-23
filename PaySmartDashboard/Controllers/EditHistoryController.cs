using PaySmartDashboard;
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
    public class EditHistoryController : ApiController
    {
           [HttpGet]
        public DataTable GetEditHistory(string Task)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistory credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getEditHistory";
            cmd.Connection = conn;
            cmd.Parameters.Add("@Task", SqlDbType.VarChar).Value = Task;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistory Credentials completed.");
            // int found = 0;
            return Tbl;

        }

           [HttpGet]
           [Route("api/EditHistory/GetHistoryTasks")]
           public DataTable GetHistoryTasks()
           {
               DataTable Tbl = new DataTable();

               LogTraceWriter traceWriter = new LogTraceWriter();
               traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistory credentials....");
               //connect to database
               SqlConnection conn = new SqlConnection();
               //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
               conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

               SqlCommand cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "GetEditHistoryTasks";
               cmd.Connection = conn;
               
               DataSet ds = new DataSet();
               SqlDataAdapter db = new SqlDataAdapter(cmd);
               db.Fill(ds);
               Tbl = ds.Tables[0];
               traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistory Credentials completed.");
               // int found = 0;
               return Tbl;

           }
    }
}
   