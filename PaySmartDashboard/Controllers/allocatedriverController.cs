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

namespace PaySmartDashboard.Controllers
{


    public class allocatedriverController : ApiController
    {

        [HttpGet]
        [Route("api/allocatedriver/GetAssigndetails")]

        public DataTable GetAssigndetails(int VechId)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetAssigndetails";
            cmd.Connection = conn;

            
            cmd.Parameters.Add("@VechID", SqlDbType.Int).Value = VechId;
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }

        [HttpGet]
        [Route("api/allocatedriver/Getallocatedriver")]

        public DataTable Getallocatedriver(int VID)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVGetallocatedriver";
            cmd.Connection = conn;
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;

            
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }
        [HttpPost]
        [Route("api/allocatedriver/AllocateDriver")]

        public DataTable drivers(allocatedriver A)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {


                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSInsUpdallocatedriver";
                cmd.Connection = conn;

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = A.flag;
                cmd.Parameters.Add(f);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = A.Id;
                cmd.Parameters.Add(i);

                SqlParameter dd = new SqlParameter("@CompanyId", SqlDbType.Int);
                dd.Value = A.CompanyId;
                cmd.Parameters.Add(dd);

                SqlParameter BookingNo = new SqlParameter("@BookingNo", SqlDbType.Int);
                BookingNo.Value = A.BookingNo;
                cmd.Parameters.Add(BookingNo);



                SqlParameter CustomerName = new SqlParameter("@CustomerName", SqlDbType.NVarChar, 255);
                CustomerName.Value = A.CustomerName;
                cmd.Parameters.Add(CustomerName);

                SqlParameter CusID = new SqlParameter("@CusID", SqlDbType.NVarChar, 255);
                CusID.Value = A.CusID;
                cmd.Parameters.Add(CusID);

                SqlParameter PhoneNo = new SqlParameter("@PhoneNo", SqlDbType.NVarChar, 255);
                PhoneNo.Value = A.PhoneNo;
                cmd.Parameters.Add(PhoneNo);

                SqlParameter AltPhoneNo = new SqlParameter("@AltPhoneNo", SqlDbType.NVarChar, 255);
                AltPhoneNo.Value = A.AltPhoneNo;
                cmd.Parameters.Add(AltPhoneNo);

                SqlParameter Address = new SqlParameter("@Address", SqlDbType.NVarChar, Max);
                Address.Value = A.Address;
                cmd.Parameters.Add(Address);

                SqlParameter PickupAddress = new SqlParameter("@PickupAddress", SqlDbType.NVarChar, Max);
                PickupAddress.Value = A.PickupAddress;
                cmd.Parameters.Add(PickupAddress);

                SqlParameter LandMark = new SqlParameter("@LandMark", SqlDbType.NVarChar, 255);
                LandMark.Value = A.LandMark;
                cmd.Parameters.Add(LandMark);

                SqlParameter PickupPlace = new SqlParameter("@PickupPlace", SqlDbType.NVarChar, 255);
                PickupPlace.Value = A.PickupPlace;
                cmd.Parameters.Add(PickupPlace);

                SqlParameter DropPlace = new SqlParameter("@DropPlace", SqlDbType.NVarChar, 255);
                DropPlace.Value = A.DropPlace;
                cmd.Parameters.Add(DropPlace);

                SqlParameter Package = new SqlParameter("@Package", SqlDbType.NVarChar, 255);
                Package.Value = A.Package;
                cmd.Parameters.Add(Package);

                SqlParameter VehicleType = new SqlParameter("@VehicleType", SqlDbType.NVarChar, 255);
                VehicleType.Value = A.VehicleType;
                cmd.Parameters.Add(VehicleType);

                SqlParameter NoofVehicle = new SqlParameter("@NoofVehicle", SqlDbType.Int);
                NoofVehicle.Value = A.NoofVehicle;
                cmd.Parameters.Add(NoofVehicle);

                SqlParameter VechID = new SqlParameter("@VechID", SqlDbType.Int);
                VechID.Value = A.VechID;
                cmd.Parameters.Add(VechID);

                SqlParameter RegistrationNo = new SqlParameter("@RegistrationNo", SqlDbType.NVarChar, 255);
                RegistrationNo.Value = A.RegistrationNo;
                cmd.Parameters.Add(RegistrationNo);

                SqlParameter DriverName = new SqlParameter("@DriverName", SqlDbType.NVarChar, 255);
                DriverName.Value = A.DriverName;
                cmd.Parameters.Add(DriverName);

                SqlParameter Did = new SqlParameter("@DriverId", SqlDbType.Int);
                Did.Value = A.DriverId;
                cmd.Parameters.Add(Did);

                SqlParameter PresentDriverLandMark = new SqlParameter("@PresentDriverLandMark", SqlDbType.NVarChar, 255);
                PresentDriverLandMark.Value = A.PresentDriverLandMark;
                cmd.Parameters.Add(PresentDriverLandMark);

                SqlParameter ExecutiveName = new SqlParameter("@ExecutiveName", SqlDbType.NVarChar, 255);
                ExecutiveName.Value = A.ExecutiveName;
                cmd.Parameters.Add(ExecutiveName);

                SqlParameter ed = new SqlParameter("@EffectiveDate", SqlDbType.Date);
                ed.Value = A.EffectiveDate;
                cmd.Parameters.Add(ed);

                SqlParameter de = new SqlParameter("@EffectiveTill", SqlDbType.Date);
                de.Value = A.EffectiveTill;
                cmd.Parameters.Add(de);

                SqlParameter vv = new SqlParameter("@VehicleModelId", SqlDbType.VarChar);
                vv.Value = A.VehicleModelId;
                cmd.Parameters.Add(vv);


                SqlParameter vf = new SqlParameter("@ServiceTypeId", SqlDbType.VarChar);
                vf.Value = A.ServiceTypeId;
                cmd.Parameters.Add(vf);

                SqlParameter vg = new SqlParameter("@VehicleGroupId", SqlDbType.VarChar);
                vg.Value = A.VehicleGroupId;
                cmd.Parameters.Add(vg);

            }
            catch
            {
                Exception ex;
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpGet]
        [Route("api/allocatedriver/AvailableVDList")]

        public DataSet AvailableVDList(int vGroupId)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAvailableVDList";
            cmd.Connection = conn;

            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vGroupId;


            DataSet dt = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }

        [HttpGet]
        [Route("api/allocatedriver/AvailableDrivers")]

        public DataTable AvailableDrivers(int vGroupId, int notassigned)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetdrivermaster";
            cmd.Connection = conn;
                        
            cmd.Parameters.Add("@DId", SqlDbType.Int).Value = -1;
            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vGroupId;
            cmd.Parameters.Add("@notassigned", SqlDbType.Int).Value = notassigned;

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;

        }


        public int Max { get; set; }
    }

}
