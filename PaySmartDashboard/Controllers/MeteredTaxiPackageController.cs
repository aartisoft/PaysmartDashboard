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
    public class MeteredTaxiPackageController : ApiController
    {
        [Route("api/MeteredTaxiPackage/GetMeteredTaxiPackage")]
        public DataTable GetMeteredTaxiPackage()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMeteredTaxiPackages";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/MeteredTaxiPackage/GetMeteredTaxiPackagePricing")]
        public DataTable GetMeteredTaxiPackagePricing()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetMeteredTaxiPackagePricing";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/MeteredTaxiPackage/SaveMeteredTaxiPackages")]
        public DataTable SaveMeteredTaxiPackages(MeteredTaxiPackages mt)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelMeteredTaxiPackages";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(mt.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(mt.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PackageName";
            Title.SqlDbType = SqlDbType.VarChar;
            Title.Value = Convert.ToString(mt.PackageName);
            cmd.Parameters.Add(Title);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(mt.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@OpId";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(mt.OpId);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(mt.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(mt.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(mt.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

        [Route("api/MeteredTaxiPackage/SaveMeteredTaxiPackagePricing")]
        public DataTable SaveMeteredTaxiPackagePricing(MeteredTaxiPackagePricing mtp)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelMeteredTaxiPackagePricing";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(mtp.Id);
            cmd.Parameters.Add(Id);


            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PkgId";
            Title.SqlDbType = SqlDbType.Int;
            Title.Value = Convert.ToString(mtp.PackageId);
            cmd.Parameters.Add(Title);

            SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@Source";
            Value.SqlDbType = SqlDbType.VarChar;
            Value.Value = Convert.ToString(mtp.Source);
            cmd.Parameters.Add(Value);

            SqlParameter SrcStopId = new SqlParameter();
            SrcStopId.ParameterName = "@Destination";
            SrcStopId.SqlDbType = SqlDbType.VarChar;
            SrcStopId.Value = Convert.ToString(mtp.Destination);
            cmd.Parameters.Add(SrcStopId);

            SqlParameter DeststopId = new SqlParameter();
            DeststopId.ParameterName = "@Srclat";
            DeststopId.SqlDbType = SqlDbType.Decimal;
            DeststopId.Value = Convert.ToString(mtp.Srclat);
            cmd.Parameters.Add(DeststopId);

            SqlParameter Srclong = new SqlParameter();
            Srclong.ParameterName = "@Srclong";
            Srclong.SqlDbType = SqlDbType.Decimal;
            Srclong.Value = Convert.ToString(mtp.Srclong);
            cmd.Parameters.Add(Srclong);

            SqlParameter Destlat = new SqlParameter();
            Destlat.ParameterName = "@Destlat";
            Destlat.SqlDbType = SqlDbType.Decimal;
            Destlat.Value = Convert.ToString(mtp.Destlat);
            cmd.Parameters.Add(DeststopId);

            SqlParameter Destlong = new SqlParameter();
            Destlong.ParameterName = "@Destlong";
            Destlong.SqlDbType = SqlDbType.Decimal;
            Destlong.Value = Convert.ToString(mtp.Destlong);
            cmd.Parameters.Add(Destlong);

            SqlParameter dist = new SqlParameter();
            dist.ParameterName = "@Distance";
            dist.SqlDbType = SqlDbType.Decimal;
            dist.Value = Convert.ToString(mtp.Distance);
            cmd.Parameters.Add(dist);

            SqlParameter PricingTypeId = new SqlParameter();
            PricingTypeId.ParameterName = "@PricingTypeId";
            PricingTypeId.SqlDbType = SqlDbType.Int;
            PricingTypeId.Value = Convert.ToString(mtp.PricingTypeId);
            cmd.Parameters.Add(PricingTypeId);

            SqlParameter UnitTypeId = new SqlParameter();
            UnitTypeId.ParameterName = "@UnitTypeId";
            UnitTypeId.SqlDbType = SqlDbType.Int;
            UnitTypeId.Value = Convert.ToString(mtp.UnitTypeId);
            cmd.Parameters.Add(UnitTypeId);

            SqlParameter UnitPrice = new SqlParameter();
            UnitPrice.ParameterName = "@UnitPrice";
            UnitPrice.SqlDbType = SqlDbType.Decimal;
            UnitPrice.Value = Convert.ToString(mtp.UnitPrice);
            cmd.Parameters.Add(UnitPrice);

            SqlParameter Amount = new SqlParameter();
            Amount.ParameterName = "@Amount";
            Amount.SqlDbType = SqlDbType.Decimal;
            Amount.Value = Convert.ToString(mtp.Amount);
            cmd.Parameters.Add(Amount);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(mtp.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(mtp.Description);
            cmd.Parameters.Add(Description);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@VehicleGroupId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(mtp.VehicleGroupId);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@VehicleTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(mtp.VehicleTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter UnitId = new SqlParameter();
            UnitId.ParameterName = "@UnitId";
            UnitId.SqlDbType = SqlDbType.Int;
            UnitId.Value = Convert.ToString(mtp.UnitId);
            cmd.Parameters.Add(UnitId);

            SqlParameter FromValue = new SqlParameter();
            FromValue.ParameterName = "@FromValue";
            FromValue.SqlDbType = SqlDbType.Int;
            FromValue.Value = Convert.ToString(mtp.FromValue);
            cmd.Parameters.Add(FromValue);

            SqlParameter ToValue = new SqlParameter();
            ToValue.ParameterName = "@ToValue";
            ToValue.SqlDbType = SqlDbType.Int;
            ToValue.Value = Convert.ToString(mtp.ToValue);
            cmd.Parameters.Add(ToValue);

            SqlParameter EffectiveDate = new SqlParameter();
            EffectiveDate.ParameterName = "@EffectiveDate";
            EffectiveDate.SqlDbType = SqlDbType.DateTime;
            EffectiveDate.Value = Convert.ToString(mtp.EffectiveDate);
            cmd.Parameters.Add(EffectiveDate);

            SqlParameter ExpiryDate = new SqlParameter();
            ExpiryDate.ParameterName = "@ExpiryDate";
            ExpiryDate.SqlDbType = SqlDbType.DateTime;
            ExpiryDate.Value = Convert.ToString(mtp.ExpiryDate);
            cmd.Parameters.Add(ExpiryDate);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(mtp.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }
    }
}
