using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaySmartDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class StartReportController : ApiController
    {

        [HttpGet]
        [Route("api/StartReport/GetStatus")]

        public DataTable GetStatus()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVGetreport";
            cmd.Connection = conn;

           

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }

        [HttpPost]
        [Route("api/StartReport/Startingreport")]

        public DataTable Startingreport(start s)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdDelreport";
            cmd.Connection = conn;


            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = s.flag;
            cmd.Parameters.Add(f);

            SqlParameter i = new SqlParameter("@SlNo", SqlDbType.Int);
            i.Value = s.SlNo;
            cmd.Parameters.Add(i);
           
            SqlParameter E = new SqlParameter("@EntryDate", SqlDbType.Date);
            E.Value = s.EntryDate;
            cmd.Parameters.Add(E);

            SqlParameter d = new SqlParameter("@VechID", SqlDbType.Int);
            d.Value = s.VechID;
            cmd.Parameters.Add(d);

            SqlParameter r = new SqlParameter("@RegistrationNo", SqlDbType.NVarChar,255);
            r.Value = s.RegistrationNo;
            cmd.Parameters.Add(r);

            SqlParameter dd = new SqlParameter("@DriverName", SqlDbType.NVarChar, 255);
            dd.Value = s.DriverName;
            cmd.Parameters.Add(dd);

            SqlParameter p = new SqlParameter("@PartyName", SqlDbType.NVarChar,255);
            p.Value = s.PartyName;
            cmd.Parameters.Add(p);

            SqlParameter po = new SqlParameter("@PickupPlace", SqlDbType.NVarChar,255);
            po.Value = s.PickupPlace;
            cmd.Parameters.Add(po);

            SqlParameter de = new SqlParameter("@DropPlace", SqlDbType.NVarChar,255);
            de.Value = s.DropPlace;
            cmd.Parameters.Add(de);

            SqlParameter pp = new SqlParameter("@StartMeter", SqlDbType.Int);
            pp.Value = s.StartMeter;
            cmd.Parameters.Add(pp);

            SqlParameter d1 = new SqlParameter("@PickupTime", SqlDbType.DateTime);
            d1.Value = s.PickupTime;
            cmd.Parameters.Add(d1);

            SqlParameter e = new SqlParameter("@ExecutiveName", SqlDbType.NVarChar,255);
            e.Value = s.ExecutiveName;
            cmd.Parameters.Add(e);

            SqlParameter bb = new SqlParameter("@BookingNo", SqlDbType.Decimal);
            bb.Value = s.BookingNo;
            cmd.Parameters.Add(bb);

            SqlParameter ee = new SqlParameter("@EntryTime", SqlDbType.DateTime);
            ee.Value = s.EntryTime;
            cmd.Parameters.Add(ee);

            SqlParameter cc = new SqlParameter("@CloseStatus", SqlDbType.NVarChar,255);
            cc.Value = s.CloseStatus;
            cmd.Parameters.Add(cc);      



            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

    }
}
