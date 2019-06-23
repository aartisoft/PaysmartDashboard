
using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class VehicleDistPricingController : ApiController
    {
        [HttpGet]
        [Route("api/VehicleDistPricing/GetDistanceBasePricing")]
        public DataTable GetDistanceBasePricing(int ctryId,int vgId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetDistanceBasePricing";
            cmd.Connection = conn;
            cmd.Parameters.Add("@ctryId", SqlDbType.Int).Value = ctryId;
            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vgId;
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);



            // int found = 0;
            return Tbl;

        }

        [HttpPost]
        [Route("api/VehicleDistPricing/SaveVehicleDistPricing")]
        public DataTable SaveVehicleDistPricing(VehicleDist v)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSInsUpdDelDistanceBasePricing";

            cmd.Connection = conn;

            SqlParameter insupddelflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar, 10);
            insupddelflag.Value = v.insupddelflag;
            cmd.Parameters.Add(insupddelflag);

            SqlParameter q = new SqlParameter("@Id", SqlDbType.Int);
            q.Value = v.Id;
            cmd.Parameters.Add(q);

            SqlParameter q1 = new SqlParameter("@VehicleTypeId", SqlDbType.Int);
            q1.Value = v.VehicleTypeId;
            cmd.Parameters.Add(q1);

            SqlParameter e = new SqlParameter("@Fromkm", SqlDbType.Int);
            e.Value = v.FromKm;
            cmd.Parameters.Add(e);

            SqlParameter t = new SqlParameter("@ToKm", SqlDbType.Int);
            t.Value = v.ToKm;
            cmd.Parameters.Add(t);

            SqlParameter c1 = new SqlParameter("@PricingType", SqlDbType.Int);
            c1.Value = v.PricingType;
            cmd.Parameters.Add(c1);

            SqlParameter ft = new SqlParameter("@Fromdate", SqlDbType.DateTime);
            ft.Value = v.FromDate;
            cmd.Parameters.Add(ft);

            SqlParameter tf = new SqlParameter("@Todate", SqlDbType.DateTime);
            tf.Value = v.ToDate;
            cmd.Parameters.Add(tf);


            SqlParameter cd = new SqlParameter("@Createdby", SqlDbType.Int);
            cd.Value = v.CreatedBy;
            cmd.Parameters.Add(cd);

            SqlParameter up = new SqlParameter("@Amount", SqlDbType.Decimal);
            up.Value = v.Amount;
            cmd.Parameters.Add(up);

            SqlParameter uo = new SqlParameter("@PerUnitPrice", SqlDbType.Decimal);
            uo.Value = v.PerUnitPrice;
            cmd.Parameters.Add(uo);

            SqlParameter cc = new SqlParameter("@CountryId", SqlDbType.Int);
            cc.Value = v.CountryId;
            cmd.Parameters.Add(cc);

            SqlParameter vc = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vc.Value = v.VehicleGroupId;
            cmd.Parameters.Add(vc);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return (dt);



        }
    }
}
