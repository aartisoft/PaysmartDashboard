using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PaySmartDashboard.Models;

namespace SmartTicketDashboard.Controllers
{
    public class VehicleloginController : ApiController
    {

        [HttpGet]
        [Route("api/Vehiclelogin/Getvech")]

        public DataTable Getvech(int VechId)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetVechlogin";
            cmd.Connection = conn;

            cmd.Parameters.Add("@VId", SqlDbType.Int).Value = VechId;
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpPost]
        [Route("api/Vehiclelogin/vechile")]

        public DataTable vechile(Vechlogin A)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSInsUpdVechlogin";
            cmd.Connection = conn;

            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = A.flag;
            cmd.Parameters.Add(f);

            SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
            i.Value = A.Id;
            cmd.Parameters.Add(i);

            SqlParameter cc = new SqlParameter("@CompanyId", SqlDbType.Int);
            cc.Value = A.CompanyId;
            cmd.Parameters.Add(cc);

            SqlParameter CusID = new SqlParameter("@VechId", SqlDbType.Int);
            CusID.Value = A.VechId;
            cmd.Parameters.Add(CusID);

            SqlParameter PhoneNo = new SqlParameter("@RegNo", SqlDbType.NVarChar, 50);
            PhoneNo.Value = A.RegNo;
            cmd.Parameters.Add(PhoneNo);

            SqlParameter AltPhoneNo = new SqlParameter("@DriverName", SqlDbType.NVarChar, 50);
            AltPhoneNo.Value = A.DriverName;
            cmd.Parameters.Add(AltPhoneNo);

            SqlParameter Address = new SqlParameter("@LoginLandMark", SqlDbType.NVarChar, 50);
            Address.Value = A.LoginLandMark;
            cmd.Parameters.Add(Address);

            SqlParameter PickupAddress = new SqlParameter("@CurrentLandMark", SqlDbType.NVarChar, 50);
            PickupAddress.Value = A.CurrentLandMark;
            cmd.Parameters.Add(PickupAddress);

            SqlParameter LandMark = new SqlParameter("@StartKiloMtr", SqlDbType.NVarChar, 50);
            LandMark.Value = A.StartKiloMtr;
            cmd.Parameters.Add(LandMark);

            SqlParameter PickupPlace = new SqlParameter("@CurStatus", SqlDbType.NVarChar, 50);
            PickupPlace.Value = A.CurStatus;
            cmd.Parameters.Add(PickupPlace);

            SqlParameter DropPlace = new SqlParameter("@DriverMobileNo", SqlDbType.NVarChar, 255);
            DropPlace.Value = A.DriverMobileNo;
            cmd.Parameters.Add(DropPlace);

            SqlParameter ef = new SqlParameter("@ExecutiveName", SqlDbType.NVarChar, 50);
            ef.Value = A.ExecutiveName;
            cmd.Parameters.Add(ef);

            SqlParameter re = new SqlParameter("@Remarks", SqlDbType.NVarChar, 255);
            re.Value = A.Remarks;
            cmd.Parameters.Add(re);

            SqlParameter NoofVehicle = new SqlParameter("@GenratedAmount", SqlDbType.Int);
            NoofVehicle.Value = A.GenratedAmount;
            cmd.Parameters.Add(NoofVehicle);

            SqlParameter nh = new SqlParameter("@NoofTimesLogin", SqlDbType.Int);
            nh.Value = A.NoofTimesLogin;
            cmd.Parameters.Add(nh);


            SqlParameter pp = new SqlParameter("@TotalGeneratedAmount", SqlDbType.Int);
            pp.Value = A.TotalGeneratedAmount;
            cmd.Parameters.Add(pp);


            SqlParameter e = new SqlParameter("@VechType", SqlDbType.VarChar, 50);
            e.Value = A.VechType;
            cmd.Parameters.Add(e);

            SqlParameter vv = new SqlParameter("@VehicleModelId", SqlDbType.Int);
            vv.Value = A.VehicleModelId;
            cmd.Parameters.Add(vv);


            SqlParameter vf = new SqlParameter("@ServiceTypeId", SqlDbType.Int);
            vf.Value = A.ServiceTypeId;
            cmd.Parameters.Add(vf);

            SqlParameter vg = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vg.Value = A.VehicleGroupId;
            cmd.Parameters.Add(vg);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
