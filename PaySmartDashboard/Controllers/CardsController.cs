using PaySmartDashboard.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartTicketDashboard.Controllers
{
    public class CardsController : ApiController
    {
        [HttpGet]
        [Route("api/Cards/GetCardUsers1")]
        public DataTable GetCardUsers1(int CardType)
        {

            DataTable Tbl = new DataTable();

            SqlConnection conn = new SqlConnection();
           // conn.ConnetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
           conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "GetCardUsers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CardType", SqlDbType.Int).Value = CardType;
            cmd.Connection = conn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Tbl);
            return Tbl;
        }
        
        
        /*---------------------------------------------------------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCardsList")]
        public DataTable GetCardsList()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCardListNew";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*-------------------------------------GetEffectiveToo--------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetEffectiveTo")]
        public DataTable GetEffectiveTo()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEffectiveToo";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*-------------------------------------------close----------------------------------------*/
        [HttpGet]
        [Route("api/Cards/CardModelData")]
        public DataTable CardModelData()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardModel";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }

        /*---------------------------------------CardModel Data---------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCategoriesLists")]
        public DataTable GetCategoriesLists()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCategoryListNew";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/

        //[HttpGet]
        //[Route("api/Cards/GetCardsList")]
        //public DataTable GetCardsList2()
        //{
        //    try
        //    {
        //        DataTable Tbl = new DataTable();

        //        //connect to database
        //        SqlConnection conn = new SqlConnection();
        //        //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCardListNew";
        //        cmd.Connection = conn;
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter db = new SqlDataAdapter(cmd);
        //        db.Fill(ds);
        //        Tbl = ds.Tables[0];
        //        // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
        //        return Tbl;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
        //        throw ex;
        //    }
        //}

        //  /* ----------------------------SaveCardDetails by using Post Operation---------------------------------------------*/
        //[HttpPost]
        //[Route("api/Cards/SavePostCardDetails")]
        //public HttpResponseMessage SavePostCardDetails(Cards j)
        //{
        //    SqlTransaction transaction = null;

        //    //connect to database
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCardList";
        //        cmd.Connection = conn;
        //        conn.Open();

        //        transaction = conn.BeginTransaction();
        //        cmd.Transaction = transaction;

        //        #region save card details
        //        SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
        //        id.Value = j.Id;
        //        cmd.Parameters.Add(id);

        //        SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
        //        CardNum.Value = j.CardNumber;
        //        cmd.Parameters.Add(CardNum);

        //        SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
        //        CardName.Value = j.CardName;
        //        cmd.Parameters.Add(CardName);

        //        SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
        //        CardType.Value = j.CardType;
        //        cmd.Parameters.Add(CardType);

        //        SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
        //        CardModel.Value = j.CardModel;
        //        cmd.Parameters.Add(CardModel);

        //        SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
        //        CardCategory.Value = j.CardCategory;
        //        cmd.Parameters.Add(CardCategory);

        //        SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
        //        cust.Value = j.Customer;
        //        cmd.Parameters.Add(cust);

        //        SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
        //        EffectiveFrom.Value = j.EffectiveFrom;
        //        cmd.Parameters.Add(EffectiveFrom);

        //        SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
        //        EffectiveTo.Value = j.EffectiveTo;
        //        cmd.Parameters.Add(EffectiveTo);

        //        SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
        //        StatusId.Value = j.StatusId;
        //        cmd.Parameters.Add(StatusId);

        //       SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
        //       flag.Value = j.flag;
        //       cmd.Parameters.Add(flag);



        //        object id2 = cmd.ExecuteScalar();

        //        #endregion save card details

        //        transaction.Commit();
        //        // conn.Close();
        //        // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        transaction.Rollback();
        //        //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        string str = ex.Message;

        //        // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}
        /*----------------------------------SaveCardDetails---------------------------------------*/
        [HttpPost]
        [Route("api/Cards/SaveCardDetails")]
        public HttpResponseMessage SaveCardDetails(Cards k)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();
            
            try
            {
                
                // conn.ConnectionString = "Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "setCardDetails";
                cmd.Connection = conn;

                conn.Open();
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details
                //SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                //id.Value = k.id;
                //cmd.Parameters.Add(id);

                SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                CardName.Value = k.CardName;
                cmd.Parameters.Add(CardName);

                SqlParameter CardNumber = new SqlParameter("@CardNumber", SqlDbType.Int);
                CardNumber.Value = k.CardNumber;
                cmd.Parameters.Add(CardNumber);



                SqlParameter NameOnCard = new SqlParameter("@NameOnCard", SqlDbType.VarChar, 50);
                NameOnCard.Value = k.NameOnCard;
                cmd.Parameters.Add(NameOnCard);

                SqlParameter ReferenceId = new SqlParameter("@ReferenceId", SqlDbType.Int);
                ReferenceId.Value = k.ReferenceId;
                cmd.Parameters.Add(ReferenceId);

                SqlParameter EstimatedStartDate = new SqlParameter("@EstimatedStartDate", SqlDbType.Date);
                EstimatedStartDate.Value = k.EstimatedStartDate;
                cmd.Parameters.Add(EstimatedStartDate);

                SqlParameter EstimatedEndDate = new SqlParameter("@EstimatedEndDate", SqlDbType.Date);
                EstimatedEndDate.Value = k.EstimatedEndDate;
                cmd.Parameters.Add(EstimatedEndDate);

                SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                EffectiveFrom.Value = k.EffectiveFrom;
                cmd.Parameters.Add(EffectiveFrom);

                SqlParameter ValidTillDate = new SqlParameter("@ValidTillDate", SqlDbType.Date);
                ValidTillDate.Value = k.ValidTillDate;
                cmd.Parameters.Add(ValidTillDate);

                SqlParameter CVV = new SqlParameter("@CVV", SqlDbType.Int);
                CVV.Value = k.CVV;
                cmd.Parameters.Add(CVV);

                SqlParameter CVV2 = new SqlParameter("@CVV2", SqlDbType.Int);
                CVV2.Value = k.CVV2;
                cmd.Parameters.Add(CVV2);

                SqlParameter PIN = new SqlParameter("@PIN", SqlDbType.Int);
                PIN.Value = k.PIN;
                cmd.Parameters.Add(PIN);

                SqlParameter CardStatus = new SqlParameter("@CardStatus", SqlDbType.Int);
                CardStatus.Value = k.CardStatus;
                cmd.Parameters.Add(CardStatus);

                SqlParameter Customer = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                Customer.Value = k.Customer;
                cmd.Parameters.Add(Customer);

                SqlParameter UserId = new SqlParameter("@UserId", SqlDbType.Int);
                UserId.Value = k.UserId;
                cmd.Parameters.Add(UserId);


                SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                flag.Value = k.flag;
                cmd.Parameters.Add(flag);


                
                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }

            //catch (Exception ex)
            //{
            //    if (conn!= null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //    string str = ex.Message;

            //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /*-----------------------------------------------------SaveCardUser-----------------------------------------------------------*/
        [HttpPost]
        [Route("api/Cards/SaveCardUser")]
        public HttpResponseMessage SaveCardUser(Cards z)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();

            try
            {

                // conn.ConnectionString = "Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCardUserInfo";
                cmd.Connection = conn;

                
                conn.Open();
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details

                //SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                //id.Value = k.id;
                //cmd.Parameters.Add(id);

                SqlParameter FirstName = new SqlParameter("@FirstName",SqlDbType.VarChar,50);
                FirstName.Value = z.FirstName;
                cmd.Parameters.Add(FirstName);

                SqlParameter LastName = new SqlParameter("@LastName",SqlDbType.VarChar, 50);
                LastName.Value = z.LastName;
                cmd.Parameters.Add(LastName);
                
                SqlParameter EmailId = new SqlParameter("@EmailId",SqlDbType.VarChar, 50);
                EmailId.Value = z.EmailId;
                cmd.Parameters.Add(EmailId);

                SqlParameter MobileNumber = new SqlParameter("@MobileNumber",SqlDbType.VarChar,50);
                MobileNumber.Value = z.MobileNumber;
                cmd.Parameters.Add(MobileNumber);

                SqlParameter Address = new SqlParameter("@Address",SqlDbType.VarChar,50);
                Address.Value = z.Address;
                cmd.Parameters.Add(Address);

                SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.Int);
                CardType.Value = z.CardType;
                cmd.Parameters.Add(CardType);

                SqlParameter CardNumber = new SqlParameter("@CardNumber ", SqlDbType.Int);
                CardNumber.Value = z.CardNumber;
                cmd.Parameters.Add(CardNumber);

                SqlParameter MiddleName = new SqlParameter("@MiddleName", SqlDbType.VarChar,50);
                MiddleName.Value = z.MiddleName;
                cmd.Parameters.Add(MiddleName);

                SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                flag.Value = z.flag;
                cmd.Parameters.Add(flag);


                
                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            //catch (Exception ex)
            //{
            //    if (conn != null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //    string str = ex.Message;

            //    Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /*----------------------------------------------------SaveCardbyCategory----------------------------------------*/
        [HttpPost]
        [Route("api/Cards/SaveCardbyCategory")]
        public HttpResponseMessage SaveCardbyCategory(Cards j)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCardListbyCategory";
                cmd.Connection = conn;
                conn.Open();

                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details
                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = j.Id;
                cmd.Parameters.Add(id);

                SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
                CardNum.Value = j.CardNumber;
                cmd.Parameters.Add(CardNum);

                SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                CardName.Value = j.CardName;
                cmd.Parameters.Add(CardName);

                SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                CardType.Value = j.CardType;
                cmd.Parameters.Add(CardType);

                SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
                CardModel.Value = j.CardModel;
                cmd.Parameters.Add(CardModel);

                SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
                CardCategory.Value = j.CardCategory;
                cmd.Parameters.Add(CardCategory);

                SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                cust.Value = j.Customer;
                cmd.Parameters.Add(cust);

                SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                EffectiveFrom.Value = j.EffectiveFrom;
                cmd.Parameters.Add(EffectiveFrom);

                SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                EffectiveTo.Value = j.EffectiveTo;
                cmd.Parameters.Add(EffectiveTo);

                SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                StatusId.Value = j.StatusId;
                cmd.Parameters.Add(StatusId);

                SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                flag.Value = j.flag;
                cmd.Parameters.Add(flag);



                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /*-------------------------------SaveCardbyCategory--------------------------------------------*/
        [HttpPost]
        [Route("api/Cards/SaveCardbyCategory2")]
        public HttpResponseMessage SaveCardbyCategory2(Cards j)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCardListbyCategory";
                cmd.Connection = conn;
                conn.Open();

                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details
                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = j.Id;
                cmd.Parameters.Add(id);

                /*    SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
                    CardNum.Value = j.CardNumber;
                    cmd.Parameters.Add(CardNum);

                    SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                    CardName.Value = j.CardName;
                    cmd.Parameters.Add(CardName);

                    SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                    CardType.Value = j.CardType;
                    cmd.Parameters.Add(CardType);

                    SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
                    CardModel.Value = j.CardModel;
                    cmd.Parameters.Add(CardModel);*/

                SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
                CardCategory.Value = j.CardCategory;
                cmd.Parameters.Add(CardCategory);

                /*SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                cust.Value = j.Customer;
                cmd.Parameters.Add(cust);

                SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                EffectiveFrom.Value = j.EffectiveFrom;
                cmd.Parameters.Add(EffectiveFrom);

                SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                EffectiveTo.Value = j.EffectiveTo;
                cmd.Parameters.Add(EffectiveTo);

                SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                StatusId.Value = j.StatusId;
                cmd.Parameters.Add(StatusId);*/

                SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                flag.Value = j.flag;
                cmd.Parameters.Add(flag);



                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        /*----------------------GetEffectiveFrom----------------------------------------------------------------*/

        [HttpPost]
        [Route("api/Cards/saveGetEffectiveFromm")]
        public HttpResponseMessage SaveGetEffectiveFrom(Cards j)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEffectiveFromm";
                cmd.Connection = conn;
                conn.Open();

                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details
                /* SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = j.Id;
                cmd.Parameters.Add(id);

                SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
                CardNum.Value = j.CardNumber;
                cmd.Parameters.Add(CardNum);

                SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                CardName.Value = j.CardName;
                cmd.Parameters.Add(CardName);

                SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                CardType.Value = j.CardType;
                cmd.Parameters.Add(CardType);

                SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
                CardModel.Value = j.CardModel;
                cmd.Parameters.Add(CardModel);

                SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
                CardCategory.Value = j.CardCategory;
                cmd.Parameters.Add(CardCategory);

                SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                cust.Value = j.Customer;
                cmd.Parameters.Add(cust);*/

                SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                EffectiveFrom.Value = j.EffectiveFrom;
                cmd.Parameters.Add(EffectiveFrom);

                /*  SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                  EffectiveTo.Value = j.EffectiveTo;
                  cmd.Parameters.Add(EffectiveTo);

                  SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                  StatusId.Value = j.StatusId;
                  cmd.Parameters.Add(StatusId);

                  SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                  flag.Value = j.flag;
                  cmd.Parameters.Add(flag);*/



                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /*----------------------------SavejobDetails----------------------------------------------------*/

        [HttpGet]
        [Route("api/Cards/CardListData")]
        public DataTable CardListData()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardListData";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }

        
        [Route("api/Cards/GetAllCardOptions")]
        public DataSet GetAllCardOptions()
        {
            try
            {


                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllCardOptions";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);

                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return ds;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*----------------------------------------------------getCardUsers--------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCardUsers")]
        public DataSet GetCardUsers()
        {
            try
            {


                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCardUsers";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);

                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return ds;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*----------------------------------------------------CardUserDetails-----------------------------------------------------------------*/
        //[HttpPost]
        //[Route("api/Cards/CardUserDetails")]
        //public HttpResponseMessage CardUserDetails(CardUser u)
        //{
        //    SqlTransaction transaction = null;

        //    connect to database
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCardUserInfo";
        //        cmd.Connection = conn;
        //        conn.Open();

        //        transaction = conn.BeginTransaction();
        //        cmd.Transaction = transaction;

        //        #region save card details
        //        SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
        //        id.Value = u.Id;
        //        cmd.Parameters.Add(id);

        //        SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar,50);
        //        firstName.Value = u.firstName;
        //        cmd.Parameters.Add(firstName);

        //        SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar, 50);
        //        lastName.Value = u.lastName;
        //        cmd.Parameters.Add(lastName);

        //        SqlParameter EmailId = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
        //        EmailId.Value = u.EmailId;
        //        cmd.Parameters.Add(EmailId);

        //        SqlParameter Mobilenumber = new SqlParameter("@Mobilenumber", SqlDbType.VarChar, 50);
        //        Mobilenumber.Value = u.Mobilenumber;
        //        cmd.Parameters.Add(Mobilenumber);

        //        SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 50);
        //        Address.Value = u.Address;
        //        cmd.Parameters.Add(Address);

        //        SqlParameter CardType = new SqlParameter("@CardType ", SqlDbType.Int);
        //        CardType.Value = u.CardType;
        //        cmd.Parameters.Add(CardType);

        //        SqlParameter CardNumber = new SqlParameter("@CardNumber", SqlDbType.Int);
        //        CardNumber.Value = u.CardNumber;
        //        cmd.Parameters.Add(CardNumber);

        //        SqlParameter middleName = new SqlParameter("@middleName", SqlDbType.VarChar, 50);
        //        middleName.Value = u.middleName;
        //        cmd.Parameters.Add(middleName);

        //        SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
        //        StatusId.Value = j.StatusId;
        //        cmd.Parameters.Add(StatusId);

        //        SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
        //        flag.Value = u.flag;
        //        cmd.Parameters.Add(flag);



        //        object id2 = cmd.ExecuteScalar();

        //        #endregion save card details

        //        transaction.Commit();
        //         conn.Close();
        //         Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        transaction.Rollback();
        //        Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        string str = ex.Message;

        //         Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}
        /*----------------------------------------------------SaveCardbyCategory----------------------------------------*/
        //[HttpPost]
        //[Route("api/Cards/SaveCardbyCategory")]
        //public HttpResponseMessage SaveCardbyCategory(Cards j)
        //{
        //    SqlTransaction transaction = null;

        //    connect to database
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCardListbyCategory";
        //        cmd.Connection = conn;
        //        conn.Open();

        //        transaction = conn.BeginTransaction();
        //        cmd.Transaction = transaction;

        //        #region save card details
        //        SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
        //        id.Value = j.Id;
        //        cmd.Parameters.Add(id);

        //        SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
        //        CardNum.Value = j.CardNumber;
        //        cmd.Parameters.Add(CardNum);

        //        SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
        //        CardName.Value = j.CardName;
        //        cmd.Parameters.Add(CardName);

        //        SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
        //        CardType.Value = j.CardType;
        //        cmd.Parameters.Add(CardType);

        //        SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
        //        CardModel.Value = j.CardModel;
        //        cmd.Parameters.Add(CardModel);

        //        SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
        //        CardCategory.Value = j.CardCategory;
        //        cmd.Parameters.Add(CardCategory);

        //        SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
        //        cust.Value = j.Customer;
        //        cmd.Parameters.Add(cust);

        //        SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
        //        EffectiveFrom.Value = j.EffectiveFrom;
        //        cmd.Parameters.Add(EffectiveFrom);

        //        SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
        //        EffectiveTo.Value = j.EffectiveTo;
        //        cmd.Parameters.Add(EffectiveTo);

        //        SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
        //        StatusId.Value = j.StatusId;
        //        cmd.Parameters.Add(StatusId);

        //        SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
        //        flag.Value = j.flag;
        //        cmd.Parameters.Add(flag);



        //        object id2 = cmd.ExecuteScalar();

        //        #endregion save card details

        //        transaction.Commit();
        //         conn.Close();
        //         Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        transaction.Rollback();
        //        Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        string str = ex.Message;

        //         Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }

        //}





        /*---------------------------------------------------------------------------------------------------------------------*/
        //        [HttpPost]
        //        [Route("api/jobs/SavejobDocs")]
        //        public DataSet SavejobDocs(jobDocuments  jdoc)
        //        {          
        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            DataSet dt = new DataSet();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "InsUpdDeljobDocuments";
        //                cmd.Connection = conn;
        //               // conn.Open();              

        //                #region save job docs
        //                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
        //                id.Value = (jdoc.Id == 0)? -1 : jdoc.Id;
        //                cmd.Parameters.Add(id);

        //                SqlParameter AssetId = new SqlParameter("@jobId", SqlDbType.Int);
        //                AssetId.Value = jdoc.jobId;
        //                cmd.Parameters.Add(AssetId);

        //                SqlParameter Gid1 = new SqlParameter("@DocTypeId", SqlDbType.Int);
        //                Gid1.Value = jdoc.docTypeId;
        //                cmd.Parameters.Add(Gid1);

        //                SqlParameter assettypeid = new SqlParameter("@DocName", SqlDbType.VarChar, 100);
        //                assettypeid.Value = jdoc.docName;
        //                cmd.Parameters.Add(assettypeid);

        //                SqlParameter rootassetid = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //                rootassetid.Value = jdoc.createdById;
        //                cmd.Parameters.Add(rootassetid);

        //                SqlParameter AsstMDLHierarID = new SqlParameter("@UpdatedBy", SqlDbType.Int);
        //                AsstMDLHierarID.Value = jdoc.UpdatedById;
        //                cmd.Parameters.Add(AsstMDLHierarID);

        //                SqlParameter assetModelId = new SqlParameter("@ExpiryDate", SqlDbType.Date);
        //                assetModelId.Value = jdoc.expiryDate;
        //                cmd.Parameters.Add(assetModelId);


        //                SqlParameter LocationId = new SqlParameter("@DueDate", SqlDbType.Date);
        //                LocationId.Value = jdoc.dueDate;
        //                cmd.Parameters.Add(LocationId);

        //                SqlParameter parentid = new SqlParameter("@DocContent", SqlDbType.VarChar);
        //                parentid.Value = jdoc.docContent;
        //                cmd.Parameters.Add(parentid);

        //                SqlParameter flag1 = new SqlParameter("@insupdflag", SqlDbType.VarChar);
        //                flag1.Value = jdoc.insupddelflag;
        //                cmd.Parameters.Add(flag1);

        //                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
        //                loggedinUserId1.Value = jdoc.UpdatedById;
        //                cmd.Parameters.Add(loggedinUserId1);


        //                //cmd.ExecuteScalar();
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(dt);

        //                #endregion save job details


        //                // conn.Close();
        //                Logger.Trace(LogCategory.WebApp, "DataTable in SavejobDocs() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobDocs() procedure", LogLevel.Error, null);
        //                return dt;

        //            }
        //            catch (Exception ex)
        //            {
        //                if (conn != null && conn.State == ConnectionState.Open)
        //                {
        //                    conn.Close();
        //                }
        //                string str = ex.Message;

        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobDocs() procedure", LogLevel.Error, null);
        //                return dt;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //                conn.Dispose();
        //            }
        //        }

        //        [HttpPost]
        //        [Route("api/jobs/SavejobEquipment")]
        //        public DataSet SavejobEquipement(jobResouces jres)
        //        {
        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            DataSet dt = new DataSet();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "InsUpdDeljobResources";
        //                cmd.Connection = conn;
        //                conn.Open();

        //                #region save job equipment
        //                //@Id int,@jobId int,@UserId int,@CreatedBy int,@UpdatedBy int,@FromDate date = null, @ToDate date = null,@insupdflag varchar(1)
        //                SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
        //                ba.Value = jres.Id;
        //                cmd.Parameters.Add(ba);

        //                SqlParameter jid = new SqlParameter("@jobId", SqlDbType.Int);
        //                jid.Value = jres.jobId;
        //                cmd.Parameters.Add(jid);

        //                SqlParameter bb = new SqlParameter("@AssetId", SqlDbType.Int);
        //                bb.Value = jres.AssetId;
        //                cmd.Parameters.Add(bb);

        //                SqlParameter bd = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //                bd.Value = jres.createdById;
        //                cmd.Parameters.Add(bd);


        //                SqlParameter bf = new SqlParameter("@UpdatedBy", SqlDbType.Int);
        //                bf.Value = jres.UpdatedById;
        //                cmd.Parameters.Add(bf);

        //                SqlParameter bh = new SqlParameter("@FromDate", SqlDbType.Date);
        //                bh.Value = jres.FromDate;
        //                cmd.Parameters.Add(bh);

        //                SqlParameter ipconfig = new SqlParameter("@ToDate", SqlDbType.Date);
        //                ipconfig.Value = jres.ToDate;
        //                cmd.Parameters.Add(ipconfig);

        //                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
        //                insupdflag.Value = (jres.insupddelflag == null) ? "" : jres.insupddelflag;
        //                cmd.Parameters.Add(insupdflag);

        //                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
        //                loggedinUserId1.Value = jres.UpdatedById;
        //                cmd.Parameters.Add(loggedinUserId1);

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(dt);

        //                #endregion save job equipment


        //                // conn.Close();
        //                Logger.Trace(LogCategory.WebApp, "DataTable in SavejobEquipement() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobEquipement() procedure", LogLevel.Error, null);
        //                return dt;

        //            }
        //            catch (Exception ex)
        //            {
        //                if (conn != null && conn.State == ConnectionState.Open)
        //                {
        //                    conn.Close();
        //                }
        //                string str = ex.Message;

        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //                return dt;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //                conn.Dispose();
        //            }
        //        }

        //        [HttpPost]
        //        [Route("api/jobs/SavejobUsers")]
        //        public DataSet SavejobUsers(jobUsers u)
        //        {
        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            DataSet dt = new DataSet();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "InsUpdDeljobUsers";
        //                cmd.Connection = conn;
        //                conn.Open();

        //                #region save job users
        //                //@Id int,@jobId int,@UserId int,@CreatedBy int,@UpdatedBy int,@FromDate date = null, @ToDate date = null,@insupdflag varchar(1)
        //                SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
        //                ba.Value = u.Id;
        //                cmd.Parameters.Add(ba);

        //                SqlParameter jid = new SqlParameter("@jobId", SqlDbType.Int);
        //                jid.Value = u.jobId;
        //                cmd.Parameters.Add(jid);

        //                SqlParameter bb = new SqlParameter("@UserId", SqlDbType.Int);
        //                bb.Value = u.UserId;
        //                cmd.Parameters.Add(bb);

        //                SqlParameter bd = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //                bd.Value = u.CreatedById;
        //                cmd.Parameters.Add(bd);


        //                SqlParameter bf = new SqlParameter("@UpdatedBy", SqlDbType.Int);
        //                bf.Value = u.UpdatedById;
        //                cmd.Parameters.Add(bf);

        //                SqlParameter bh = new SqlParameter("@FromDate", SqlDbType.Date);
        //                bh.Value = u.FromDate;
        //                cmd.Parameters.Add(bh);

        //                SqlParameter ipconfig = new SqlParameter("@ToDate", SqlDbType.Date);
        //                ipconfig.Value = u.ToDate;
        //                cmd.Parameters.Add(ipconfig);

        //                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
        //                insupdflag.Value = (u.insupddelflag == null) ? "" : u.insupddelflag;
        //                cmd.Parameters.Add(insupdflag);

        //                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
        //                loggedinUserId1.Value = u.UpdatedById;
        //                cmd.Parameters.Add(loggedinUserId1);                          

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(dt);


        //                #endregion save job details


        //                // conn.Close();
        //                Logger.Trace(LogCategory.WebApp, "DataTable in SavejobUsers() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobUsers() procedure", LogLevel.Error, null);
        //                return dt;

        //            }
        //            catch (Exception ex)
        //            {
        //                if (conn != null && conn.State == ConnectionState.Open)
        //                {
        //                    conn.Close();
        //                }
        //                string str = ex.Message;

        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobUsers() procedure", LogLevel.Error, null);
        //                return dt;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //                conn.Dispose();
        //            }
        //        }

        //        [HttpPost]
        //        [Route("api/jobs/SavejobTPResource")]
        //        public DataSet SavejobTPResource(jobTPResources u)
        //        {
        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            DataSet dt = new DataSet();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "InsUpdDeljobTPResources";
        //                cmd.Connection = conn;
        //                conn.Open();

        //                #region save job 3rd party resources
        //                //@Id int,@jobId int,@resourceName varchar(50) = null, @vendorName varchar(50) = null,@TPResourceId int,@CreatedBy int,@UpdatedBy int,@FromDate date = null, @ToDate date = null,@insupdflag varchar(1)

        //                SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
        //                ba.Value = u.Id;
        //                cmd.Parameters.Add(ba);

        //                SqlParameter jid = new SqlParameter("@jobId", SqlDbType.Int);
        //                jid.Value = u.jobId;
        //                cmd.Parameters.Add(jid);

        //                SqlParameter rn = new SqlParameter("@resourceName", SqlDbType.VarChar, 50);
        //                rn.Value = u.Name;
        //                cmd.Parameters.Add(rn);

        //                SqlParameter vn = new SqlParameter("@vendorName", SqlDbType.VarChar, 50);
        //                vn.Value = u.VName;
        //                cmd.Parameters.Add(vn);

        //                SqlParameter bb = new SqlParameter("@TPResourceId", SqlDbType.Int);
        //                bb.Value = u.TPResourceId;
        //                cmd.Parameters.Add(bb);

        //                SqlParameter bd = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //                bd.Value = u.createdById;
        //                cmd.Parameters.Add(bd);


        //                SqlParameter bf = new SqlParameter("@UpdatedBy", SqlDbType.Int);
        //                bf.Value = u.UpdatedById;
        //                cmd.Parameters.Add(bf);

        //                SqlParameter bh = new SqlParameter("@FromDate", SqlDbType.Date);
        //                bh.Value = u.FromDate;
        //                cmd.Parameters.Add(bh);

        //                SqlParameter ipconfig = new SqlParameter("@ToDate", SqlDbType.Date);
        //                ipconfig.Value = u.ToDate;
        //                cmd.Parameters.Add(ipconfig);

        //                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 1);
        //                insupdflag.Value = (u.insupddelflag == null) ? "" : u.insupddelflag;// u.insupddelflag;
        //                cmd.Parameters.Add(insupdflag);

        //                SqlParameter loggedinUserId1 = new SqlParameter("@loggedinUserId", SqlDbType.Int);
        //                loggedinUserId1.Value = u.UpdatedById;
        //                cmd.Parameters.Add(loggedinUserId1);

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(dt);

        //                #endregion save job 3rd party resources


        //                // conn.Close();
        //                Logger.Trace(LogCategory.WebApp, "DataTable in SavejobTPResource() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobTPResource() procedure", LogLevel.Error, null);
        //                return dt;

        //            }
        //            catch (Exception ex)
        //            {
        //                if (conn != null && conn.State == ConnectionState.Open)
        //                {
        //                    conn.Close();
        //                }
        //                string str = ex.Message;

        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //                return dt;
        //            }
        //            finally
        //            {
        //                conn.Close();
        //                conn.Dispose();
        //            }
        //        }
        /*-----------------------------------------GetEffectiveFromm---------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/SaveGetEffectiveFromm")]
        public DataTable SaveGetEffectiveFromm(Cards j)
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEffectiveFromm";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;

            }
            catch (Exception ex)
            {
                //  Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*-----------------------------------------------------------------------------------------------------------------*/
        /*        [HttpPost]
                [Route("api/Cards/AddNewCardData")]
                public HttpResponseMessage AddNewCardData(Cards j)
                {
                    SqlTransaction transaction = null;

                    //connect to database
                    SqlConnection conn = new SqlConnection();
                    try
                    {
                        //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AddNewCardData2";
                        cmd.Connection = conn;
                        conn.Open();

                        transaction = conn.BeginTransaction();
                        cmd.Transaction = transaction;

                        #region save card details
                        /* SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                        id.Value = j.Id;
                        cmd.Parameters.Add(id); */

        /*       SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
               CardNum.Value = j.CardNumber;
               cmd.Parameters.Add(CardNum);

             /*  SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
               CardName.Value = j.CardName;
               cmd.Parameters.Add(CardName);*/

        /*         SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                 CardType.Value = j.CardType;
                 cmd.Parameters.Add(CardType);

                 SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
                 CardModel.Value = j.CardModel;
                 cmd.Parameters.Add(CardModel);

                 SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
                 CardCategory.Value = j.CardCategory;
                 cmd.Parameters.Add(CardCategory);

             /*    SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                 cust.Value = j.Customer;
                 cmd.Parameters.Add(cust);

                 SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                 EffectiveFrom.Value = j.EffectiveFrom;
                 cmd.Parameters.Add(EffectiveFrom);

                 SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                 EffectiveTo.Value = j.EffectiveTo;
                 cmd.Parameters.Add(EffectiveTo);

                 SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                 StatusId.Value = j.StatusId;
                 cmd.Parameters.Add(StatusId);*/

        /*                 SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                         flag.Value = j.flag;
                         cmd.Parameters.Add(flag);



                         object id2 = cmd.ExecuteScalar();

                         #endregion save card details

                         transaction.Commit();
                         // conn.Close();
                         // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                         return new HttpResponseMessage(HttpStatusCode.OK);
                     }
                     catch (SqlException sqlEx)
                     {
                         transaction.Rollback();
                         //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                         return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

                     }
                     //catch (Exception ex)
                     //{
                     //    if (conn != null && conn.State == ConnectionState.Open)
                     //    {
                     //        conn.Close();
                     //    }
                     //    string str = ex.Message;

                     //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                     //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                     //}
                     finally
                     {
                         conn.Close();
                         conn.Dispose();
                     }
                 }
    

  //------------------------------------------------------------------------------------------------------------------------
                 [HttpPost]
                 [Route("api/Cards/AddNewCardData")]
                 public HttpResponseMessage AddNewCardData(Cards j)
                 {
                     SqlTransaction transaction = null;

                     //connect to database
                     SqlConnection conn = new SqlConnection();
                     try
                     {
                         //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                         conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                         SqlCommand cmd = new SqlCommand();
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.CommandText = "AddNewCardData2";
                         cmd.Connection = conn;
                         conn.Open();

                         transaction = conn.BeginTransaction();
                         cmd.Transaction = transaction;

                         #region save card details
                         /* SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                         id.Value = j.Id;
                         cmd.Parameters.Add(id); */

        /*      SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
              CardNum.Value = j.CardNumber;
              cmd.Parameters.Add(CardNum);

              /*  SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                CardName.Value = j.CardName;
                cmd.Parameters.Add(CardName);*/

        /*             SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                     CardType.Value = j.CardType;
                     cmd.Parameters.Add(CardType);

                     SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
                     CardModel.Value = j.CardModel;
                     cmd.Parameters.Add(CardModel);

                     SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
                     CardCategory.Value = j.CardCategory;
                     cmd.Parameters.Add(CardCategory);

                     /*    SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                         cust.Value = j.Customer;
                         cmd.Parameters.Add(cust);

                         SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                         EffectiveFrom.Value = j.EffectiveFrom;
                         cmd.Parameters.Add(EffectiveFrom);

                         SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                         EffectiveTo.Value = j.EffectiveTo;
                         cmd.Parameters.Add(EffectiveTo);

                         SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                         StatusId.Value = j.StatusId;
                         cmd.Parameters.Add(StatusId);*/

        /*        SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
                flag.Value = j.flag;
                cmd.Parameters.Add(flag);



                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            //catch (Exception ex)
            //{
            //    if (conn != null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //    string str = ex.Message;

            //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
/*------------------------------------------------------------------------------------------------------------------------*/
        [HttpPost]
        [Route("api/Cards/AddNewCardData3")]
        public HttpResponseMessage AddNewCardData3(Cards m)
        {


            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddNewCardData2";
                cmd.Connection = conn;
                conn.Open();



                //#region save card details
                //SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                //id.Value = m.Id;
                //cmd.Parameters.Add(id); 

                SqlParameter d = new SqlParameter("@CardNumber", SqlDbType.Int);
                d.Value = m.CardNumber;
                cmd.Parameters.Add(d);

                SqlParameter l = new SqlParameter("@CardModel", SqlDbType.Int);
                l.Value = m.CardModel;
                cmd.Parameters.Add(l);

                SqlParameter t = new SqlParameter("@CardType", SqlDbType.Int);
                t.Value = m.CardType;
                cmd.Parameters.Add(t);

                SqlParameter a = new SqlParameter("@CardCategory", SqlDbType.Int);
                a.Value = m.CardCategory;
                cmd.Parameters.Add(a);

                /*  SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                  CardName.Value = j.CardName;
                  cmd.Parameters.Add(CardName);*/

                /*    SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                    cust.Value = j.Customer;
                    cmd.Parameters.Add(cust);

                    SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                    EffectiveFrom.Value = j.EffectiveFrom;
                    cmd.Parameters.Add(EffectiveFrom);

                    SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                    EffectiveTo.Value = j.EffectiveTo;
                    cmd.Parameters.Add(EffectiveTo);

                    SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                    StatusId.Value = j.StatusId;
                    cmd.Parameters.Add(StatusId);*/

                SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
                f.Value = m.flag;
                cmd.Parameters.Add(f);



                object id2 = cmd.ExecuteScalar();

                //#endregion save card details


                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                string str = sqlEx.Message;
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            //catch (Exception ex)
            //{
            //    if (conn != null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //    string str = ex.Message;

            //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------*/
        /*      [HttpPost]
              [Route("api/Cards/AddNewCardData")]
              public HttpResponseMessage AddNewCardData(Cards j)
              {
                  SqlTransaction transaction = null;

                  //connect to database
                  SqlConnection conn = new SqlConnection();
                  try
                  {
                      //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                      conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                      SqlCommand cmd = new SqlCommand();
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.CommandText = "AddNewCardData2";
                      cmd.Connection = conn;
                      conn.Open();

                      transaction = conn.BeginTransaction();
                      cmd.Transaction = transaction;

                      #region save card details
                      /* SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                      id.Value = j.Id;
                      cmd.Parameters.Add(id); */

        /*       SqlParameter CardNum = new SqlParameter("@CardNumber", SqlDbType.Int);
               CardNum.Value = j.CardNumber;
               cmd.Parameters.Add(CardNum);

               /*  SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
                 CardName.Value = j.CardName;
                 cmd.Parameters.Add(CardName);*/

        /*      SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
              CardType.Value = j.CardType;
              cmd.Parameters.Add(CardType);

              SqlParameter CardModel = new SqlParameter("@CardModel", SqlDbType.VarChar, 50);
              CardModel.Value = j.CardModel;
              cmd.Parameters.Add(CardModel);

              SqlParameter CardCategory = new SqlParameter("@CardCategory", SqlDbType.VarChar, 50);
              CardCategory.Value = j.CardCategory;
              cmd.Parameters.Add(CardCategory);

              /*    SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
                  cust.Value = j.Customer;
                  cmd.Parameters.Add(cust);

                  SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
                  EffectiveFrom.Value = j.EffectiveFrom;
                  cmd.Parameters.Add(EffectiveFrom);

                  SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
                  EffectiveTo.Value = j.EffectiveTo;
                  cmd.Parameters.Add(EffectiveTo);

                  SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
                  StatusId.Value = j.StatusId;
                  cmd.Parameters.Add(StatusId);*/

        /*    SqlParameter flag = new SqlParameter("@flag", SqlDbType.VarChar);
            flag.Value = j.flag;
            cmd.Parameters.Add(flag);



            object id2 = cmd.ExecuteScalar();

            #endregion save card details

            transaction.Commit();
            // conn.Close();
            // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        catch (SqlException sqlEx)
        {
            transaction.Rollback();
            //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

        }
        //catch (Exception ex)
        //{
        //    if (conn != null && conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //    }
        //    string str = ex.Message;

        //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //}
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
/*---------------------------------------------------------------------------------------------------------------------*/
        [HttpPost]
        [Route("api/Cards/AddNewCardData")]
        public HttpResponseMessage PostCardType(Cards j)
        {
            SqlTransaction transaction = null;

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardType";
                cmd.Connection = conn;
                conn.Open();

                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                #region save card details
                SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
                id.Value = j.Id;
                cmd.Parameters.Add(id);

                SqlParameter CardType = new SqlParameter("@CardType", SqlDbType.VarChar, 50);
                CardType.Value = j.CardType;
                cmd.Parameters.Add(CardType);

                object id2 = cmd.ExecuteScalar();

                #endregion save card details

                transaction.Commit();
                // conn.Close();
                // Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (SqlException sqlEx)
            {
                transaction.Rollback();
                //Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

            }
            //catch (Exception ex)
            //{
            //    if (conn != null && conn.State == ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //    string str = ex.Message;

            //    // Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------*/
        //        [HttpGet]
        //        public DataSet GetjobDetails(int jobId)
        //        {
        //            try
        //            {
        //                //connect to database
        //                SqlConnection conn = new SqlConnection();
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetjobDetails";
        //                cmd.Connection = conn;

        //                SqlParameter Gim = new SqlParameter("@id", SqlDbType.Int);
        //                Gim.Value = Convert.ToString(jobId);
        //                cmd.Parameters.Add(Gim);

        //                DataSet ds = new DataSet();
        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(ds);

        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsDetails() procedure is loaded", LogLevel.Information, null);
        //                // int found = 0;
        //                return ds;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }
        /*--------------------------------------------------------------------CardUser----------------------------------------------*/
        //[HttpPost]
        //[Route("api/Cards/AddNewCardData3")]
        //public HttpResponseMessage AddNewCardData3(Cards m)
        //{


        //    connect to database
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "AddNewCardData2";
        //        cmd.Connection = conn;
        //        conn.Open();



        //        #region save card details
        //        SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
        //        id.Value = m.Id;
        //        cmd.Parameters.Add(id); 

        //        SqlParameter d = new SqlParameter("@CardNumber", SqlDbType.Int);
        //        d.Value = m.CardNumber;
        //        cmd.Parameters.Add(d);

        //        SqlParameter l = new SqlParameter("@CardModel", SqlDbType.Int);
        //        l.Value = m.CardModel;
        //        cmd.Parameters.Add(l);

        //        SqlParameter t = new SqlParameter("@CardType", SqlDbType.Int);
        //        t.Value = m.CardType;
        //        cmd.Parameters.Add(t);

        //        SqlParameter a = new SqlParameter("@CardCategory", SqlDbType.Int);
        //        a.Value = m.CardCategory;
        //        cmd.Parameters.Add(a);

        //        /*  SqlParameter CardName = new SqlParameter("@CardName", SqlDbType.VarChar, 50);
        //          CardName.Value = j.CardName;
        //          cmd.Parameters.Add(CardName);*/

        //        /*    SqlParameter cust = new SqlParameter("@Customer", SqlDbType.VarChar, 50);
        //            cust.Value = j.Customer;
        //            cmd.Parameters.Add(cust);

        //            SqlParameter EffectiveFrom = new SqlParameter("@EffectiveFrom ", SqlDbType.Date);
        //            EffectiveFrom.Value = j.EffectiveFrom;
        //            cmd.Parameters.Add(EffectiveFrom);

        //            SqlParameter EffectiveTo = new SqlParameter("@EFfectiveTo", SqlDbType.Date);
        //            EffectiveTo.Value = j.EffectiveTo;
        //            cmd.Parameters.Add(EffectiveTo);

        //            SqlParameter StatusId = new SqlParameter("@StatusId", SqlDbType.Int);
        //            StatusId.Value = j.StatusId;
        //            cmd.Parameters.Add(StatusId);*/

        //        SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
        //        f.Value = m.flag;
        //        cmd.Parameters.Add(f);



        //        object id2 = cmd.ExecuteScalar();

        //        #endregion save card details


        //         conn.Close();
        //         Logger.Trace(LogCategory.WebApp, "DataTable in SavejobsList() procedure is loaded", LogLevel.Information, null);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (SqlException sqlEx)
        //    {

        //        Logger.Error(sqlEx, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, sqlEx);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        string str = ex.Message;

        //         Logger.Error(ex, LogCategory.WebApp, "An error occured in SavejobsList() procedure", LogLevel.Error, null);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}



        /*--------------------------------------------------------------------CardType----------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/CardTypeData")]
        public DataTable CardTypeData()
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardType";
                cmd.Connection = conn;

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);

                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                // int found = 0;
                return Tbl;
            }
            catch (Exception ex)
            {
                //  Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*-------------------------------------------------------------end-------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCardNumbers")]
        public DataTable GetCardNumbers()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardNumbers";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }

        /*-------------------------------------------------------------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCardStatus")]
        public DataTable GetCardStatus()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardStatus";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*------------------------------------------------------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetCardDetails")]
        public DataTable GetCardDetails()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCardDetails";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;

            }
            catch (Exception ex)
            {
                //  Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*------------------------------------------------------------------------------------------------------------*/
        //        [HttpGet]
        //        public DataTable GetjobFileContent(int docId)
        //        {

        //            DataTable Tbl = new DataTable();

        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetjobFileContent";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@fileID", SqlDbType.Int);
        //                mid.Value = docId;
        //                cmd.Parameters.Add(mid);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(Tbl);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobFileContent() procedure is loaded", LogLevel.Information, null);
        //                return Tbl;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobFileContent() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        public DataTable GetThirdPartyResources()
        //        {
        //            DataTable Tbl = new DataTable();

        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetThirdPartyResources";
        //                cmd.Connection = conn;
        //                DataSet ds = new DataSet();
        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(ds);
        //                Tbl = ds.Tables[0];
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetThirdPartyResources() procedure is loaded", LogLevel.Information, null);
        //                // int found = 0;
        //                return Tbl;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetThirdPartyResources() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }


        //        [HttpGet]
        //        [Route("api/jobs/GetjobHistoryDetails")]
        //        public DataTable GetjobHistoryDetails(int ehId)
        //        {

        //            DataTable Tbl = new DataTable();

        //            //connect to database
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetDetailedjobEditHistory";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@ehId", SqlDbType.Int);
        //                mid.Value = ehId;
        //                cmd.Parameters.Add(mid);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(Tbl);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobHistoryDetails() procedure is loaded", LogLevel.Information, null);
        //                return Tbl;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobHistoryDetails() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        [Route("api/jobs/GetjobDocuments")]
        //        public DataTable GetjobDocuments(int locationId, int statusId, int customerId)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetjobDocuments";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@locationId", SqlDbType.Int);
        //                mid.Value = locationId;
        //                cmd.Parameters.Add(mid);

        //                SqlParameter lid = new SqlParameter("@statusId", SqlDbType.Int);
        //                lid.Value = statusId;
        //                cmd.Parameters.Add(lid);

        //                SqlParameter custId = new SqlParameter("@custId", SqlDbType.Int);
        //                custId.Value = customerId;
        //                cmd.Parameters.Add(custId);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(dt);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobDocuments() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobDocuments() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        [Route("api/jobs/GetjobEquipment")]
        //        public DataTable GetjobEquipment(int locationId, int statusId, int customerId, int AssetModelId)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetjobEquipment";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@locationId", SqlDbType.Int);
        //                mid.Value = locationId;
        //                cmd.Parameters.Add(mid);

        //                SqlParameter lid = new SqlParameter("@statusId", SqlDbType.Int);
        //                lid.Value = statusId;
        //                cmd.Parameters.Add(lid);

        //                SqlParameter custId = new SqlParameter("@custId", SqlDbType.Int);
        //                custId.Value = customerId;
        //                cmd.Parameters.Add(custId);

        //                SqlParameter amId = new SqlParameter("@assetModelId", SqlDbType.Int);
        //                amId.Value = AssetModelId;
        //                cmd.Parameters.Add(amId);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(dt);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobEquipment() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobEquipment() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        [Route("api/jobs/GetjobPersonnel")]
        //        public DataTable GetjobPersonnel(int locationId, int statusId, int customerId)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetjobPersonnel";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@locationId", SqlDbType.Int);
        //                mid.Value = locationId;
        //                cmd.Parameters.Add(mid);

        //                SqlParameter lid = new SqlParameter("@statusId", SqlDbType.Int);
        //                lid.Value = statusId;
        //                cmd.Parameters.Add(lid);

        //                SqlParameter custId = new SqlParameter("@custId", SqlDbType.Int);
        //                custId.Value = customerId;
        //                cmd.Parameters.Add(custId);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(dt);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetjobPersonnel() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobPersonnel() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        [Route("api/jobs/GetUsersForjob")]
        //        public DataTable GetUsersForjob(int jobId)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetUsersForjob";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@jobId", SqlDbType.Int);
        //                mid.Value = jobId;
        //                cmd.Parameters.Add(mid);

        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(dt);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetUsersForjob() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetUsersForjob() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }

        //        [HttpGet]
        //        [Route("api/jobs/GetEquipmentForjob")]
        //        public DataTable GetEquipmentForjob(int modelId, int locationId, int jobId)
        //        {
        //            DataTable dt = new DataTable();
        //            SqlConnection conn = new SqlConnection();
        //            try
        //            {
        //                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PTS_DB_ConnectionString"].ToString();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "GetEquipmentForjob";
        //                cmd.Connection = conn;

        //                SqlParameter mid = new SqlParameter("@modelId", SqlDbType.Int);
        //                mid.Value = modelId;
        //                cmd.Parameters.Add(mid);

        //                SqlParameter lid = new SqlParameter("@locationId", SqlDbType.Int);
        //                lid.Value = locationId;
        //                cmd.Parameters.Add(lid);


        //                SqlParameter jid = new SqlParameter("@jobId", SqlDbType.Int);
        //                jid.Value = jobId;
        //                cmd.Parameters.Add(jid);


        //                SqlDataAdapter db = new SqlDataAdapter(cmd);
        //                db.Fill(dt);
        //                Logger.Trace(LogCategory.WebApp, "DataTable in GetEquipmentForjob() procedure is loaded", LogLevel.Information, null);
        //                return dt;
        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.Error(ex, LogCategory.WebApp, "An error occured in GetEquipmentForjob() procedure", LogLevel.Error, null);
        //                throw ex;
        //            }
        //        }
        //        public void Options() { }
        //    }
        //}

        //    }


        //----------------------------------------//
        //[HttpGet]
        //[Route("api/Cards/DisplayUserInfo")]
        //public DataTable DisplayUserInfo(int CardType, float CardNumber)
        //{

        //    DataTable Tbl = new DataTable();

        //    SqlConnection conn = new SqlConnection();
        //    //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //    SqlCommand cmd = new SqlCommand();


        //    cmd.CommandText = "GetCardUserInfo";
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.Add("@CardType", SqlDbType.Int).Value = CardType;
        //    cmd.Connection = conn;

        //    cmd.Parameters.Add("@CardNumber", SqlDbType.Int).Value = CardNumber;

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(Tbl);
        //    return Tbl;
        //}

        /*----------------------------------------TransactionType------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetTransactionType")]
        public DataTable GetTransactionType()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTransactionType";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        /*---------------------------------------------------GetReferenceId-------------------------------------------------------------------*/
        [HttpGet]
        [Route("api/Cards/GetReferenceId")]
        public DataTable GetReferenceId()
        {
            try
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetReferenceId";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tbl = ds.Tables[0];
                // Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tbl;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        /*--------------------------------------------------------------------------------------------------------------------------------------*/
        //[HttpGet]
        //[Route("api/Cards/GetCardUsers")]
        //public DataSet GetCardUsers()
        //{
        //    try
        //    {


        //        connect to database
        //        SqlConnection conn = new SqlConnection();
        //        conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetCardUsers";
        //        cmd.Connection = conn;
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter db = new SqlDataAdapter(cmd);
        //        db.Fill(ds);

        //         Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //         Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
        //        throw ex;
        //    }
        //}



        //public DataTable Tbl { get; set; }
        //public DataTable Tb2 { get; set; }
        /*---------------------------------------get Userid------------------------------------------------*/

        [HttpGet]
        [Route("api/Cards/GetUserids")]
        public DataTable GetUserids()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getUserid";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }





        /*------------------------------------------Get Customers----------------------------------*/
        [HttpGet]
        [Route("api/Cards/getCustomers")]
        public DataTable GetCustomers()
        {
            try
            {
                DataTable Tb2 = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //conn.connetionString="Data Source=localhost;Initial Catalog=btposdb;integrated security=sspi";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCustomers";
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(ds);
                Tb2 = ds.Tables[0];
                //Logger.Trace(LogCategory.WebApp, "DataTable in GetjobsList() procedure is loaded", LogLevel.Information, null);
                return Tb2;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, LogCategory.WebApp, "An error occured in GetjobsList() procedure", LogLevel.Error, null);
                throw ex;
            }
        }


        [HttpPost]
        [Route("api/Cards/CardTransaction")]
        public DataTable CardTransaction(Cards ca)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdCardTransaction";

            cmd.Connection = con;

            SqlParameter a = new SqlParameter("@flag", SqlDbType.VarChar);
            a.Value = ca.flag;
            cmd.Parameters.Add(a);

            SqlParameter b = new SqlParameter("@CardId", SqlDbType.VarChar,50);
            b.Value = ca.CardId;
            cmd.Parameters.Add(b);

            SqlParameter c = new SqlParameter("@TransactionId", SqlDbType.VarChar, 50);
            c.Value = ca.TransactionId;
            cmd.Parameters.Add(c);

            SqlParameter d = new SqlParameter("@TransactionNo", SqlDbType.VarChar, 50);
           d.Value = ca.TransactionNo;
            cmd.Parameters.Add(d);

            SqlParameter e = new SqlParameter("@TransactionDateTime", SqlDbType.DateTime );
            e.Value = ca.TransactionDateTime;
            cmd.Parameters.Add(e);

            SqlParameter f = new SqlParameter("@TransactionName", SqlDbType.VarChar, 50);
            f.Value = ca.TransactionName;
            cmd.Parameters.Add(f);

            SqlParameter g = new SqlParameter("@TransactionType", SqlDbType.VarChar, 50);
            g.Value = ca.TransactionType;
            cmd.Parameters.Add(g);

            SqlParameter h = new SqlParameter("@TransactionAmount", SqlDbType.Float);
            h.Value = ca.TransactionAmount;
            cmd.Parameters.Add(h);

            SqlParameter i = new SqlParameter("@TransactionStatus", SqlDbType.VarChar, 50);
            i.Value = ca.TransactionStatus;
            cmd.Parameters.Add(i);

            SqlParameter j = new SqlParameter("@TransactionLoc", SqlDbType.VarChar, 50);
            j.Value = ca.TransactionLoc;
            cmd.Parameters.Add(j);

            SqlParameter k = new SqlParameter("@TransactionMode", SqlDbType.VarChar, 50);
            k.Value = ca.TransactionMode;
            cmd.Parameters.Add(k);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }

}
