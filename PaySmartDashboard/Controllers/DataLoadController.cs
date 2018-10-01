using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using PaySmartDashboard.Models;
using System.Collections;

namespace PaySmartDashboard.Controllers
{
    public class DataLoadController : ApiController
    {
        [HttpGet]
        [Route("api/DataLoad/GetDataLoad")]
        public DataTable GetDataLoad()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetDataLoad credentials....");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDataLoad";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetDataLoad Credentials completed.");
            // int found = 0;
            return Tbl;

        }

        //[HttpPost]
        //[Route("api/DataLoad/SaveCompanyGroups")]
        //public HttpResponseMessage SaveCompanyGroups(List<CompanyGroups> list)
        //{
            
        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdDelCompany";
        //        cmd.Connection = conn;

        //        conn.Open();
                
        //        foreach (CompanyGroups n in list)
        //        {
        //            SqlParameter gsa = new SqlParameter();
        //            gsa.ParameterName = "@active";
        //            gsa.SqlDbType = SqlDbType.Int;
        //            gsa.Value = n.active;
        //            cmd.Parameters.Add(gsa);

        //            SqlParameter gsn = new SqlParameter();
        //            gsn.ParameterName = "@code";
        //            gsn.SqlDbType = SqlDbType.VarChar;
        //            gsn.Value = n.code;
        //            cmd.Parameters.Add(gsn);

        //            SqlParameter gsab = new SqlParameter();
        //            gsab.ParameterName = "@desc";
        //            gsab.SqlDbType = SqlDbType.VarChar;
        //            gsab.Value = n.desc;
        //            cmd.Parameters.Add(gsab);

        //            SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
        //            gsac.Value = n.Id;
        //            cmd.Parameters.Add(gsac);

        //            SqlParameter gid = new SqlParameter();
        //            gid.ParameterName = "@Name";
        //            gid.SqlDbType = SqlDbType.VarChar;
        //            gid.Value = n.Name;
        //            cmd.Parameters.Add(gid);


        //            SqlParameter gad = new SqlParameter();
        //            gad.ParameterName = "@Address";
        //            gad.SqlDbType = SqlDbType.VarChar;
        //            gad.Value = n.Address;
        //            cmd.Parameters.Add(gad);

        //            SqlParameter gcn = new SqlParameter();
        //            gcn.ParameterName = "@ContactNo1";
        //            gcn.SqlDbType = SqlDbType.VarChar;
        //            gcn.Value = n.ContactNo1;
        //            cmd.Parameters.Add(gcn);

        //            SqlParameter gcn1 = new SqlParameter();
        //            gcn1.ParameterName = "@ContactNo2";
        //            gcn1.SqlDbType = SqlDbType.VarChar;
        //            gcn1.Value = n.ContactNo2;
        //            cmd.Parameters.Add(gcn1);



        //            SqlParameter gem = new SqlParameter();
        //            gem.ParameterName = "@EmailId";
        //            gem.SqlDbType = SqlDbType.VarChar;
        //            gem.Value = n.EmailId;
        //            cmd.Parameters.Add(gem);






        //            //SqlParameter TAdd = new SqlParameter();
        //            //TAdd.ParameterName = "@TemporaryAddress";
        //            //TAdd.SqlDbType = SqlDbType.VarChar;
        //            //TAdd.Value = n.TemporaryAddress;
        //            //cmd.Parameters.Add(TAdd);


        //            // ImageConverter imgCon = new ImageConverter();
        //            // logo.Value = (byte[])imgCon.ConvertTo(n.Logo, typeof(byte[]));


        //            SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
        //            insupdflag.Value = n.insupdflag;
        //            cmd.Parameters.Add(insupdflag);

        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
        //        conn.Close();
        //        traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}

        //[HttpPost]
        //[Route("api/DataLoad/SaveUsers")]

        //public HttpResponseMessage SaveUsers(List<Users> list1)
        //{

        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdUsers";
        //        cmd.Connection = conn;

        //        conn.Open();


        //        foreach (Users U in list1)
        //        {
        //            SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
        //            UId.Value = U.Id;
        //            cmd.Parameters.Add(UId);

        //            SqlParameter UFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
        //            UFirstName.Value = U.FirstName;
        //            cmd.Parameters.Add(UFirstName);

        //            SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
        //            LastName.Value = U.LastName;
        //            cmd.Parameters.Add(LastName);

        //            SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
        //            MiddleName.Value = U.MiddleName;
        //            cmd.Parameters.Add(MiddleName);




        //            SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
        //            UEmail.Value = U.Email;
        //            cmd.Parameters.Add(UEmail);



        //            SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
        //            UMobileNo.Value = U.ContactNo1;
        //            cmd.Parameters.Add(UMobileNo);

        //            SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
        //            ContactNo2.Value = U.ContactNo2;
        //            cmd.Parameters.Add(ContactNo2);



        //            SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
        //            UActive.Value = U.Active;
        //            cmd.Parameters.Add(UActive);



        //            //  SqlParameter WUserName = new SqlParameter("@WUserName",SqlDbType.VarChar,15);
        //            //WUserName.Value = U.WUserName;
        //            //cmd.Parameters.Add(WUserName);

        //            //SqlParameter WPassword = new SqlParameter("@WPassword",SqlDbType.VarChar,15);
        //            //WPassword.Value = U.WPassword;
        //            //cmd.Parameters.Add(WPassword);


        //            SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
        //            insupdflag.Value = U.insupdflag;
        //            cmd.Parameters.Add(insupdflag);




        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
        //        conn.Close();
        //        traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers Credentials completed.");
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}





        
        [HttpPost]
        [Route("api/DataLoad/SaveCompanyGroups1")]
        public DataTable SaveCompanyGroups1(List<CompanyGroups> list)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups credentials....");
            DataTable tbl = new DataTable();

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompanyGroups";
                cmd.Connection = conn;

                conn.Open();

                foreach (CompanyGroups m in list)
                {
                    SqlParameter gid = new SqlParameter();
                    gid.ParameterName = "@Name";
                    gid.SqlDbType = SqlDbType.VarChar;
                    gid.Value = m.Name;
                    cmd.Parameters.Add(gid);

                    SqlParameter gsa = new SqlParameter("@active", SqlDbType.Int);
                    gsa.Value = m.active;
                    cmd.Parameters.Add(gsa);

                    SqlParameter gsn = new SqlParameter();
                    gsn.ParameterName = "@code";
                    gsn.SqlDbType = SqlDbType.VarChar;
                    gsn.Value = m.code;
                    cmd.Parameters.Add(gsn);

                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@Description";
                    gsab.SqlDbType = SqlDbType.VarChar;
                    gsab.Value = m.desc;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gad = new SqlParameter();
                    gad.ParameterName = "@Address";
                    gad.SqlDbType = SqlDbType.VarChar;
                    gad.Value = m.Address;
                    cmd.Parameters.Add(gad);

                    SqlParameter gem = new SqlParameter();
                    gem.ParameterName = "@EmailId";
                    gem.SqlDbType = SqlDbType.VarChar;
                    gem.Value = m.EmailId;
                    cmd.Parameters.Add(gem);

                    SqlParameter gcn = new SqlParameter();
                    gcn.ParameterName = "@ContactNo1";
                    gcn.SqlDbType = SqlDbType.VarChar;
                    gcn.Value = m.ContactNo1;
                    cmd.Parameters.Add(gcn);

                    SqlParameter gcn1 = new SqlParameter();
                    gcn1.ParameterName = "@ContactNo2";
                    gcn1.SqlDbType = SqlDbType.VarChar;
                    gcn1.Value = m.ContactNo2;
                    cmd.Parameters.Add(gcn1);

                    SqlParameter gcn2 = new SqlParameter();
                    gcn2.ParameterName = "@Fax";
                    gcn2.SqlDbType = SqlDbType.VarChar;
                    gcn2.Value = m.Fax;
                    cmd.Parameters.Add(gcn2);

                    SqlParameter gem1 = new SqlParameter();
                    gem1.ParameterName = "@Title";
                    gem1.SqlDbType = SqlDbType.VarChar;
                    gem1.Value = m.Title;
                    cmd.Parameters.Add(gem1);

                    SqlParameter gem2 = new SqlParameter();
                    gem2.ParameterName = "@Caption";
                    gem2.SqlDbType = SqlDbType.VarChar;
                    gem2.Value = m.Caption;
                    cmd.Parameters.Add(gem2);

                    SqlParameter gem3 = new SqlParameter();
                    gem3.ParameterName = "@Country";
                    gem3.SqlDbType = SqlDbType.VarChar;
                    gem3.Value = m.Country;
                    cmd.Parameters.Add(gem3);

                    SqlParameter gem4 = new SqlParameter();
                    gem4.ParameterName = "@ZipCode";
                    gem4.SqlDbType = SqlDbType.VarChar;
                    gem4.Value = m.ZipCode;
                    cmd.Parameters.Add(gem4);

                    SqlParameter gem5 = new SqlParameter();
                    gem5.ParameterName = "@State";
                    gem5.SqlDbType = SqlDbType.VarChar;
                    gem5.Value = m.State;
                    cmd.Parameters.Add(gem5);

                    SqlParameter gem8 = new SqlParameter();
                    gem8.ParameterName = "@FleetSize";
                    gem8.SqlDbType = SqlDbType.Int;
                    gem8.Value = m.FleetSize;
                    cmd.Parameters.Add(gem8);

                    SqlParameter gem7 = new SqlParameter();
                    gem7.ParameterName = "@StaffSize";
                    gem7.SqlDbType = SqlDbType.Int;
                    gem7.Value = m.StaffSize;
                    cmd.Parameters.Add(gem7);

                    SqlParameter gem9 = new SqlParameter();
                    gem9.ParameterName = "@AlternateAddress";
                    gem9.SqlDbType = SqlDbType.VarChar;
                    gem9.Value = m.AlternateAddress;
                    cmd.Parameters.Add(gem9);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag.Value = m.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    DataSet ds = new DataSet();
                    SqlDataAdapter db = new SqlDataAdapter(cmd);
                    db.Fill(tbl);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return tbl;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                
                string str = ex.Message;

                
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCompanyGroups:" + ex.Message);
                
                return tbl;


                // int found = 0;
               
            }
         
        }
        


        


        //[HttpPost]
        //[Route("api/DataLoad/SaveDriverGroups")]
        //public SqlParameter[] SaveDriverGroups(DriversGroups m)
        //{
            
        //    //List<DriversGroups> list1 = new List<DriversGroups>();
        //    LogTraceWriter traceWriter = new LogTraceWriter();
        //    traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriverGroups credentials....");
        //    //DataTable Tbl = new DataTable();
        //    SqlConnection conn = new SqlConnection();

        //    try
        //    {
        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "HVInsUpddrivers2";
        //        cmd.Connection = conn;

        //        conn.Open();
        //        //list = new List<DriversGroups>();
        //        for(int i=0; i<m.DriversGroup.Length;i++)
        //        {
        //            SqlParameter dgid = new SqlParameter();
        //            dgid.ParameterName = "@CompanyId";
        //            dgid.SqlDbType = SqlDbType.Int;
        //            dgid.Value = m.CompanyId;
        //            cmd.Parameters.Add(dgid);

        //            SqlParameter dgname = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
        //            dgname.Value = m.NAme;
        //            cmd.Parameters.Add(dgname);

        //            SqlParameter dgAddr = new SqlParameter();
        //            dgAddr.ParameterName = "@Address";
        //            dgAddr.SqlDbType = SqlDbType.VarChar;
        //            dgAddr.Value = m.Address;
        //            cmd.Parameters.Add(dgAddr);

        //            SqlParameter dgcity = new SqlParameter();
        //            dgcity.ParameterName = "@City";
        //            dgcity.SqlDbType = SqlDbType.VarChar;
        //            dgcity.Value = m.City;
        //            cmd.Parameters.Add(dgcity);

        //            SqlParameter dgppin = new SqlParameter();
        //            dgppin.ParameterName = "@Pin";
        //            dgppin.SqlDbType = SqlDbType.VarChar;
        //            dgppin.Value = m.Pin;
        //            cmd.Parameters.Add(dgppin);

        //            //SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
        //            //gsac.Value = n.Id;
        //            //cmd.Parameters.Add(gsac);                    

        //            SqlParameter dgpadr = new SqlParameter();
        //            dgpadr.ParameterName = "@PAddress";
        //            dgpadr.SqlDbType = SqlDbType.VarChar;
        //            dgpadr.Value = m.PAddress;
        //            cmd.Parameters.Add(dgpadr);

        //            SqlParameter dgPPin = new SqlParameter();
        //            dgPPin.ParameterName = "@PPin";
        //            dgPPin.SqlDbType = SqlDbType.VarChar;
        //            dgPPin.Value = m.PPin;
        //            cmd.Parameters.Add(dgPPin);

        //            SqlParameter dgMob1 = new SqlParameter();
        //            dgMob1.ParameterName = "@OffMobileNo";
        //            dgMob1.SqlDbType = SqlDbType.VarChar;
        //            dgMob1.Value = m.OffMobileNo;
        //            cmd.Parameters.Add(dgMob1);

        //            SqlParameter dgPM = new SqlParameter();
        //            dgPM.ParameterName = "@PMobNo";
        //            dgPM.SqlDbType = SqlDbType.VarChar;
        //            dgPM.Value = m.PMobNo;
        //            cmd.Parameters.Add(dgPM);

        //            SqlParameter dgDOB = new SqlParameter();
        //            dgDOB.ParameterName = "@DOB";
        //            dgDOB.SqlDbType = SqlDbType.DateTime;
        //            dgDOB.Value = m.DOB;
        //            cmd.Parameters.Add(dgDOB);

        //            SqlParameter dgDOJ = new SqlParameter();
        //            dgDOJ.ParameterName = "@DOJ";
        //            dgDOJ.SqlDbType = SqlDbType.DateTime;
        //            dgDOJ.Value = m.DOJ;
        //            cmd.Parameters.Add(dgDOJ);

        //            SqlParameter dgbg = new SqlParameter();
        //            dgbg.ParameterName = "@BloodGroup";
        //            dgbg.SqlDbType = SqlDbType.VarChar;
        //            dgbg.Value = m.BloodGroup;
        //            cmd.Parameters.Add(dgbg);

        //            SqlParameter dgLNo = new SqlParameter();
        //            dgLNo.ParameterName = "@LicenceNo";
        //            dgLNo.SqlDbType = SqlDbType.VarChar;
        //            dgLNo.Value = m.LicenceNo;
        //            cmd.Parameters.Add(dgLNo);

        //            SqlParameter dgLEDt = new SqlParameter();
        //            dgLEDt.ParameterName = "@LiCExpDate";
        //            dgLEDt.SqlDbType = SqlDbType.VarChar;
        //            dgLEDt.Value = m.LiCExpDate;
        //            cmd.Parameters.Add(dgLEDt);

        //            SqlParameter dgBNo = new SqlParameter();
        //            dgBNo.ParameterName = "@BadgeNo";
        //            dgBNo.SqlDbType = SqlDbType.VarChar;
        //            dgBNo.Value = m.BadgeNo;
        //            cmd.Parameters.Add(dgBNo);

        //            SqlParameter dgBED = new SqlParameter();
        //            dgBED.ParameterName = "@BadgeExpDate";
        //            dgBED.SqlDbType = SqlDbType.DateTime;
        //            dgBED.Value = m.BadgeExpDate;
        //            cmd.Parameters.Add(dgBED);

        //            SqlParameter dgRemarks = new SqlParameter();
        //            dgRemarks.ParameterName = "@Remarks";
        //            dgRemarks.SqlDbType = SqlDbType.VarChar;
        //            dgRemarks.Value = m.Remarks;
        //            cmd.Parameters.Add(dgRemarks);


        //            SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
        //            insupdflag.Value = m.flag;
        //            cmd.Parameters.Add(insupdflag);

        //            cmd.ExecuteScalar();
        //            cmd.Parameters.Clear();
        //        }
                
                
        //        return null;
        //        //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
        //        //return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }

        //        string str = ex.Message;
        //        traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
        //        ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //        return null;
        //    }
        //    // int found = 0;
        //    //  return Tbl;
        //}
        


        

        [HttpPost]
        [Route("api/DataLoad/SaveUsersGroup1")]

        public HttpResponseMessage SaveUsersGroup1(List<UsersGroup> list5)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdUsersGroups";
                cmd.Connection = conn;

                conn.Open();


                foreach (UsersGroup U in list5)
                {
                    //SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
                    //UId.Value = U.Id;
                    //cmd.Parameters.Add(UId);

                    SqlParameter UFirstName=new SqlParameter();
                    UFirstName.ParameterName="@FirstName";
                    UFirstName.SqlDbType=SqlDbType.VarChar;
                    UFirstName.Value=U.FirstName;
                    cmd.Parameters.Add(UFirstName);

                    SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                    LastName.Value = U.LastName;
                    cmd.Parameters.Add(LastName);

                    SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
                    MiddleName.Value = U.MiddleName;
                    cmd.Parameters.Add(MiddleName);

                    SqlParameter empNo = new SqlParameter("@EmpNo", SqlDbType.VarChar, 15);
                    empNo.Value = U.EmpNo;
                    cmd.Parameters.Add(empNo);

                    SqlParameter UEmail = new SqlParameter("@Email", SqlDbType.VarChar, 15);
                    UEmail.Value = U.Email;
                    cmd.Parameters.Add(UEmail);

                    SqlParameter UAddress = new SqlParameter("@Address", SqlDbType.VarChar, 15);
                    UAddress.Value = U.Address;
                    cmd.Parameters.Add(UAddress);

                    SqlParameter roleId = new SqlParameter("@RoleId", SqlDbType.Int);
                    roleId.Value = U.RoleId;
                    cmd.Parameters.Add(roleId);

                    SqlParameter UActive = new SqlParameter("@Active", SqlDbType.Int);
                    UActive.Value = U.Active;
                    cmd.Parameters.Add(UActive);

                    SqlParameter UcmpId = new SqlParameter("@cmpId", SqlDbType.Int);
                    UcmpId.Value = U.cmpId;
                    cmd.Parameters.Add(UcmpId);


                    SqlParameter UMobileNo = new SqlParameter("@ContactNo1", SqlDbType.VarChar, 15);
                    UMobileNo.Value = U.ContactNo1;
                    cmd.Parameters.Add(UMobileNo);

                    SqlParameter ContactNo2 = new SqlParameter("@ContactNo2", SqlDbType.VarChar, 15);
                    ContactNo2.Value = U.ContactNo2;
                    cmd.Parameters.Add(ContactNo2);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = U.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveUsers Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveUsers:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            // int found = 0;
            //  return Tbl;
        }
        
        [HttpPost]
        [Route("api/DataLoad/SaveVehicleGroups")]
        public SqlParameter[] SaveVehicleGroups(VehiclesGroups o)
        {
           
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");
            
            SqlConnection conn = new SqlConnection();

            try
            {
               
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpddrivers2";
                cmd.Connection = conn;

                conn.Open();
              
                ArrayList arr = new ArrayList();
               
                SqlParameter vgid = new SqlParameter();
                vgid.ParameterName = "@Id";
                vgid.SqlDbType = SqlDbType.Int;
                vgid.Value = o.Id;
                cmd.Parameters.Add(vgid);

                SqlParameter vgCompanyId = new SqlParameter("@CompanyId", SqlDbType.Int);
                vgCompanyId.Value = o.Company;
                cmd.Parameters.Add(vgCompanyId);

                SqlParameter vgVId = new SqlParameter();
                vgVId.ParameterName = "@VID";
                vgVId.SqlDbType = SqlDbType.Int;
                vgVId.Value = o.VID;
                cmd.Parameters.Add(vgVId);

                SqlParameter vgRegNo = new SqlParameter();
                vgRegNo.ParameterName = "@RegistrationNo";
                vgRegNo.SqlDbType = SqlDbType.NVarChar;
                vgRegNo.Value = o.RegistrationNo;
                cmd.Parameters.Add(vgRegNo);

                SqlParameter vgType = new SqlParameter();
                vgType.ParameterName = "@VehicleType";
                vgType.SqlDbType = SqlDbType.NVarChar;
                vgType.Value = o.vehicleType;
                cmd.Parameters.Add(vgType);
                 
                SqlParameter vgOwnerName = new SqlParameter();
                vgOwnerName.ParameterName = "@OwnerName";
                vgOwnerName.SqlDbType = SqlDbType.NVarChar;
                vgOwnerName.Value = o.FleetOwner;
                cmd.Parameters.Add(vgOwnerName);

                SqlParameter vgChasisNo = new SqlParameter();
                vgChasisNo.ParameterName = "@ChasisNo";
                vgChasisNo.SqlDbType = SqlDbType.NVarChar;
                vgChasisNo.Value = o.ChasisNo;
                cmd.Parameters.Add(vgChasisNo);

                SqlParameter vgEngineNo = new SqlParameter();
                vgEngineNo.ParameterName = "@Engineno";
                vgEngineNo.SqlDbType = SqlDbType.NVarChar;
                vgEngineNo.Value = o.Engineno;
                cmd.Parameters.Add(vgEngineNo);

                SqlParameter vgRoadTDate = new SqlParameter();
                vgRoadTDate.ParameterName = "@RoadTaxDate";
                vgRoadTDate.SqlDbType = SqlDbType.DateTime;
                vgRoadTDate.Value = o.RoadTaxDate;
                cmd.Parameters.Add(vgRoadTDate);

                SqlParameter vgInsuNo = new SqlParameter();
                vgInsuNo.ParameterName = "@HasAC";
                vgInsuNo.SqlDbType = SqlDbType.Int;
                vgInsuNo.Value = o.HasAC;
                cmd.Parameters.Add(vgInsuNo);

                SqlParameter vgInsDate = new SqlParameter();
                vgInsDate.ParameterName = "@InsDate";
                vgInsDate.SqlDbType = SqlDbType.DateTime;
                vgInsDate.Value = o.InsDate;
                cmd.Parameters.Add(vgInsDate);

                SqlParameter vgPolutionNo = new SqlParameter();
                vgPolutionNo.ParameterName = "@PolutionNo";
                vgPolutionNo.SqlDbType = SqlDbType.NVarChar;
                vgPolutionNo.Value = o.PolutionNo;
                cmd.Parameters.Add(vgPolutionNo);

                SqlParameter vgPolExpDate = new SqlParameter();
                vgPolExpDate.ParameterName = "@PolExpDate";
                vgPolExpDate.SqlDbType = SqlDbType.DateTime;
                vgPolExpDate.Value = o.PolExpDate;
                cmd.Parameters.Add(vgPolExpDate);

                SqlParameter vgRCBookNo = new SqlParameter();
                vgRCBookNo.ParameterName = "@RCBookNo";
                vgRCBookNo.SqlDbType = SqlDbType.NVarChar;
                vgRCBookNo.Value = o.RCBookNo;
                cmd.Parameters.Add(vgRCBookNo);

                SqlParameter vgRCExpDate = new SqlParameter();
                vgRCExpDate.ParameterName = "@RCExpDate";
                vgRCExpDate.SqlDbType = SqlDbType.DateTime;
                vgRCExpDate.Value = o.RCExpDate;
                cmd.Parameters.Add(vgRCExpDate);

                SqlParameter vgCompanyVeh = new SqlParameter();
                vgCompanyVeh.ParameterName = "@StatusId";
                vgCompanyVeh.SqlDbType = SqlDbType.Int;
                vgCompanyVeh.Value = o.StatusId;
                cmd.Parameters.Add(vgCompanyVeh);

                SqlParameter vgOwnerPhoneNo = new SqlParameter();
                vgOwnerPhoneNo.ParameterName = "@IsVerified";
                vgOwnerPhoneNo.SqlDbType = SqlDbType.Int;
                vgOwnerPhoneNo.Value = o.IsVerified;
                cmd.Parameters.Add(vgOwnerPhoneNo);

                SqlParameter vgHomeLandmark = new SqlParameter();
                vgHomeLandmark.ParameterName = "@HomeLandmark";
                vgHomeLandmark.SqlDbType = SqlDbType.NVarChar;
                vgHomeLandmark.Value = o.VehicleCode;
                cmd.Parameters.Add(vgHomeLandmark);


                SqlParameter vgMYear = new SqlParameter();
                vgMYear.ParameterName = "@ModelYear";
                vgMYear.SqlDbType = SqlDbType.NVarChar;
                vgMYear.Value = o.ModelYear;
                cmd.Parameters.Add(vgMYear);

                SqlParameter vgDayOnly = new SqlParameter();
                vgDayOnly.ParameterName = "@IsDriverowned";
                vgDayOnly.SqlDbType = SqlDbType.Int;
                vgDayOnly.Value = o.IsDriverowned;
                cmd.Parameters.Add(vgDayOnly);

                SqlParameter vgVechMobileNo = new SqlParameter();
                vgVechMobileNo.ParameterName = "@DriverId";
                vgVechMobileNo.SqlDbType = SqlDbType.NVarChar;
                vgVechMobileNo.Value = o.DriverId;
                cmd.Parameters.Add(vgVechMobileNo);

                SqlParameter vgEntryDate = new SqlParameter();
                vgEntryDate.ParameterName = "@EntryDate";
                vgEntryDate.SqlDbType = SqlDbType.DateTime;
                vgEntryDate.Value = o.EntryDate;
                cmd.Parameters.Add(vgEntryDate);

                SqlParameter vgNewEntry = new SqlParameter();
                vgNewEntry.ParameterName = "@CountryId";
                vgNewEntry.SqlDbType = SqlDbType.NVarChar;
                vgNewEntry.Value = o.Country;
                cmd.Parameters.Add(vgNewEntry);

                SqlParameter vgVehicleModelId = new SqlParameter();
                vgVehicleModelId.ParameterName = "@VehicleModelId";
                vgVehicleModelId.SqlDbType = SqlDbType.Int;
                vgVehicleModelId.Value = o.VehicleModel;
                cmd.Parameters.Add(vgVehicleModelId);

                SqlParameter vgServiceTypeId = new SqlParameter();
                vgServiceTypeId.ParameterName = "@VehicleMakeId";
                vgServiceTypeId.SqlDbType = SqlDbType.Int;
                vgServiceTypeId.Value = o.VehicleMake;
                cmd.Parameters.Add(vgServiceTypeId);

                SqlParameter vgVehicleGroupId = new SqlParameter();
                vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                vgVehicleGroupId.SqlDbType = SqlDbType.Int;
                vgVehicleGroupId.Value = o.VehicleGroup;
                cmd.Parameters.Add(vgVehicleGroupId);
                
                SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                insupdflag.Value = o.flag;
                cmd.Parameters.Add(insupdflag);

                cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                //}

                if (arr.Count > 0)
                {
                    arr.TrimToSize();
                    return (SqlParameter[])arr.ToArray(typeof(SqlParameter));
                }
                return null;
                //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;
            }
        }

        //demo purpose
        [HttpPost]
        [Route("api/DataLoad/SaveDriverGroups1")]
        public HttpResponseMessage SaveDriverGroups1(List<DriversGroups> list1)
        {

            //List<DriversGroups> list1 = new List<DriversGroups>();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriverGroups credentials....");
            //DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();

            try
            {
                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpddriversGroup";
                cmd.Connection = conn;

                conn.Open();
                //list = new List<DriversGroups>();
                foreach (DriversGroups p in list1)
                {
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "HVInsUpddrivers2";
                    //cmd.Connection = conn;


                    SqlParameter dgid = new SqlParameter();
                    dgid.ParameterName = "@CompanyId";
                    dgid.SqlDbType = SqlDbType.VarChar;
                    dgid.Value = p.CompanyId;
                    cmd.Parameters.Add(dgid);

                    SqlParameter dgname = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
                    dgname.Value = p.NAme;
                    cmd.Parameters.Add(dgname);

                    SqlParameter dgAddr = new SqlParameter();
                    dgAddr.ParameterName = "@Address";
                    dgAddr.SqlDbType = SqlDbType.VarChar;
                    dgAddr.Value = p.Address;
                    cmd.Parameters.Add(dgAddr);

                    SqlParameter dgcity = new SqlParameter();
                    dgcity.ParameterName = "@City";
                    dgcity.SqlDbType = SqlDbType.VarChar;
                    dgcity.Value = p.City;
                    cmd.Parameters.Add(dgcity);

                    SqlParameter dgppin = new SqlParameter();
                    dgppin.ParameterName = "@Pin";
                    dgppin.SqlDbType = SqlDbType.VarChar;
                    dgppin.Value = p.Pin;
                    cmd.Parameters.Add(dgppin);

                    SqlParameter dgpadr = new SqlParameter();
                    dgpadr.ParameterName = "@PAddress";
                    dgpadr.SqlDbType = SqlDbType.VarChar;
                    dgpadr.Value = p.PermanentAddress;
                    cmd.Parameters.Add(dgpadr);

                    SqlParameter dgPPin = new SqlParameter();
                    dgPPin.ParameterName = "@PPin";
                    dgPPin.SqlDbType = SqlDbType.VarChar;
                    dgPPin.Value = p.PermanentPin;
                    cmd.Parameters.Add(dgPPin);

                        SqlParameter pc = new SqlParameter();
                        pc.ParameterName = "@PCity";
                    pc.SqlDbType = SqlDbType.VarChar;
                    pc.Value = p.PCity;
                    cmd.Parameters.Add(pc);

                    SqlParameter dgMob1 = new SqlParameter();
                    dgMob1.ParameterName = "@OffMobileNo";
                    dgMob1.SqlDbType = SqlDbType.VarChar;
                    dgMob1.Value = p.OffMobileNo;
                    cmd.Parameters.Add(dgMob1);

                    SqlParameter dgPM = new SqlParameter();
                    dgPM.ParameterName = "@PMobNo";
                    dgPM.SqlDbType = SqlDbType.VarChar;
                    dgPM.Value = p.MobileNumber;
                    cmd.Parameters.Add(dgPM);

                    SqlParameter dgDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
                    dgDOB.Value = p.DOB;
                    cmd.Parameters.Add(dgDOB);

                    //SqlParameter dgDOB = new SqlParameter();
                    //dgDOB.ParameterName = "@DOB";
                    //dgDOB.SqlDbType = SqlDbType.DateTime;
                    //dgDOB.Value = p.DOB;
                    //cmd.Parameters.Add(dgDOB);

                    SqlParameter dgDOJ = new SqlParameter();
                    dgDOJ.ParameterName = "@DOJ";
                    dgDOJ.SqlDbType = SqlDbType.DateTime;
                    dgDOJ.Value = p.DOJ;
                    cmd.Parameters.Add(dgDOJ);

                    SqlParameter dgbg = new SqlParameter();
                    dgbg.ParameterName = "@BloodGroup";
                    dgbg.SqlDbType = SqlDbType.VarChar;
                    dgbg.Value = p.BloodGroup;
                    cmd.Parameters.Add(dgbg);

                    SqlParameter dgLNo = new SqlParameter();
                    dgLNo.ParameterName = "@LicenceNo";
                    dgLNo.SqlDbType = SqlDbType.VarChar;
                    dgLNo.Value = p.LicenceNo;
                    cmd.Parameters.Add(dgLNo);

                    SqlParameter dgLEDt = new SqlParameter();
                    dgLEDt.ParameterName = "@LiCExpDate";
                    dgLEDt.SqlDbType = SqlDbType.DateTime;
                    dgLEDt.Value = p.LiCExpDate;
                    cmd.Parameters.Add(dgLEDt);

                    SqlParameter dgBNo = new SqlParameter();
                    dgBNo.ParameterName = "@BadgeNo";
                    dgBNo.SqlDbType = SqlDbType.VarChar;
                    dgBNo.Value = p.BadgeNo;
                    cmd.Parameters.Add(dgBNo);

                    SqlParameter dgBED = new SqlParameter();
                    dgBED.ParameterName = "@BadgeExpDate";
                    dgBED.SqlDbType = SqlDbType.DateTime;
                    dgBED.Value = p.BadgeExpDate;
                    cmd.Parameters.Add(dgBED);

                    SqlParameter dgRemarks = new SqlParameter();
                    dgRemarks.ParameterName = "@Remarks";
                    dgRemarks.SqlDbType = SqlDbType.VarChar;
                    dgRemarks.Value = p.Remarks;
                    cmd.Parameters.Add(dgRemarks);

                    SqlParameter dgVehicleModelId = new SqlParameter();
                    dgVehicleModelId.ParameterName = "@VehicleModelId";
                    dgVehicleModelId.SqlDbType = SqlDbType.VarChar;
                    dgVehicleModelId.Value = p.VehicleModelId;
                    cmd.Parameters.Add(dgVehicleModelId);

                    SqlParameter fd = new SqlParameter();
                    fd.ParameterName = "@FirstName";
                    fd.SqlDbType = SqlDbType.VarChar;
                    fd.Value = p.FirstName;
                    cmd.Parameters.Add(fd);

                    SqlParameter gf = new SqlParameter();
                    gf.ParameterName = "@LastName";
                    gf.SqlDbType = SqlDbType.VarChar;
                    gf.Value = p.LastName;
                    cmd.Parameters.Add(gf);
                    

                    SqlParameter yt = new SqlParameter();
                    yt.ParameterName = "@EmailId";
                    yt.SqlDbType = SqlDbType.VarChar;
                    yt.Value = p.EmailId;
                    cmd.Parameters.Add(yt);

                    SqlParameter dc = new SqlParameter();
                    dc.ParameterName = "@DriverCode";
                    dc.SqlDbType = SqlDbType.VarChar;
                    dc.Value = p.DriverCode;
                    cmd.Parameters.Add(dc);

                    SqlParameter fo = new SqlParameter();
                    fo.ParameterName = "@FleetOwner";
                    fo.SqlDbType = SqlDbType.VarChar;
                    fo.Value = p.FleetOwner;
                    cmd.Parameters.Add(fo);

                    SqlParameter cs = new SqlParameter();
                    cs.ParameterName = "@CurrentStateId";
                    cs.SqlDbType = SqlDbType.VarChar;
                    cs.Value = p.CurrentStateId;
                    cmd.Parameters.Add(cs);

                    SqlParameter ct = new SqlParameter();
                    ct.ParameterName = "@CountryId";
                    ct.SqlDbType = SqlDbType.VarChar;
                    ct.Value = p.Country;
                    cmd.Parameters.Add(ct);


                    SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                    insupdflag.Value = p.flag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                }

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveDriversGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str1 = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        //sam
        [HttpPost]
        [Route("api/DataLoad/SaveVehicleGroups1")]
        public HttpResponseMessage SaveVehicleGroups1(List<VehiclesGroups> list3)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");
            
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpdVehiclesGroups";
                cmd.Connection = conn;

                conn.Open();
                foreach (VehiclesGroups o in list3)
                {
                //SqlParameter vgid = new SqlParameter();
                //vgid.ParameterName = "@Id";
                //vgid.SqlDbType = SqlDbType.Int;
                //vgid.Value = o.Id;
                //cmd.Parameters.Add(vgid);

                SqlParameter vgCompanyId = new SqlParameter("@CompanyId", SqlDbType.VarChar, 50);
                vgCompanyId.Value = o.Company;
                cmd.Parameters.Add(vgCompanyId);

                SqlParameter vgVId = new SqlParameter();
                vgVId.ParameterName = "@VID";
                vgVId.SqlDbType = SqlDbType.Int;
                vgVId.Value = o.VID;
                cmd.Parameters.Add(vgVId);

                SqlParameter vgRegNo = new SqlParameter();
                vgRegNo.ParameterName = "@RegistrationNo";
                vgRegNo.SqlDbType = SqlDbType.NVarChar;
                vgRegNo.Value = o.RegistrationNo;
                cmd.Parameters.Add(vgRegNo);

                SqlParameter vgType = new SqlParameter();
                vgType.ParameterName = "@VehicleType";
                vgType.SqlDbType = SqlDbType.NVarChar;
                vgType.Value = o.vehicleType;
                cmd.Parameters.Add(vgType);

                //SqlParameter gsac = new SqlParameter("@Id", SqlDbType.Int);
                //gsac.Value = n.Id;
                //cmd.Parameters.Add(gsac);                    

                SqlParameter vgOwnerName = new SqlParameter();
                vgOwnerName.ParameterName = "@FleetOwnerId";
                vgOwnerName.SqlDbType = SqlDbType.Int;
                vgOwnerName.Value = o.FleetOwner;
                cmd.Parameters.Add(vgOwnerName);

                SqlParameter vgChasisNo = new SqlParameter();
                vgChasisNo.ParameterName = "@ChasisNo";
                vgChasisNo.SqlDbType = SqlDbType.NVarChar;
                vgChasisNo.Value = o.ChasisNo;
                cmd.Parameters.Add(vgChasisNo);

                SqlParameter vgEngineNo = new SqlParameter();
                vgEngineNo.ParameterName = "@Engineno";
                vgEngineNo.SqlDbType = SqlDbType.NVarChar;
                vgEngineNo.Value = o.Engineno;
                cmd.Parameters.Add(vgEngineNo);

                SqlParameter vgRoadTDate = new SqlParameter();
                vgRoadTDate.ParameterName = "@RoadTaxDate";
                vgRoadTDate.SqlDbType = SqlDbType.DateTime;
                vgRoadTDate.Value = o.RoadTaxDate;
                cmd.Parameters.Add(vgRoadTDate);

                SqlParameter vgInsuNo = new SqlParameter();
                vgInsuNo.ParameterName = "@HasAC";
                vgInsuNo.SqlDbType = SqlDbType.Int;
                vgInsuNo.Value = o.HasAC;
                cmd.Parameters.Add(vgInsuNo);

                SqlParameter vgInsDate = new SqlParameter();
                vgInsDate.ParameterName = "@InsDate";
                vgInsDate.SqlDbType = SqlDbType.DateTime;
                vgInsDate.Value = o.InsDate;
                cmd.Parameters.Add(vgInsDate);

                SqlParameter vgPolutionNo = new SqlParameter();
                vgPolutionNo.ParameterName = "@PolutionNo";
                vgPolutionNo.SqlDbType = SqlDbType.NVarChar;
                vgPolutionNo.Value = o.PolutionNo;
                cmd.Parameters.Add(vgPolutionNo);

                SqlParameter vgPolExpDate = new SqlParameter();
                vgPolExpDate.ParameterName = "@PolExpDate";
                vgPolExpDate.SqlDbType = SqlDbType.DateTime;
                vgPolExpDate.Value = o.PolExpDate;
                cmd.Parameters.Add(vgPolExpDate);

                SqlParameter vgRCBookNo = new SqlParameter();
                vgRCBookNo.ParameterName = "@RCBookNo";
                vgRCBookNo.SqlDbType = SqlDbType.NVarChar;
                vgRCBookNo.Value = o.RCBookNo;
                cmd.Parameters.Add(vgRCBookNo);

                SqlParameter vgRCExpDate = new SqlParameter();
                vgRCExpDate.ParameterName = "@RCExpDate";
                vgRCExpDate.SqlDbType = SqlDbType.DateTime;
                vgRCExpDate.Value = o.RCExpDate;
                cmd.Parameters.Add(vgRCExpDate);

                SqlParameter vgCompanyVeh = new SqlParameter();
                vgCompanyVeh.ParameterName = "@StatusId";
                vgCompanyVeh.SqlDbType = SqlDbType.VarChar;
                vgCompanyVeh.Value = o.StatusId;
                cmd.Parameters.Add(vgCompanyVeh);

                SqlParameter vgOwnerPhoneNo = new SqlParameter();
                vgOwnerPhoneNo.ParameterName = "@IsVerified";
                vgOwnerPhoneNo.SqlDbType = SqlDbType.Int;
                vgOwnerPhoneNo.Value = o.IsVerified;
                cmd.Parameters.Add(vgOwnerPhoneNo);

                SqlParameter vgHomeLandmark = new SqlParameter();
                vgHomeLandmark.ParameterName = "@VehicleCode";
                vgHomeLandmark.SqlDbType = SqlDbType.NVarChar;
                vgHomeLandmark.Value = o.VehicleCode;
                cmd.Parameters.Add(vgHomeLandmark);


                SqlParameter vgMYear = new SqlParameter();
                vgMYear.ParameterName = "@ModelYear";
                vgMYear.SqlDbType = SqlDbType.NVarChar;
                vgMYear.Value = o.ModelYear;
                cmd.Parameters.Add(vgMYear);

                SqlParameter vgDayOnly = new SqlParameter();
                vgDayOnly.ParameterName = "@IsDriverowned";
                vgDayOnly.SqlDbType = SqlDbType.Int;
                vgDayOnly.Value = o.IsDriverowned;
                cmd.Parameters.Add(vgDayOnly);

                SqlParameter vgVechMobileNo = new SqlParameter();
                vgVechMobileNo.ParameterName = "@DriverId";
                vgVechMobileNo.SqlDbType = SqlDbType.Int;
                vgVechMobileNo.Value = o.DriverId;
                cmd.Parameters.Add(vgVechMobileNo);

                SqlParameter vgEntryDate = new SqlParameter();
                vgEntryDate.ParameterName = "@EntryDate";
                vgEntryDate.SqlDbType = SqlDbType.DateTime;
                vgEntryDate.Value = o.EntryDate;
                cmd.Parameters.Add(vgEntryDate);

                SqlParameter vgNewEntry = new SqlParameter();
                vgNewEntry.ParameterName = "@CountryId";
                vgNewEntry.SqlDbType = SqlDbType.VarChar;
                vgNewEntry.Value = o.Country;
                cmd.Parameters.Add(vgNewEntry);

                SqlParameter vgVehicleModelId = new SqlParameter();
                vgVehicleModelId.ParameterName = "@VehicleModelId";
                vgVehicleModelId.SqlDbType = SqlDbType.VarChar;
                vgVehicleModelId.Value = o.VehicleModel;
                cmd.Parameters.Add(vgVehicleModelId);

                SqlParameter vgServiceTypeId = new SqlParameter();
                vgServiceTypeId.ParameterName = "@VehicleMakeId";
                vgServiceTypeId.SqlDbType = SqlDbType.VarChar;
                vgServiceTypeId.Value = o.VehicleMake;
                cmd.Parameters.Add(vgServiceTypeId);

                SqlParameter vgVehicleGroupId = new SqlParameter();
                vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                vgVehicleGroupId.SqlDbType = SqlDbType.VarChar;
                vgVehicleGroupId.Value = o.VehicleGroup;
                cmd.Parameters.Add(vgVehicleGroupId);

                SqlParameter lyt = new SqlParameter();
                lyt.ParameterName = "@LayoutTypeId";
                lyt.SqlDbType = SqlDbType.VarChar;
                lyt.Value = o.LayoutType;
                cmd.Parameters.Add(lyt);


                    SqlParameter insupdflag = new SqlParameter("@flag", SqlDbType.VarChar);
                insupdflag.Value = o.flag;
                cmd.Parameters.Add(insupdflag);

                SqlParameter mssg = new SqlParameter("@mssg", SqlDbType.VarChar,100);
               // mssg.Value = o.flag;
                mssg.Direction = ParameterDirection.Output;                
                cmd.Parameters.Add(mssg);

                cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCompanyGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriversGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                //return null;
            }
        }

        [HttpPost]
        [Route("api/DataLoad/SaveCardsGroup")]
        public HttpResponseMessage SaveCardsGroup(List<CardsGroup> list4)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveVehicleGroups credentials....");

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdCardsGroup";
                cmd.Connection = conn;

                conn.Open();
                foreach (CardsGroup cg in list4)
                {
                    SqlParameter cgCardNumber = new SqlParameter("@CardNumber", SqlDbType.VarChar);
                    cgCardNumber.Value = cg.CardNumber;
                    cmd.Parameters.Add(cgCardNumber);

                    SqlParameter cgCardModel = new SqlParameter();
                    cgCardModel.ParameterName = "@CardModel";
                    cgCardModel.SqlDbType = SqlDbType.VarChar;
                    cgCardModel.Value = cg.CardModel;
                    cmd.Parameters.Add(cgCardModel);

                    SqlParameter cgCardType = new SqlParameter();
                    cgCardType.ParameterName = "@CardType";
                    cgCardType.SqlDbType = SqlDbType.VarChar;
                    cgCardType.Value = cg.CardType;
                    cmd.Parameters.Add(cgCardType);

                    SqlParameter cgCardCategory = new SqlParameter();
                    cgCardCategory.ParameterName = "@CardCategory";
                    cgCardCategory.SqlDbType = SqlDbType.VarChar;
                    cgCardCategory.Value = cg.CardCategory;
                    cmd.Parameters.Add(cgCardCategory);

                    SqlParameter cgStatusId = new SqlParameter();
                    cgStatusId.ParameterName = "@StatusId";
                    cgStatusId.SqlDbType = SqlDbType.VarChar;
                    cgStatusId.Value = cg.Status;
                    cmd.Parameters.Add(cgStatusId);

                    SqlParameter cgUserId = new SqlParameter();
                    cgUserId.ParameterName = "@UserId";
                    cgUserId.SqlDbType = SqlDbType.Int;
                    cgUserId.Value = cg.UserId;
                    cmd.Parameters.Add(cgUserId);

                    SqlParameter cgCustomer = new SqlParameter();
                    cgCustomer.ParameterName = "@Customer";
                    cgCustomer.SqlDbType = SqlDbType.VarChar;
                    cgCustomer.Value = cg.Customer;
                    cmd.Parameters.Add(cgCustomer);

                    SqlParameter cgEffectiveFrom = new SqlParameter();
                    cgEffectiveFrom.ParameterName = "@EffectiveFrom";
                    cgEffectiveFrom.SqlDbType = SqlDbType.DateTime;
                    cgEffectiveFrom.Value = cg.EffectiveFrom;
                    cmd.Parameters.Add(cgEffectiveFrom);

                    SqlParameter cgEffectiveTo = new SqlParameter();
                    cgEffectiveTo.ParameterName = "@EffectiveTo";
                    cgEffectiveTo.SqlDbType = SqlDbType.DateTime;
                    cgEffectiveTo.Value = cg.EffectiveTo;
                    cmd.Parameters.Add(cgEffectiveTo);

                    SqlParameter insupdflag1 = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
                    insupdflag1.Value = cg.insupdflag;
                    cmd.Parameters.Add(insupdflag1);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveCardGroups Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveCardsGroups:" + ex.Message);
                ///return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return null;
            }
        }

        [HttpPost]
        [Route("api/DataLoad/SaveDriverVehicleAssignGroup")]
        public HttpResponseMessage SaveDriverVehicleAssignGroup(List<DriverVehicleAssignGroup> list5)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverVehicleAssignGroup credentials....");

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DriversVehicleAssignGroup";
                cmd.Connection = conn;

                conn.Open();
                foreach (DriverVehicleAssignGroup dva in list5)
                {
                    SqlParameter vgRegNo = new SqlParameter();
                    vgRegNo.ParameterName = "@RegistrationNo";
                    vgRegNo.SqlDbType = SqlDbType.NVarChar;
                    vgRegNo.Value = dva.RegistrationNo;
                    cmd.Parameters.Add(vgRegNo);

                    SqlParameter vgChasisNo = new SqlParameter();
                    vgChasisNo.ParameterName = "@ChasisNo";
                    vgChasisNo.SqlDbType = SqlDbType.NVarChar;
                    vgChasisNo.Value = dva.ChasisNo;
                    cmd.Parameters.Add(vgChasisNo);

                    SqlParameter vgVehicleGroupId = new SqlParameter();
                    vgVehicleGroupId.ParameterName = "@VehicleGroupId";
                    vgVehicleGroupId.SqlDbType = SqlDbType.VarChar;
                    vgVehicleGroupId.Value = dva.VehicleGroup;
                    cmd.Parameters.Add(vgVehicleGroupId);

                    SqlParameter vgVehicleModelId = new SqlParameter();
                    vgVehicleModelId.ParameterName = "@VehicleModelId";
                    vgVehicleModelId.SqlDbType = SqlDbType.VarChar;
                    vgVehicleModelId.Value = dva.VehicleModel;
                    cmd.Parameters.Add(vgVehicleModelId);

                    SqlParameter cv = new SqlParameter();
                    cv.ParameterName = "@CountryId";
                    cv.SqlDbType = SqlDbType.VarChar;
                    cv.Value = dva.Country;
                    cmd.Parameters.Add(cv);

                    SqlParameter vb = new SqlParameter();
                    vb.ParameterName = "@VehicleCode";
                    vb.SqlDbType = SqlDbType.NVarChar;
                    vb.Value = dva.VehicleCode;
                    cmd.Parameters.Add(vb);

                    SqlParameter fg = new SqlParameter();
                    fg.ParameterName = "@FleetOwnerId";
                    fg.SqlDbType = SqlDbType.Int;
                    fg.Value = dva.FleetOwner;
                    cmd.Parameters.Add(fg);

                    SqlParameter vgEngineNo = new SqlParameter();
                    vgEngineNo.ParameterName = "@Engineno";
                    vgEngineNo.SqlDbType = SqlDbType.NVarChar;
                    vgEngineNo.Value = dva.Engineno;
                    cmd.Parameters.Add(vgEngineNo);

                    SqlParameter vgType = new SqlParameter();
                    vgType.ParameterName = "@VehicleType";
                    vgType.SqlDbType = SqlDbType.NVarChar;
                    vgType.Value = dva.vehicleType;
                    cmd.Parameters.Add(vgType);

                    SqlParameter vgServiceTypeId = new SqlParameter();
                    vgServiceTypeId.ParameterName = "@VehicleMakeId";
                    vgServiceTypeId.SqlDbType = SqlDbType.VarChar;
                    vgServiceTypeId.Value = dva.VehicleMake;
                    cmd.Parameters.Add(vgServiceTypeId);


                    SqlParameter vgVechMobileNo = new SqlParameter();
                    vgVechMobileNo.ParameterName = "@DriverId";
                    vgVechMobileNo.SqlDbType = SqlDbType.Int;
                    vgVechMobileNo.Value = dva.DriverId;
                    cmd.Parameters.Add(vgVechMobileNo);


                    SqlParameter vgMYear = new SqlParameter();
                    vgMYear.ParameterName = "@ModelYear";
                    vgMYear.SqlDbType = SqlDbType.NVarChar;
                    vgMYear.Value = dva.ModelYear;
                    cmd.Parameters.Add(vgMYear);

                    SqlParameter vgInsuNo = new SqlParameter();
                    vgInsuNo.ParameterName = "@HasAC";
                    vgInsuNo.SqlDbType = SqlDbType.Int;
                    vgInsuNo.Value = dva.HasAC;
                    cmd.Parameters.Add(vgInsuNo);


                    SqlParameter vgDayOnly = new SqlParameter();
                    vgDayOnly.ParameterName = "@IsDriverowned";
                    vgDayOnly.SqlDbType = SqlDbType.Int;
                    vgDayOnly.Value = dva.IsDriverowned;
                    cmd.Parameters.Add(vgDayOnly);                 


                    SqlParameter vgCompanyVeh = new SqlParameter();
                    vgCompanyVeh.ParameterName = "@StatusId";
                    vgCompanyVeh.SqlDbType = SqlDbType.VarChar;
                    vgCompanyVeh.Value = dva.StatusId;
                    cmd.Parameters.Add(vgCompanyVeh);

                    SqlParameter vgOwnerPhoneNo = new SqlParameter();
                    vgOwnerPhoneNo.ParameterName = "@IsVerified";
                    vgOwnerPhoneNo.SqlDbType = SqlDbType.Int;
                    vgOwnerPhoneNo.Value = dva.IsVerified;
                    cmd.Parameters.Add(vgOwnerPhoneNo);
                    

                    SqlParameter vgEntryDate = new SqlParameter();
                    vgEntryDate.ParameterName = "@EntryDate";
                    vgEntryDate.SqlDbType = SqlDbType.DateTime;
                    vgEntryDate.Value = dva.EntryDate;
                    cmd.Parameters.Add(vgEntryDate);

                    SqlParameter fd = new SqlParameter();
                    fd.ParameterName = "@FirstName";
                    fd.SqlDbType = SqlDbType.VarChar;
                    fd.Value = dva.FirstName;
                    cmd.Parameters.Add(fd);

                    SqlParameter gf = new SqlParameter();
                    gf.ParameterName = "@LastName";
                    gf.SqlDbType = SqlDbType.VarChar;
                    gf.Value = dva.LastName;
                    cmd.Parameters.Add(gf);

                    SqlParameter dgPM = new SqlParameter();
                    dgPM.ParameterName = "@PMobNo";
                    dgPM.SqlDbType = SqlDbType.VarChar;
                    dgPM.Value = dva.MobileNumber;
                    cmd.Parameters.Add(dgPM);

                    SqlParameter dgAddr = new SqlParameter();
                    dgAddr.ParameterName = "@Address";
                    dgAddr.SqlDbType = SqlDbType.VarChar;
                    dgAddr.Value = dva.Address;
                    cmd.Parameters.Add(dgAddr);

                    SqlParameter dgpadr = new SqlParameter();
                    dgpadr.ParameterName = "@PAddress";
                    dgpadr.SqlDbType = SqlDbType.VarChar;
                    dgpadr.Value = dva.PermanentAddress;
                    cmd.Parameters.Add(dgpadr);

                    SqlParameter dgppin = new SqlParameter();
                    dgppin.ParameterName = "@Pin";
                    dgppin.SqlDbType = SqlDbType.VarChar;
                    dgppin.Value = dva.Pin;
                    cmd.Parameters.Add(dgppin);

                    SqlParameter dgPPin = new SqlParameter();
                    dgPPin.ParameterName = "@PPin";
                    dgPPin.SqlDbType = SqlDbType.VarChar;
                    dgPPin.Value = dva.PermanentPin;
                    cmd.Parameters.Add(dgPPin);

                    SqlParameter yt = new SqlParameter();
                    yt.ParameterName = "@EmailId";
                    yt.SqlDbType = SqlDbType.VarChar;
                    yt.Value = dva.EmailId;
                    cmd.Parameters.Add(yt);

                    SqlParameter dc = new SqlParameter();
                    dc.ParameterName = "@DriverCode";
                    dc.SqlDbType = SqlDbType.VarChar;
                    dc.Value = dva.DriverCode;
                    cmd.Parameters.Add(dc);

                    SqlParameter cs = new SqlParameter();
                    cs.ParameterName = "@CurrentStateId";
                    cs.SqlDbType = SqlDbType.VarChar;
                    cs.Value = dva.CurrentStateId;
                    cmd.Parameters.Add(cs);

                    SqlParameter lyt = new SqlParameter();
                    lyt.ParameterName = "@LayoutTypeId";
                    lyt.SqlDbType = SqlDbType.VarChar;
                    lyt.Value = dva.LayoutType;
                    cmd.Parameters.Add(lyt);

                    SqlParameter cmp = new SqlParameter();
                    cmp.ParameterName = "@CompanyId";
                    cmp.SqlDbType = SqlDbType.VarChar;
                    cmp.Value = dva.Company;
                    cmd.Parameters.Add(cmp);


                    SqlParameter dvaflag = new SqlParameter("@flag", SqlDbType.VarChar);
                    dvaflag.Value = dva.inspudflag;
                    cmd.Parameters.Add(dvaflag);

                    cmd.ExecuteScalar();
                    cmd.Parameters.Clear();

                }
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "DriverVehicleAssignGroup Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                string str2 = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveDriverVehicleAssignGroup:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
               // return ;

            }
        }
    }
}
