using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace PaySmartDashboard.Controllers
{
    public class UsersController : ApiController
    {

        [HttpGet]
        public DataTable GetUsers(int cmpId)//Main Method
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers ....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetUsers";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@cmpId", SqlDbType.Int);
            cmpid.Value = cmpId;
            cmd.Parameters.Add(cmpid);

            //SqlParameter empid= new SqlParameter("@EmpNo", SqlDbType.Int);
            //cmpid.Value = empid;
            //cmd.Parameters.Add(empid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers  completed.");

            return Tbl;
        }

        [HttpGet]
        public DataTable GetUserDetails(int UId)//Main Method
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers ....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "getUserdetails";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@UId", SqlDbType.Int);
            cmpid.Value = UId;
            cmd.Parameters.Add(cmpid);

            //SqlParameter empid= new SqlParameter("@EmpNo", SqlDbType.Int);
            //cmpid.Value = empid;
            //cmd.Parameters.Add(empid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUsers  completed.");

            return Tbl;
        }
        [HttpPost]
        public DataTable SaveUsers(Users U)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers ....");

            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdUsers";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
                UId.Value = U.Id;
                cmd.Parameters.Add(UId);

                SqlParameter UFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                UFirstName.Value = U.FirstName;
                cmd.Parameters.Add(UFirstName);

                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                LastName.Value = U.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                MiddleName.Value = U.MiddleName;
                cmd.Parameters.Add(MiddleName);

                SqlParameter UUserType = new SqlParameter("@cmpId", SqlDbType.Int);
                UUserType.Value = U.companyId;
                cmd.Parameters.Add(UUserType);

                SqlParameter uEmpNo = new SqlParameter("@EmpNo", SqlDbType.VarChar, 15);
                uEmpNo.Value = U.EmpNo;
                cmd.Parameters.Add(uEmpNo);

                SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                UEmail.Value = U.Email;
                cmd.Parameters.Add(UEmail);

                SqlParameter UAdressId = new SqlParameter("@Address", SqlDbType.VarChar, 250);
                UAdressId.Value = U.Address;
                cmd.Parameters.Add(UAdressId);

                SqlParameter AltAddress = new SqlParameter("@AltAddress", SqlDbType.VarChar, 250);
                AltAddress.Value = U.AltAdress;
                cmd.Parameters.Add(AltAddress);

                SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
                UMobileNo.Value = U.ContactNo1;
                cmd.Parameters.Add(UMobileNo);

                SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
                ContactNo2.Value = U.ContactNo2;
                cmd.Parameters.Add(ContactNo2);

                SqlParameter URole1 = new SqlParameter("@RoleId", SqlDbType.Int);
                URole1.Value = U.RoleId;
                cmd.Parameters.Add(URole1);

                SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
                UActive.Value = U.Active;
                cmd.Parameters.Add(UActive);

                SqlParameter UUserName = new SqlParameter("@DUserName", SqlDbType.VarChar, 15);
                UUserName.Value = U.DUserName;
                cmd.Parameters.Add(UUserName);

                SqlParameter UPassword = new SqlParameter("@DPassword", SqlDbType.VarChar, 15);
                UPassword.Value = U.DPassword;
                cmd.Parameters.Add(UPassword);

                //  SqlParameter WUserName = new SqlParameter("@WUserName",SqlDbType.VarChar,15);
                //WUserName.Value = U.WUserName;
                //cmd.Parameters.Add(WUserName);

                //SqlParameter WPassword = new SqlParameter("@WPassword",SqlDbType.VarChar,15);
                //WPassword.Value = U.WPassword;
                //cmd.Parameters.Add(WPassword);

                SqlParameter MgrId = new SqlParameter("@ManagerId", SqlDbType.Int);
                MgrId.Value = U.mgrId;
                cmd.Parameters.Add(MgrId);


                SqlParameter ZipCode = new SqlParameter("@ZipCode", SqlDbType.VarChar, 15);
                ZipCode.Value = U.ZipCode;
                cmd.Parameters.Add(ZipCode);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = U.insupdflag;
                cmd.Parameters.Add(insupdflag);

                SqlParameter StateId = new SqlParameter("@StateId", SqlDbType.Int);
                StateId.Value = U.StateId;
                cmd.Parameters.Add(StateId);

                SqlParameter CountryId = new SqlParameter("@CountryId", SqlDbType.Int);
                CountryId.Value = U.CountryId;
                cmd.Parameters.Add(CountryId);

                SqlParameter GenderId = new SqlParameter("@GenderId", SqlDbType.Int);
                GenderId.Value = U.GenderId;
                cmd.Parameters.Add(GenderId);

                SqlParameter RFromDate = new SqlParameter();
                RFromDate.ParameterName = "@RFromDate";
                RFromDate.SqlDbType = SqlDbType.DateTime;
                RFromDate.Value = U.RFromDate;
                cmd.Parameters.Add(RFromDate);

                SqlParameter RToDate = new SqlParameter();
                RToDate.ParameterName = "@RToDate";
                RToDate.SqlDbType = SqlDbType.DateTime;
                RToDate.Value = U.RToDate;
                cmd.Parameters.Add(RToDate);

                SqlParameter Photo = new SqlParameter();
                Photo.ParameterName = "@Photo";
                Photo.SqlDbType = SqlDbType.VarChar;
                Photo.Value = U.Photo;
                cmd.Parameters.Add(Photo);

                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers completed.");

            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
                throw ex;
            }



            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        [Route("api/Users/GetUserRoles")]
        public DataTable GetUserRoles(int cmpId)
        {
            DataTable tbl = new DataTable();


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserRoles ....");

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetUserRoles";
            cmd.Connection = conn;

            SqlParameter UUserType = new SqlParameter("@companyId", SqlDbType.Int);
            UUserType.Value = cmpId;
            cmd.Parameters.Add(UUserType);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserRoles  completed.");

            return tbl;
        }

        [HttpPost]
        [Route("api/Users/SaveUserRoles")]
        public DataTable SaveUserRoles(userroles U)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUserRoles ....");

            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelUserRoles";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter UId = new SqlParameter("@Id", SqlDbType.Int);
                UId.Value = U.Id;
                cmd.Parameters.Add(UId);

                SqlParameter URole = new SqlParameter("@UserId", SqlDbType.Int);
                URole.Value = U.UserId;
                cmd.Parameters.Add(URole);

                SqlParameter UUser = new SqlParameter("@roleid", SqlDbType.Int);
                UUser.Value = U.RoleId;
                cmd.Parameters.Add(UUser);

                SqlParameter UCmp = new SqlParameter("@CompanyId", SqlDbType.Int);
                UCmp.Value = U.CompanyId;
                cmd.Parameters.Add(UCmp);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = U.insupdflag;
                cmd.Parameters.Add(insupdflag);

                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUserRoles  completed.");

            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUserRoles:" + ex.Message);
            }


            // int found = 0;
            return Tbl;
        }

        public DataTable GetCountry(int active)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCountry ...");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCountry";
            cmd.Connection = conn;
            SqlParameter a = new SqlParameter("@active", SqlDbType.Int);
            a.Value = active;
            cmd.Parameters.Add(a);
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetCountry completed.");
            // int found = 0;
            return Tbl;
        }
    }
}
