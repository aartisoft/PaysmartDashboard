using PaySmartDashboard;
using PaySmartDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace PaySmartDashboard.Controllers
{
    public class DemoRequestController : ApiController
    {
        [HttpGet]
        [Route("api/DemoRequest/GetDemoRequest")]
        public DataTable GetDemoRequest()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDemorequest";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
        [HttpPost]
        [Route("api/DemoRequest/SaveDemoDetails")]
        public DataTable SaveDemoDetails(DemoRequest b)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDemoRequest";

                cmd.Connection = conn;

                SqlParameter i = new SqlParameter("@flag", SqlDbType.VarChar);
                i.Value = b.flag;
                cmd.Parameters.Add(i);

                SqlParameter ie = new SqlParameter("@Id", SqlDbType.Int);
                ie.Value = b.Id;
                cmd.Parameters.Add(ie);

                SqlParameter cm = new SqlParameter("@Email", SqlDbType.VarChar, 250);
                cm.Value = b.email;
                cmd.Parameters.Add(cm);

                SqlParameter bd = new SqlParameter("@MobileNumber", SqlDbType.VarChar, 50);
                bd.Value = b.mobile;
                cmd.Parameters.Add(bd);

                SqlParameter stat = new SqlParameter("@Status", SqlDbType.VarChar, 50);
                stat.Value = b.statusid;
                cmd.Parameters.Add(stat);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                #region Demo
                string email = dt.Rows[0]["Email"].ToString();
                string dpwd = dt.Rows[0]["DashboardPwd"].ToString();
                string cotp = dt.Rows[0]["OtpCustomerApp"].ToString();
                string bname = dt.Rows[0]["BusinessAppUsername"].ToString();
                string botp = dt.Rows[0]["OtpBusinessApp"].ToString();
                if (email != null)
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
                        mail.To.Add(b.email);
                        mail.Subject = "PaySmart Demo Credentials";
                        mail.IsBodyHtml = true;

                        string samplemail = @"<div>
                                         <p>Hi,</p>
                                         <p>Thanks for requesting demo of PaySmart.</p>
                                        <p>We have set up a basic demo for your evaluation. The demo is setup for the city Hyderabad with currency INR, English as the language. One driver is automatically registered by us whose credentials we have mentioned below. You can go through the complete ride flow in the demo. If there are any issues, please refer to this <a href='http://196.27.119.221:53800/UI/DemoRequest.html'>Demo setup video</a> or feel free to connect with us by replying back to this email.</p>

                                              <p>Your PaySmart Demo credentials and links are here.</p>
                                              <p><a href='http://196.27.119.220:1476/Login.html'>Dashboard Link</a><br/>
                                              Username:  " + bname + @"<br/> 
                                              Password:" + dpwd + @"</p>

                                               <p>Customer App Link:<a href='http://196.27.119.221:53800/UI/Apks/CustomerApp.html'>Android , </a><a href='http://196.27.119.221:53800/UI/Apks/CustomerApp.html'>IOS</a><br/>
                                               You can login with any phone number in the customer app.<br/> 
                                               A 4 digit OTP will come as an SMS, please enter it.<br/>  
                                               Again, on the next screen you need to enter this six digit demo passcode : " + cotp + @"</p>

                                              <p>Driver App: <a href='http://196.27.119.221:53800/UI/Apks/DriverApp.html'>Android</a><a href='http://196.27.119.221:53800/UI/Apks/DriverApp.html'>IOS</a><br/> 
                                               Driver Mobile Number: " + bname + @"<br/> 
                                               OTP: " + botp + @"</p>  
                                               <p>PaySmart</p>
                                           

                                                   </div>";

                        //                        string verifcodeMail = @"<table>
                        //                                                        <tr>
                        //                                                            <td>
                        //                                                                <h2>Thank you for signing up with PaySmart</h2>
                        //                                                                <table width=\""760\"" align=\""center\"">
                        //                                                                    <tbody style='background-color:#F0F8FF;'>
                        //                                                                        <tr>
                        //                                                                            <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
                        //<div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />

                        //                                                       Your Vehicle is Booked:<h3>" + eotp + @" </h3>

                        //                                                        If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.

                        //                                                                                <br/>
                        //                                                                                <br/>             

                        //                                                                                Warm regards,<br>
                        //                                                                                PAYSMART Customer Service Team<br/><br />
                        //</div>
                        //                                                                            </td>
                        //                                                                        </tr>

                        //                                                                    </tbody>
                        //                                                                </table>
                        //                                                            </td>
                        //                                                        </tr>

                        //                                                    </table>";

                        mail.Body = samplemail;
                        //mail.Body = verifcodeMail;
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
                        //throw ex;
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
                    }
                }
                #endregion Demo




            }
            catch (Exception ex)
            {

                throw ex;
                //throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));

            }
            finally
            {
                conn.Close();
                conn.Dispose();
                SqlConnection.ClearPool(conn);
            }
            return dt;
        }
    }
}
