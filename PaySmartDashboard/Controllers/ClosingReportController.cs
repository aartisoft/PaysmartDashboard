using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class ClosingReportController : ApiController
    {
        [HttpGet]

        [Route("api/ClosingReport/GetReports")]
        public DataTable GetReports()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetClosingReport";
            
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpPost]
        [Route("api/ClosingReport/closerprt")]

        public DataTable closerprt(close d)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdDelClosingReport";
            cmd.Connection = conn;


            SqlParameter nn = new SqlParameter("@flag", SqlDbType.VarChar);
            nn.Value = d.flag;
            cmd.Parameters.Add(nn);

            SqlParameter n = new SqlParameter("@SlNo", SqlDbType.Int);
            n.Value = d.SlNo;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@EntryDate", SqlDbType.Date);
            r.Value = d.EntryDate;
            cmd.Parameters.Add(r);

            SqlParameter a = new SqlParameter("@VechID", SqlDbType.Int);
            a.Value = d.VechID;
            cmd.Parameters.Add(a);

            SqlParameter s = new SqlParameter("@RegistrationNo", SqlDbType.NVarChar,255);
            s.Value = d.RegistrationNo;
            cmd.Parameters.Add(s);

            SqlParameter f = new SqlParameter("@DriverName", SqlDbType.NVarChar, 255);
            f.Value = d.DriverName;
            cmd.Parameters.Add(f);

            SqlParameter j2 = new SqlParameter("@PartyName", SqlDbType.NVarChar, 255);
            j2.Value = d.PartyName;
            cmd.Parameters.Add(j2);

            SqlParameter g = new SqlParameter("@PickupPlace", SqlDbType.NVarChar, 255);
            g.Value = d.PickupPlace;
            cmd.Parameters.Add(g);

            SqlParameter h = new SqlParameter("@DropPlace", SqlDbType.NVarChar, 255);
            h.Value = d.DropPlace;
            cmd.Parameters.Add(h);

            SqlParameter j = new SqlParameter("@StartMeter", SqlDbType.Int);
            j.Value = d.StartMeter;
            cmd.Parameters.Add(j);

            SqlParameter k = new SqlParameter("@EndMeter", SqlDbType.Int);
            k.Value = d.EndMeter;
            cmd.Parameters.Add(k);

            SqlParameter y = new SqlParameter("@OtherExp", SqlDbType.Int);
            y.Value = d.OtherExp;
            cmd.Parameters.Add(y);

            SqlParameter rj = new SqlParameter("@GeneratedAmount", SqlDbType.Int);
            rj.Value = d.GeneratedAmount;
            cmd.Parameters.Add(rj);

            SqlParameter t = new SqlParameter("@ActualAmount", SqlDbType.Int);
            t.Value = d.ActualAmount;
            cmd.Parameters.Add(t);

            SqlParameter u = new SqlParameter("@ExecutiveName", SqlDbType.NVarChar, 255);
            u.Value = d.ExecutiveName;
            cmd.Parameters.Add(u);

            SqlParameter o = new SqlParameter("@BNo", SqlDbType.Decimal);
            o.Value = d.BNo;
            cmd.Parameters.Add(o);

            SqlParameter p = new SqlParameter("@DropTime", SqlDbType.DateTime);
            p.Value = d.DropTime;
            cmd.Parameters.Add(p);

            SqlParameter w = new SqlParameter("@PickupTime", SqlDbType.DateTime);
            w.Value = d.PickupTime;
            cmd.Parameters.Add(w);


            SqlParameter ws = new SqlParameter("@EntryTime", SqlDbType.DateTime);
            ws.Value = d.EntryTime;
            cmd.Parameters.Add(ws);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
