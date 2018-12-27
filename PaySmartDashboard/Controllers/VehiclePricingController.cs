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

namespace PaySmartDashboard.Controllers
{
    public class VehiclePricingController : ApiController
    {


        [HttpGet]
        [Route("api/VehiclePricing/GetVehiclePrices")]

        public DataTable GetVehiclePrices()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVGetTariff";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);           

            return dt;
        }


        [HttpGet]
        [Route("api/VehiclePricing/GetPricinglist")]


        public DataTable GetPricinglist(int vdpid)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVGetPricingDetails";
            cmd.Connection = conn;
            cmd.Parameters.Add("vdpid", SqlDbType.Int).Value = vdpid;
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/VehiclePricing/VehiclePrices")]

        public DataTable Vehicles(Pricing m)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdDelTariff";
            cmd.Connection = conn;

            SqlParameter s = new SqlParameter("@SrNo", SqlDbType.Int);
            s.Value = m.SrNo;
            cmd.Parameters.Add(s);

            SqlParameter i = new SqlParameter("@Duration", SqlDbType.Int);
            i.Value = m.Duration;
            cmd.Parameters.Add(i);

            SqlParameter n = new SqlParameter("@KiloMtr", SqlDbType.Int);
            n.Value = m.KiloMtr;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@IndicaRate", SqlDbType.Int);
            r.Value = m.IndicaRate;
            cmd.Parameters.Add(r);

            SqlParameter a = new SqlParameter("@IndigoRate", SqlDbType.Int);
            a.Value = m.IndigoRate;
            cmd.Parameters.Add(a);

            SqlParameter sn = new SqlParameter("@InnovaRate", SqlDbType.Int);
            sn.Value = m.InnovaRate;
            cmd.Parameters.Add(sn);

            SqlParameter f = new SqlParameter("@Tag", SqlDbType.VarChar,255);
            f.Value = m.Tag;
            cmd.Parameters.Add(f);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }


        [HttpGet]
        [Route("api/VehiclePricing/GetVehicleDistancePrices")]

        public DataTable GetVehicleDistancePrices()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetVehicleDistPrices";
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/VehiclePricing/VehicleDistanceConfig")]
        public DataTable VehicleDistanceConfig(VehicleDistancePriceConfiguration vdpc)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSInsUpdDelVehicleDistancePrice";
            cmd.Connection = conn;

            SqlParameter vdpcId = new SqlParameter("@Id", SqlDbType.Int);
            vdpcId.Value = vdpc.Id;
            cmd.Parameters.Add(vdpcId);

            SqlParameter vdpcSourceLoc = new SqlParameter("@SourceLoc", SqlDbType.VarChar);
            vdpcSourceLoc.Value = vdpc.SourceLoc;
            cmd.Parameters.Add(vdpcSourceLoc);

            SqlParameter vdpcDestinationLoc = new SqlParameter("@DestinationLoc", SqlDbType.VarChar);
            vdpcDestinationLoc.Value = vdpc.DestinationLoc;
            cmd.Parameters.Add(vdpcDestinationLoc);

            SqlParameter vdpcSourceLat = new SqlParameter("@SourceLat", SqlDbType.Float);
            vdpcSourceLat.Value = vdpc.SourceLat;
            cmd.Parameters.Add(vdpcSourceLat);

            SqlParameter vdpcSourceLng = new SqlParameter("@SourceLng", SqlDbType.Float);
            vdpcSourceLng.Value = vdpc.SourceLng;
            cmd.Parameters.Add(vdpcSourceLng);

            SqlParameter vdpcDestinationLat = new SqlParameter("@DestinationLat", SqlDbType.Float);
            vdpcDestinationLat.Value = vdpc.DestinationLat;
            cmd.Parameters.Add(vdpcDestinationLat);

            SqlParameter vdpcDestinationLng = new SqlParameter("@DestinationLng", SqlDbType.Float);
            vdpcDestinationLng.Value = vdpc.DestinationLng;
            cmd.Parameters.Add(vdpcDestinationLng);

            SqlParameter vdpcVehicleModelId = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vdpcVehicleModelId.Value = vdpc.VehicleGroupId;
            cmd.Parameters.Add(vdpcVehicleModelId);

            SqlParameter vdpcVehicleTypeId = new SqlParameter("@VehicleTypeId", SqlDbType.Int);
            vdpcVehicleTypeId.Value = vdpc.VehicleTypeId;
            cmd.Parameters.Add(vdpcVehicleTypeId);

            SqlParameter vdpcPricingTypeId = new SqlParameter("@PricingTypeId", SqlDbType.Int);
            vdpcPricingTypeId.Value = vdpc.PricingTypeId;
            cmd.Parameters.Add(vdpcPricingTypeId);

            SqlParameter vdpcDistance = new SqlParameter("@Distance", SqlDbType.Float);
            vdpcDistance.Value = vdpc.Distance;
            cmd.Parameters.Add(vdpcDistance);

            SqlParameter vdpcUnitPrice = new SqlParameter("@UnitPrice", SqlDbType.Float);
            vdpcUnitPrice.Value = vdpc.UnitPrice;
            cmd.Parameters.Add(vdpcUnitPrice);

            SqlParameter vdpcAmount = new SqlParameter("@Amount", SqlDbType.Float);
            vdpcAmount.Value = vdpc.Amount;
            cmd.Parameters.Add(vdpcAmount);

            SqlParameter ctry = new SqlParameter("@CountryId", SqlDbType.Int);
            ctry.Value = vdpc.CountryId;
            cmd.Parameters.Add(ctry);

            SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = vdpc.flag;
            cmd.Parameters.Add(flag);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
