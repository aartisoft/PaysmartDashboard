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
    public class VehicleLogoutController : ApiController
    {

        [HttpGet]
        [Route("api/VehicleLogout/Getvechout")]

        public DataTable Getvechout(int VechId)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetVechlogout";
            cmd.Connection = conn;

            cmd.Parameters.Add("@VechID", SqlDbType.Int).Value = VechId;
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpPost]
        [Route("api/VehicleLogout/vechileout")]

        public DataTable vechileout(Vechlogin c)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSInsUpdVechlogout";
            cmd.Connection = conn;

            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = c.flag;
            cmd.Parameters.Add(f);

            SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
            i.Value = c.Id;
            cmd.Parameters.Add(i);

            SqlParameter cc = new SqlParameter("@CompanyId", SqlDbType.Int);
            cc.Value = c.CompanyId;
            cmd.Parameters.Add(cc);


            SqlParameter CusID = new SqlParameter("@VechId", SqlDbType.Int);
            CusID.Value = c.VechId;
            cmd.Parameters.Add(CusID);

            SqlParameter PhoneNo = new SqlParameter("@RegNo", SqlDbType.NVarChar, 255);
            PhoneNo.Value = c.RegNo;
            cmd.Parameters.Add(PhoneNo);

            SqlParameter AltPhoneNo = new SqlParameter("@DriverName", SqlDbType.NVarChar, 255);
            AltPhoneNo.Value = c.DriverName;
            cmd.Parameters.Add(AltPhoneNo);

            SqlParameter Address = new SqlParameter("@LoginLandMark", SqlDbType.NVarChar, 50);
            Address.Value = c.LoginLandMark;
            cmd.Parameters.Add(Address);

            SqlParameter PickupAddress = new SqlParameter("@CurrentLandMark", SqlDbType.NVarChar, 50);
            PickupAddress.Value = c.CurrentLandMark;
            cmd.Parameters.Add(PickupAddress);

            SqlParameter LandMark = new SqlParameter("@EndMtr", SqlDbType.NVarChar, 255);
            LandMark.Value = c.EndMtr;
            cmd.Parameters.Add(LandMark);

            SqlParameter PickupPlace = new SqlParameter("@CurStatus", SqlDbType.NVarChar, 255);
            PickupPlace.Value = c.CurStatus;
            cmd.Parameters.Add(PickupPlace);

            SqlParameter DropPlace = new SqlParameter("@DriverMobileNo", SqlDbType.NVarChar, 255);
            DropPlace.Value = c.DriverMobileNo;
            cmd.Parameters.Add(DropPlace);

            SqlParameter ef = new SqlParameter("@ExecutiveName", SqlDbType.NVarChar, 255);
            ef.Value = c.ExecutiveName;
            cmd.Parameters.Add(ef);

            SqlParameter re = new SqlParameter("@Remarks", SqlDbType.NVarChar, 255);
            re.Value = c.Remarks;
            cmd.Parameters.Add(re);

            SqlParameter NoofVehicle = new SqlParameter("@GenratedAmount", SqlDbType.Int);
            NoofVehicle.Value = c.GenratedAmount;
            cmd.Parameters.Add(NoofVehicle);

            SqlParameter nh = new SqlParameter("@NoofTimesLogin", SqlDbType.Int);
            nh.Value = c.NoofTimesLogin;
            cmd.Parameters.Add(nh);

            SqlParameter pp = new SqlParameter("@TotalGeneratedAmount", SqlDbType.NVarChar, 255);
            pp.Value = c.TotalGeneratedAmount;
            cmd.Parameters.Add(pp);

            SqlParameter e = new SqlParameter("@VechType", SqlDbType.VarChar, 50);
            e.Value = c.VechType;
            cmd.Parameters.Add(e);




            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
