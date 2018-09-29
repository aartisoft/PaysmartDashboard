using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaySmartDashboard.Models;

namespace PaySmartDashboard.Controllers
{
    public class faqsController : ApiController
    {

        public DataTable Getlist()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Getfaqs";
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }



        [HttpPost]
        [Route("api/FAQs/SaveFAQs")]
        public int SaveFAQs(faqs fi)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFAQs";

            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Value = fi.Id;
            cmd.Parameters.Add(id);

            SqlParameter q = new SqlParameter("@Question", SqlDbType.VarChar, 100);
            q.Value = fi.Question;
            cmd.Parameters.Add(q);

            SqlParameter a = new SqlParameter("@Answer", SqlDbType.VarChar, 500);
            a.Value = fi.Answer;
            cmd.Parameters.Add(a);


            SqlParameter cb = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
            cb.Value = fi.CreatedBy;
            cmd.Parameters.Add(cb);

            SqlParameter at = new SqlParameter("@AppType", SqlDbType.Int);
            at.Value = fi.AppType;
            cmd.Parameters.Add(at);

            SqlParameter c = new SqlParameter("@Category", SqlDbType.Int);
            c.Value = fi.Category;
            cmd.Parameters.Add(c);

            SqlParameter sc = new SqlParameter("@SubCategory", SqlDbType.Int);
            sc.Value = fi.SubCategory;
            cmd.Parameters.Add(sc);

            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = fi.flag;
            cmd.Parameters.Add(f);

            conn.Open();
            int status = cmd.ExecuteNonQuery();
            conn.Close();
            return status;
        }
    }
}
         
