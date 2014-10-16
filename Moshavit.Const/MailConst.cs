using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Const
{
    public class MailConst
    {
        public class From
        {
            public const string EMAIL = "DoNotReplay@moshavit.com";
            public const string DO_NOT_REPLAY = "Do Not Replay";
        }

        public class Account
        {
            public const string HOST = "smtp.gmail.com";
            public const string MAIL_ACCOUNT = "****";
            public const string PASSWORD = "****";
            public const int PORT = 587;
        }

        public class Template
        {
            public const string FORGOT_PASSWORD = "Forgot Password";

            public const string WELCOM_MAIL = "Welcome Mail";
        }
    }
}
