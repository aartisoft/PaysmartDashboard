using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySmartDashboard.Models
{
    public class UserLogin
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string LoginInfo { set; get; }
        public string Passkey { set; get; }
        public string Salt { set; get; }
        public string Active { set; get; }

    }
}