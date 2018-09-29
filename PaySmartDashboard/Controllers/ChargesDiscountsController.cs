using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
namespace PaySmartDashboard.Controllers
{
    public class ChargesDiscountsController : ApiController
    {
        [Route("api/ChargesDiscounts/GetAllChargesDiscounts")]
        public DataTable GetAllChargesDiscounts ()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetChargesDiscounts";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/ChargesDiscounts/GetPackageCharges")]
        public DataTable GetPackageCharges()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPackageCharges";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/ChargesDiscounts/GetPackageDiscounts")]
        public DataTable GetPackageDiscounts()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPackageDiscounts";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }

        [Route("api/ChargesDiscounts/GetPromotionalDiscount")]
        public DataTable GetPromotionalDiscount()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPromotionalDiscounts";
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);

            return dt;
        }


        [Route("api/ChargesDiscounts/SaveChargesDiscounts")]
        public DataTable SaveChargesDiscounts(ChargesDiscounts cd)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelChargesDiscounts";

                SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(cd.Id);
            cmd.Parameters.Add(Id);

               SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(cd.Code);
            cmd.Parameters.Add(Code);

              SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@Title";
            Title.SqlDbType = SqlDbType.VarChar;
            Title.Value = Convert.ToString(cd.Title);
            cmd.Parameters.Add(Title);
           
            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@Description";
            Description.SqlDbType = SqlDbType.VarChar;
            Description.Value = Convert.ToString(cd.Description);
            cmd.Parameters.Add(Description);

             SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@TypeId";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(cd.cdTypeId);
            cmd.Parameters.Add(Type);

             SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@CategoryId";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(cd.CategoryId);
            cmd.Parameters.Add(Category);

             SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@ApplyAsId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(cd.ApplyAsId);
            cmd.Parameters.Add(ApplyAs);

             SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@Value";
            Value.SqlDbType = SqlDbType.Decimal;
            Value.Value = Convert.ToString(cd.cdValue);
            cmd.Parameters.Add(Value);

             SqlParameter FromDate = new SqlParameter();
            FromDate.ParameterName = "@FromDate";
            FromDate.SqlDbType = SqlDbType.Date;
            FromDate.Value = Convert.ToString(cd.FromDate);
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.ParameterName = "@ToDate";
            ToDate.SqlDbType = SqlDbType.Date;
            ToDate.Value = Convert.ToString(cd.ToDate);
            cmd.Parameters.Add(ToDate);

             SqlParameter Flag  = new SqlParameter();
            Flag .ParameterName = "@Flag ";
            Flag .SqlDbType = SqlDbType.VarChar;
            Flag .Value = Convert.ToString(cd.Flag );
            cmd.Parameters.Add(Flag );

           
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

        [Route("api/ChargesDiscounts/SavePackageCharges")]
        public DataTable SavePackageCharges(PackageCharges pc)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelPackageCharges";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(pc.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(pc.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PackageId";
            Title.SqlDbType = SqlDbType.Int;
            Title.Value = Convert.ToString(pc.PackageId);
            cmd.Parameters.Add(Title);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@TypeId";
            Description.SqlDbType = SqlDbType.Int;
            Description.Value = Convert.ToString(pc.TypeId);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@ApplyOn";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(pc.ApplyOn);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@Value";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(pc.Value);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@UnitTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(pc.UnitTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@UnitId";
            Value.SqlDbType = SqlDbType.Int;
            Value.Value = Convert.ToString(pc.UnitId);
            cmd.Parameters.Add(Value);

            SqlParameter FromDate = new SqlParameter();
            FromDate.ParameterName = "@FromValue";
            FromDate.SqlDbType = SqlDbType.Int;
            FromDate.Value = Convert.ToString(pc.FromValue);
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.ParameterName = "@ToValue";
            ToDate.SqlDbType = SqlDbType.Int;
            ToDate.Value = Convert.ToString(pc.ToValue);
            cmd.Parameters.Add(ToDate);

            SqlParameter EffectiveDate = new SqlParameter();
            EffectiveDate.ParameterName = "@EffectiveDate";
            EffectiveDate.SqlDbType = SqlDbType.DateTime;
            EffectiveDate.Value = Convert.ToString(pc.EffectiveDate);
            cmd.Parameters.Add(EffectiveDate);

            SqlParameter ExpiryDate = new SqlParameter();
            ExpiryDate.ParameterName = "@ExpiryDate";
            ExpiryDate.SqlDbType = SqlDbType.DateTime;
            ExpiryDate.Value = Convert.ToString(pc.ExpiryDate);
            cmd.Parameters.Add(ExpiryDate);

            SqlParameter ChargeTy = new SqlParameter();
            ChargeTy.ParameterName = "@ChargeTypeId";
            ChargeTy.SqlDbType = SqlDbType.Int;
            ChargeTy.Value = Convert.ToString(pc.ChargeTypeId);
            cmd.Parameters.Add(ChargeTy);

            SqlParameter ChargeCode = new SqlParameter();
            ChargeCode.ParameterName = "@ChargeCode";
            ChargeCode.SqlDbType = SqlDbType.VarChar;
            ChargeCode.Value = Convert.ToString(pc.ChargeCode);
            cmd.Parameters.Add(ChargeCode);

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(pc.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }


        [Route("api/ChargesDiscounts/SavePackageDiscounts")]
        public DataTable SavePackageDiscounts(PackageDiscount dc)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelPackageDiscounts";            

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(dc.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@Code";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(dc.Code);
            cmd.Parameters.Add(Code);

            SqlParameter Title = new SqlParameter();
            Title.ParameterName = "@PackageId";
            Title.SqlDbType = SqlDbType.Int;
            Title.Value = Convert.ToString(dc.PackageId);
            cmd.Parameters.Add(Title);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@TypeId";
            Description.SqlDbType = SqlDbType.Int;
            Description.Value = Convert.ToString(dc.TypeId);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@ApplyOn";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(dc.ApplyOn);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@Value";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(dc.Value);
            cmd.Parameters.Add(Category);

            SqlParameter ApplyAs = new SqlParameter();
            ApplyAs.ParameterName = "@UnitTypeId";
            ApplyAs.SqlDbType = SqlDbType.Int;
            ApplyAs.Value = Convert.ToString(dc.UnitTypeId);
            cmd.Parameters.Add(ApplyAs);

            SqlParameter Value = new SqlParameter();
            Value.ParameterName = "@UnitId";
            Value.SqlDbType = SqlDbType.Int;
            Value.Value = Convert.ToString(dc.UnitId);
            cmd.Parameters.Add(Value);          

            SqlParameter EffectiveDate = new SqlParameter();
            EffectiveDate.ParameterName = "@EffectiveDate";
            EffectiveDate.SqlDbType = SqlDbType.DateTime;
            EffectiveDate.Value = Convert.ToString(dc.EffectiveDate);
            cmd.Parameters.Add(EffectiveDate);

            SqlParameter ExpiryDate = new SqlParameter();
            ExpiryDate.ParameterName = "@ExpiryDate";
            ExpiryDate.SqlDbType = SqlDbType.DateTime;
            ExpiryDate.Value = Convert.ToString(dc.ExpiryDate);
            cmd.Parameters.Add(ExpiryDate);

            SqlParameter ChargeTy = new SqlParameter();
            ChargeTy.ParameterName = "@DiscountTypeId";
            ChargeTy.SqlDbType = SqlDbType.Int;
            ChargeTy.Value = Convert.ToString(dc.DiscountTypeId);
            cmd.Parameters.Add(ChargeTy);
           

            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(dc.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

        [Route("api/ChargesDiscounts/SavePromotionalDiscount")]
        public DataTable SavePromotionalDiscount(Promotionaldisc pd)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelPromotionalDiscounts";

            SqlParameter Id = new SqlParameter();
            Id.ParameterName = "@Id";
            Id.SqlDbType = SqlDbType.Int;
            Id.Value = Convert.ToString(pd.Id);
            cmd.Parameters.Add(Id);

            SqlParameter Code = new SqlParameter();
            Code.ParameterName = "@OpCode";
            Code.SqlDbType = SqlDbType.VarChar;
            Code.Value = Convert.ToString(pd.OpCode);
            cmd.Parameters.Add(Code);

            SqlParameter Condition = new SqlParameter();
            Condition.ParameterName = "@Condition";
            Condition.SqlDbType = SqlDbType.VarChar;
            Condition.Value = Convert.ToString(pd.Condition);
            cmd.Parameters.Add(Condition);

            SqlParameter ValueType = new SqlParameter();
            ValueType.ParameterName = "@ValueType";
            ValueType.SqlDbType = SqlDbType.Int;
            ValueType.Value = Convert.ToString(pd.ValueType);
            cmd.Parameters.Add(ValueType);

            SqlParameter FromDate = new SqlParameter();
            FromDate.ParameterName = "@FromValue";
            FromDate.SqlDbType = SqlDbType.Int;
            FromDate.Value = Convert.ToString(pd.FromValue);
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.ParameterName = "@ToValue";
            ToDate.SqlDbType = SqlDbType.Int;
            ToDate.Value = Convert.ToString(pd.ToValue);
            cmd.Parameters.Add(ToDate);

            SqlParameter Description = new SqlParameter();
            Description.ParameterName = "@TypeId";
            Description.SqlDbType = SqlDbType.Int;
            Description.Value = Convert.ToString(pd.TypeId);
            cmd.Parameters.Add(Description);

            SqlParameter Type = new SqlParameter();
            Type.ParameterName = "@ApplyOn";
            Type.SqlDbType = SqlDbType.Int;
            Type.Value = Convert.ToString(pd.ApplyOn);
            cmd.Parameters.Add(Type);

            SqlParameter Category = new SqlParameter();
            Category.ParameterName = "@Value";
            Category.SqlDbType = SqlDbType.Int;
            Category.Value = Convert.ToString(pd.Value);
            cmd.Parameters.Add(Category);         

            SqlParameter Applicability = new SqlParameter();
            Applicability.ParameterName = "@Applicability";
            Applicability.SqlDbType = SqlDbType.VarChar;
            Applicability.Value = Convert.ToString(pd.Applicability);
            cmd.Parameters.Add(Applicability);

            SqlParameter Codes = new SqlParameter();
            Codes.ParameterName = "@Code";
            Codes.SqlDbType = SqlDbType.VarChar;
            Codes.Value = Convert.ToString(pd.Code);
            cmd.Parameters.Add(Codes);


            SqlParameter Flag = new SqlParameter();
            Flag.ParameterName = "@Flag ";
            Flag.SqlDbType = SqlDbType.VarChar;
            Flag.Value = Convert.ToString(pd.flag);
            cmd.Parameters.Add(Flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            return dt;

        }

    }
}
