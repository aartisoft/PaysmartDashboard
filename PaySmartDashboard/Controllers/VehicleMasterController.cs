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
    public class VehicleMasterController : ApiController
    {
        [HttpGet]
        [Route("api/VehicleMaster/GetVehcileList")]
        public DataTable GetVehcileList(int ctryId, int fid,int vgId)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetVehicleList";            
            cmd.Connection = conn;
            cmd.Parameters.Add("@ctryId", SqlDbType.Int).Value = ctryId;
            cmd.Parameters.Add("@fleetId", SqlDbType.Int).Value = fid;
            cmd.Parameters.Add("@vgId", SqlDbType.Int).Value = vgId;
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);            
            return dt;
        }

        [HttpGet]
        [Route("api/VehicleMaster/GetVehcileMaster")]
        public DataTable GetVehcileMaster(int VID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSgetvehilcetypes";
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/VehicleMaster/GetVehcileDetails")]
        public DataSet GetVehcileDetails(int VID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSgetvehicleDetails";
            cmd.Parameters.Add("@VID", SqlDbType.Int).Value = VID;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            
            return ds;

        }

        [HttpGet]
        [Route("api/DriverMaster/GetVehicleApproval")]
        public DataTable GetVehicleApproval(String RegNo)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetVehicleApproval";
            cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar).Value = RegNo;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpPost]
        [Route("api/VehicleMaster/Vehicles")]
        public DataTable Vehicles(vehiclemas v)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdVehicles";
            cmd.Connection = conn;


            SqlParameter se = new SqlParameter("@flag", SqlDbType.VarChar);
            se.Value = v.flag;
            cmd.Parameters.Add(se);


            SqlParameter s = new SqlParameter("@Id", SqlDbType.Int);
            s.Value = v.Id;
            cmd.Parameters.Add(s);

            SqlParameter i = new SqlParameter("@VID", SqlDbType.Int);
            i.Value = v.VID;
            cmd.Parameters.Add(i);

            SqlParameter cd = new SqlParameter("@CompanyId", SqlDbType.Int);
            cd.Value = v.CompanyId;
            cmd.Parameters.Add(cd);

            SqlParameter n = new SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50);
            n.Value = v.RegistrationNo;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            r.Value = v.Type;
            cmd.Parameters.Add(r);

            SqlParameter a = new SqlParameter("@OwnerName", SqlDbType.VarChar, 50);
            a.Value = v.OwnerName;
            cmd.Parameters.Add(a);           

            SqlParameter jw = new SqlParameter("@CompanyVechile", SqlDbType.Int);
            jw.Value = v.CompanyVechile;
            cmd.Parameters.Add(jw);

            SqlParameter wj = new SqlParameter("@OwnerPhoneNo", SqlDbType.VarChar, 50);
            wj.Value = v.OwnerPhoneNo;
            cmd.Parameters.Add(wj);

            SqlParameter wh = new SqlParameter("@HomeLandmark", SqlDbType.VarChar, 50);
            wh.Value = v.HomeLandmark;
            cmd.Parameters.Add(wh);

            SqlParameter wg = new SqlParameter("@ModelYear", SqlDbType.VarChar);
            wg.Value = v.ModelYear;
            cmd.Parameters.Add(wg);

            SqlParameter wf = new SqlParameter("@DayOnly", SqlDbType.VarChar, 50);
            wf.Value = v.DayOnly;
            cmd.Parameters.Add(wf);            

            SqlParameter ca = new SqlParameter("@VechMobileNo", SqlDbType.VarChar, 50);
            ca.Value = v.VechMobileNo;
            cmd.Parameters.Add(ca);

            SqlParameter ws = new SqlParameter("@EntryDate", System.Data.SqlDbType.Date);
            ws.Value = v.EntryDate;
            cmd.Parameters.Add(ws);

            SqlParameter wsd = new SqlParameter("@NewEntry", SqlDbType.VarChar, 50);
            wsd.Value = v.NewEntry;
            cmd.Parameters.Add(wsd);

            SqlParameter vv = new SqlParameter("@VehicleModelId", SqlDbType.Int);
            vv.Value = v.VehicleModelId;
            cmd.Parameters.Add(vv);

            SqlParameter vf = new SqlParameter("@ServiceTypeId", SqlDbType.Int);
            vf.Value = v.ServiceTypeId;
            cmd.Parameters.Add(vf);

            SqlParameter vg = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vg.Value = v.VehicleGroupId;
            cmd.Parameters.Add(vg);

            SqlParameter pp = new SqlParameter("@Photo", SqlDbType.VarChar);
            pp.Value = v.photo;
            cmd.Parameters.Add(pp);

            SqlParameter ss = new SqlParameter("@Status", SqlDbType.VarChar);
            ss.Value = v.photo;
            cmd.Parameters.Add(ss);

            SqlParameter fl = new SqlParameter("@FleetOwnerCode", SqlDbType.VarChar);
            fl.Value = v.Fleetcode;
            cmd.Parameters.Add(fl);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/VehicleMaster/Vehicle")]
        public DataTable Vehicle(vehiclemas v)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpdVehicle";
            cmd.Connection = conn;


            SqlParameter se = new SqlParameter("@flag", SqlDbType.VarChar);
            se.Value = v.flag;
            cmd.Parameters.Add(se);

            SqlParameter s = new SqlParameter("@Id", SqlDbType.Int);
            s.Value = v.Id;
            cmd.Parameters.Add(s);

            SqlParameter i = new SqlParameter("@VID", SqlDbType.Int);
            i.Value = v.VID;
            cmd.Parameters.Add(i);

            SqlParameter cd = new SqlParameter("@CompanyId", SqlDbType.Int);
            cd.Value = v.CompanyId;
            cmd.Parameters.Add(cd);

            SqlParameter n = new SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50);
            n.Value = v.RegistrationNo;
            cmd.Parameters.Add(n);

            SqlParameter cn = new SqlParameter("@ChasisNo", SqlDbType.VarChar, 50);
            cn.Value = v.ChasisNo;
            cmd.Parameters.Add(cn);

            SqlParameter en = new SqlParameter("@Engineno", SqlDbType.VarChar, 50);
            en.Value = v.Engineno;
            cmd.Parameters.Add(en);

            SqlParameter oid = new SqlParameter("@FleetOwnerId", SqlDbType.Int);
            oid.Value = v.OwnerId;
            cmd.Parameters.Add(oid);

            SqlParameter vt = new SqlParameter("@VehicleTypeId", SqlDbType.Int);
            vt.Value = v.VehicleTypeId;
            cmd.Parameters.Add(vt);

            SqlParameter vv = new SqlParameter("@VehicleModelId", SqlDbType.Int);
            vv.Value = v.VehicleModelId;
            cmd.Parameters.Add(vv);

            SqlParameter vg = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vg.Value = v.VehicleGroupId;
            cmd.Parameters.Add(vg);            

            SqlParameter wg = new SqlParameter("@ModelYear", SqlDbType.VarChar,5);
            wg.Value = v.ModelYear;
            cmd.Parameters.Add(wg);

            SqlParameter ac = new SqlParameter("@HasAC", SqlDbType.Int);
            ac.Value = v.HasAC;
            cmd.Parameters.Add(ac);

            SqlParameter sid = new SqlParameter("@StatusId", SqlDbType.Int);
            sid.Value = v.StatusId;
            cmd.Parameters.Add(sid);

            SqlParameter isv = new SqlParameter("@IsVerified", SqlDbType.Int);
            isv.Value = v.IsVerified;
            cmd.Parameters.Add(isv);

            SqlParameter isDriverOwned = new SqlParameter("@isDriverOwned", SqlDbType.Int);
            isDriverOwned.Value = v.isDriverOwned;
            cmd.Parameters.Add(isDriverOwned); 
                    

            SqlParameter vcode = new SqlParameter("@VehicleCode ", SqlDbType.VarChar,10);
            vcode.Value = v.VehicleCode;
            cmd.Parameters.Add(vcode);

            SqlParameter pr = new SqlParameter("@Photo", SqlDbType.VarChar);
            pr.Value = v.Photo;
            cmd.Parameters.Add(pr);

            SqlParameter ctr = new SqlParameter("@CountryId", SqlDbType.Int);
            ctr.Value = v.CountryId;
            cmd.Parameters.Add(ctr);

            SqlParameter fi = new SqlParameter("@FrontImage", SqlDbType.VarChar);
            fi.Value = v.FrontImage;
            cmd.Parameters.Add(fi);

            SqlParameter bi = new SqlParameter("@BackImage", SqlDbType.VarChar);
            bi.Value = v.BackImage;
            cmd.Parameters.Add(bi);

            SqlParameter ri = new SqlParameter("@RightImage", SqlDbType.VarChar);
            ri.Value = v.RightImage;
            cmd.Parameters.Add(ri);

            SqlParameter li = new SqlParameter("@LeftImage", SqlDbType.VarChar);
            li.Value = v.LeftImage;
            cmd.Parameters.Add(li);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        [HttpPost]
        [Route("api/VehicleMaster/SaveVehicleDoc")]
        public DataTable SaveVehicleDoc(VehicleDocuments a)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpdDelVehicleDocs";
                cmd.Connection = conn;
        
                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = a.Id;
                cmd.Parameters.Add(id);

                SqlParameter AssetId = new SqlParameter("@VehicleId", SqlDbType.Int);
                AssetId.Value = a.VehicleId;
                cmd.Parameters.Add(AssetId);

                SqlParameter Gid = new SqlParameter("@FileName", SqlDbType.VarChar, 100);
                Gid.Value = a.FileName;
                cmd.Parameters.Add(Gid);               

                SqlParameter rootassetid = new SqlParameter("@DocTypeId", SqlDbType.Int);
                rootassetid.Value = a.docTypeId;
                cmd.Parameters.Add(rootassetid);

                SqlParameter AsstMDLHierarID = new SqlParameter("@UpdatedById", SqlDbType.Int);
                AsstMDLHierarID.Value = a.UpdatedById;
                cmd.Parameters.Add(AsstMDLHierarID);

                SqlParameter assetModelId = new SqlParameter("@ExpiryDate", SqlDbType.Date);
                assetModelId.Value = a.expiryDate;
                cmd.Parameters.Add(assetModelId);


                SqlParameter LocationId = new SqlParameter("@DueDate", SqlDbType.Date);
                LocationId.Value = a.dueDate;
                cmd.Parameters.Add(LocationId);

                SqlParameter parentid = new SqlParameter("@FileContent", SqlDbType.VarChar);
                parentid.Value = a.FileContent;
                cmd.Parameters.Add(parentid);

                SqlParameter flag = new SqlParameter("@change", SqlDbType.VarChar);
                flag.Value = a.insupddelflag;
                cmd.Parameters.Add(flag);

                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
                loggedinUserId1.Value = a.UpdatedById;
                cmd.Parameters.Add(loggedinUserId1);

                 SqlParameter doc = new SqlParameter("@DocumentNo", SqlDbType.VarChar, 50);
                 doc.Value = a.DocumentNo;
                 cmd.Parameters.Add(doc);

                 SqlParameter doc2 = new SqlParameter("@DocumentNo2", SqlDbType.VarChar, 50);
                 doc2.Value = a.DocumentNo2;
                 cmd.Parameters.Add(doc2);

                 SqlParameter ver = new SqlParameter("@IsVerified", SqlDbType.Int);
                 ver.Value = a.isVerified;
                 cmd.Parameters.Add(ver);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                
                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                
                return dt;
            }
        }


        [HttpPost]
        [Route("api/VehicleMaster/DocumentVerification")]
        public DataTable DocumentVerification(VehicleDocuments v)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSinsupdvehicledocsverifying";
                cmd.Connection = conn;

                SqlParameter AssetId = new SqlParameter("@VehicleId", SqlDbType.Int);
                AssetId.Value = v.VehicleId;
                cmd.Parameters.Add(AssetId);

                SqlParameter rootassetid = new SqlParameter("@DocType", SqlDbType.VarChar);
                rootassetid.Value = v.docType;
                cmd.Parameters.Add(rootassetid);

                
                SqlParameter flag = new SqlParameter("@change", SqlDbType.VarChar);
                flag.Value = v.insupddelflag;
                cmd.Parameters.Add(flag);               

                SqlParameter ver = new SqlParameter("@IsVerified", SqlDbType.Int);
                ver.Value = v.isVerified;
                cmd.Parameters.Add(ver);


                SqlParameter IA = new SqlParameter("@IsApproved", SqlDbType.Int);
                IA.Value = v.IsApproved;
                cmd.Parameters.Add(IA);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                return dt;
            }
        }


        [HttpGet]
        [Route("api/VehicleMaster/FileContent")]
        public DataTable FileContent(int docId, int docCategoryId)
        {

            DataTable Tbl = new DataTable();
            try
            {

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSGetFileContent";
                cmd.Connection = conn;

                SqlParameter mid = new SqlParameter("@FileId", SqlDbType.Int);
                mid.Value = docId;
                cmd.Parameters.Add(mid);

                SqlParameter catId = new SqlParameter("@Category", SqlDbType.Int);
                catId.Value = docCategoryId;
                cmd.Parameters.Add(catId);

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Tbl;
        }


        [HttpPost]
        [Route("api/VehicleMaster/SaveVehicleApprovals")]
        public DataTable SaveVehicleApprovals(Approvals a)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSinsupdVehicleApprovals";
                cmd.Connection = conn;


                SqlParameter LocationId = new SqlParameter("@Change", SqlDbType.VarChar);
                LocationId.Value = a.change;
                cmd.Parameters.Add(LocationId);

                SqlParameter parentid = new SqlParameter("@IsApproved", SqlDbType.Int);
                parentid.Value = a.IsApproved;
                cmd.Parameters.Add(parentid);

                SqlParameter flag = new SqlParameter("@RegistrationNo", SqlDbType.VarChar);
                flag.Value = a.RegistrationNo;
                cmd.Parameters.Add(flag);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                return dt;
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
        }
    }
}
