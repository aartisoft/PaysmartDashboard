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
using QRCoder;
using System.Drawing;
using System.IO;
using System.Web.Http.Tracing;
using System.Net.Mail;

namespace PaySmartDashboard.Controllers
{
    public class DriverMasterController : ApiController
    {
       
        [HttpGet]
        [Route("api/DriverMaster/GetMaster")]
        public DataTable GetMaster(int ctryId)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetdrivermaster";
            cmd.Parameters.Add("@ctryId", SqlDbType.Int).Value = ctryId;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpGet]
        [Route("api/DriverMaster/Getdriverdetails")]
        public DataSet Getdriverdetails(int DId)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection();
            try { 
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVgetdriverdetails";
            cmd.Parameters.Add("@DId", SqlDbType.Int).Value = DId;
            cmd.Connection = conn;
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);           

            
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
            return ds;
        }

        [HttpGet]
        [Route("api/DriverMaster/GetBankdetails")]
        public DataTable GetBankdetails(int DId)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVGetbankingdetails";
            cmd.Parameters.Add("@DId", SqlDbType.Int).Value = DId;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }


        [HttpGet]
        [Route("api/DriverMaster/GetDriverApproval")]
        public DataTable GetDriverApproval(String MobileNo)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSGetDriverApproval";
            cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = MobileNo;
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            dt = ds.Tables[0];

            return dt;

        }

        [HttpPost]
        [Route("api/DriverMaster/Driverlist")]
        public DataTable Driverlist(driverdetails d)
        {
            SqlConnection conn = new SqlConnection();
            try { 
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HVInsUpddrivers";
            cmd.Connection = conn;

            SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
            ff.Value = d.flag;
            cmd.Parameters.Add(ff);

            SqlParameter i = new SqlParameter("@DId", SqlDbType.Int);
            i.Value = d.DId;
            cmd.Parameters.Add(i);

            SqlParameter di = new SqlParameter("@CountryId", SqlDbType.VarChar, 50);
            di.Value = d.Country;
            cmd.Parameters.Add(di);

            SqlParameter n = new SqlParameter("@NAme", SqlDbType.VarChar, 50);
            n.Value = d.Name;
            cmd.Parameters.Add(n);

            SqlParameter r = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            r.Value = d.Address;
            cmd.Parameters.Add(r);

            SqlParameter f = new SqlParameter("@PAddress", SqlDbType.VarChar, 50);
            f.Value = d.PermanentAddress;
            cmd.Parameters.Add(f);

            SqlParameter s = new SqlParameter("@Pin", SqlDbType.VarChar, 50);
            s.Value = d.Pin;
            cmd.Parameters.Add(s);

            SqlParameter g = new SqlParameter("@PPin", SqlDbType.VarChar, 50);
            g.Value = d.PermanentPin;
            cmd.Parameters.Add(g);

            SqlParameter j = new SqlParameter("@PMobNo", SqlDbType.VarChar, 255);
            j.Value = d.Mobilenumber;
            cmd.Parameters.Add(j);

            SqlParameter fr = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
            fr.Value = d.FirstName;
            cmd.Parameters.Add(fr);

            SqlParameter lk = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
            lk.Value = d.LastName;
            cmd.Parameters.Add(lk);


            SqlParameter ed = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
            ed.Value = d.EmailId;
            cmd.Parameters.Add(ed);

            SqlParameter dc = new SqlParameter("@DriverCode", SqlDbType.VarChar);
            dc.Value = d.drivercode;
            cmd.Parameters.Add(dc);

            SqlParameter pr = new SqlParameter("@Photo", SqlDbType.VarChar);
            pr.Value = d.Photo;
            cmd.Parameters.Add(pr);

            SqlParameter bg = new SqlParameter("@BloodGroup", SqlDbType.VarChar);
            bg.Value = d.BloodGroup;
            cmd.Parameters.Add(bg);

            SqlParameter df = new SqlParameter("@DOB", SqlDbType.DateTime);
            df.Value = d.DOB;
            cmd.Parameters.Add(df);

            SqlParameter dfs = new SqlParameter("@DOJ", SqlDbType.DateTime);
            dfs.Value = d.DOJ;

            cmd.Parameters.Add(dfs);

            SqlParameter sd = new SqlParameter("@Status", SqlDbType.Int);
            sd.Value = d.Status;
            cmd.Parameters.Add(sd);

            SqlParameter vf = new SqlParameter("@VehicleGroupId", SqlDbType.Int);
            vf.Value = d.VehicleGroup;
            cmd.Parameters.Add(vf);

            SqlParameter gf = new SqlParameter("@IsVerified", SqlDbType.Int);
            gf.Value = d.IsVerified;
            cmd.Parameters.Add(gf);

            SqlParameter hd = new SqlParameter("@IsApproved", SqlDbType.Int);
            hd.Value = d.IsApproved;
            cmd.Parameters.Add(hd);

            SqlParameter cdd = new SqlParameter("@CurrentStateId", SqlDbType.Int);
            cdd.Value = d.CurrentStateId;
            cmd.Parameters.Add(cdd);

            SqlParameter ptt = new SqlParameter("@PaymentTypeId", SqlDbType.Int);
            ptt.Value = d.PaymentTypeId;
            cmd.Parameters.Add(ptt);


                DataTable dt = new DataTable();
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

        [HttpPost]
        [Route("api/DriverMaster/SaveDriverDoc")]
        public DataTable SaveDriverDoc(DriverDocuments a)
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
                cmd.CommandText = "HVInsUpdDelDriverDocs";
                cmd.Connection = conn;

                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = a.Id;
                cmd.Parameters.Add(id);

                SqlParameter AssetId = new SqlParameter("@DriverId", SqlDbType.Int);
                AssetId.Value = a.DriverId;
                cmd.Parameters.Add(AssetId);

                SqlParameter Gid = new SqlParameter("@FileName", SqlDbType.VarChar, 100);
                Gid.Value = a.docName;
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
                parentid.Value = a.docContent;
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
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/DriverMaster/Bankingdetails")]
        public DataTable Bankingdetails(bankdetails b)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HVInsUpdBankingdetails";
                cmd.Connection = conn;

                SqlParameter ff = new SqlParameter("@flag", SqlDbType.VarChar);
                ff.Value = b.flag;
                cmd.Parameters.Add(ff);

                SqlParameter i = new SqlParameter("@Id", SqlDbType.Int);
                i.Value = b.Id;
                cmd.Parameters.Add(i);                

                SqlParameter n = new SqlParameter("@Accountnumber", SqlDbType.VarChar, 50);
                n.Value = b.Accountnumber;
                cmd.Parameters.Add(n);

                SqlParameter r = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
                r.Value = b.BankName;
                cmd.Parameters.Add(r);


                SqlParameter a = new SqlParameter("@BankCode", SqlDbType.VarChar, 50);
                a.Value = b.Bankcode;
                cmd.Parameters.Add(a);

                SqlParameter s = new SqlParameter("@BranchAddress", SqlDbType.VarChar, 50);
                s.Value = b.BranchAddress;
                cmd.Parameters.Add(s);                

                SqlParameter j2 = new SqlParameter("@CountryId", SqlDbType.VarChar,50);
                j2.Value = b.Country;
                cmd.Parameters.Add(j2);

                SqlParameter f = new SqlParameter("@IsActive", SqlDbType.Int);
                f.Value = b.IsActive;
                cmd.Parameters.Add(f);

                SqlParameter ddd = new SqlParameter("@DriverId", SqlDbType.Int);
                ddd.Value = b.DriverId;
                cmd.Parameters.Add(ddd);

                SqlParameter er = new SqlParameter("@QRCode", SqlDbType.VarChar);
                er.Value = b.qrcode;
                cmd.Parameters.Add(er);

                SqlParameter Code1 = new SqlParameter("@Code", SqlDbType.VarChar);
                Code1.Value = b.DriverCode;
                cmd.Parameters.Add(Code1);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //update the qr code 
                if (dt.Rows.Count > 0) {
                    i.Value = dt.Rows[0]["Id"].ToString();
                    var code = dt.Rows[0]["Code"].ToString();
                    if (code != "") {
                        ff.Value = "U";
                        var qrcode = GetQRCode(code);
                        er.Value = qrcode;

                        Code1.Value = code;
                        dt = new DataTable();                        
                        da.Fill(dt);
                    }
                }
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

        private string GetQRCode(string code)
        {
            string str = "";
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)3;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {

                       Bitmap img = qrCode.GetGraphic(20, Color.Black, Color.White,
                            null, 15);
                        str = ImageToBase64((Image)img, System.Drawing.Imaging.ImageFormat.Png);
                        str = "data:image/jpeg;base64," + str;
                    }
                }
            }

            return str;
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        [HttpGet]
        [Route("api/DriverMaster/CurrentState")]
        public DataTable CurrentState(int DId)
        {
            DataTable dt = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();

            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "CurrentState....");

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSGetCurrentDriverStatus";
                cmd.Parameters.Add("@DId", SqlDbType.Int).Value = DId;
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(dt);

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "CurrentState successful....");

            }
            catch (Exception ex)
            {
                traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "CurrentState...." + ex.Message.ToString());
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                SqlConnection.ClearPool(conn);
            }
            return dt;

        }

        [HttpGet]
        [Route("api/DriverMaster/FileContent")]
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
        [Route("api/DriverMaster/DocumentVerification")]
        public DataTable DocumentVerification(DriverDocuments d)
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
                cmd.CommandText = "PSinsupddriverdocsverifying";
                cmd.Connection = conn;

                SqlParameter AssetId = new SqlParameter("@DriverId", SqlDbType.Int);
                AssetId.Value = d.DriverId;
                cmd.Parameters.Add(AssetId);

                SqlParameter rootassetid = new SqlParameter("@DocType", SqlDbType.VarChar);
                rootassetid.Value = d.docType;
                cmd.Parameters.Add(rootassetid);


                SqlParameter flag = new SqlParameter("@change", SqlDbType.VarChar);
                flag.Value = d.insupddelflag;
                cmd.Parameters.Add(flag);

                SqlParameter ver = new SqlParameter("@IsVerified", SqlDbType.Int);
                ver.Value = d.isVerified;
                cmd.Parameters.Add(ver);


                SqlParameter IA = new SqlParameter("@IsApproved", SqlDbType.Int);
                IA.Value = d.IsApproved;
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


        [HttpPost]
        [Route("api/DriverMaster/SaveDriverApprovals")]
        public DataTable SaveDriverApprovals(Approvals a)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PSinsupddriverApprovals";
                cmd.Connection = conn;


                SqlParameter LocationId = new SqlParameter("@Change", SqlDbType.VarChar);
                LocationId.Value = a.change;
                cmd.Parameters.Add(LocationId);

                SqlParameter parentid = new SqlParameter("@IsApproved", SqlDbType.Int);
                parentid.Value = a.IsApproved;
                cmd.Parameters.Add(parentid);

                SqlParameter flag = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                flag.Value = a.MobileNo;
                cmd.Parameters.Add(flag);               

               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                #region email opt
                string eotp = dt.Rows[0]["Email"].ToString();
                if (eotp != null)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();

                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add(fromaddress);
                        mail.Subject = "Driver Approval";
                        mail.IsBodyHtml = true;

                        string verifcodeMail = @"<table>
                                                        <tr>
                                                            <td>
                                                                <h2>Thank you for registering with PaySmart APP</h2>
                                                                <table width=\""760\"" align=\""center\"">
                                                                    <tbody style='background-color:#F0F8FF;'>
                                                                        <tr>
                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
<div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />
                                                                             
                                                       Driver has been Approved for:<h3>" + eotp + @" </h3>

                                                        If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.

                                                                                <br/>
                                                                                <br/>             
                                                                       
                                                                                Warm regards,<br>
                                                                                PAYSMART Customer Service Team<br/><br />
</div>
                                                                            </td>
                                                                        </tr>

                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                    </table>";


                        mail.Body = verifcodeMail;
                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        traceWriter.Trace(Request, "0", TraceLevel.Error, "{0}", "Register driver Email otp failed...." + ex.Message);
                        throw ex;
                    }

                }

                //send mobile otp


                // return dt;

                #endregion email otp                              
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw ex;
            }
            return dt;
        }

    }
}
