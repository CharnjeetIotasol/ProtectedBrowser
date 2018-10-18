using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtectedBrowser.Common.Constants
{
    public partial class ErrorMessage
    {
        public class AccountError
        {
            public const string INCORRECT = "Username or password incorrect.";
            public const string ACTIVATE = "Your account is not activated by admin.";
            public const string DELETED = "User Does not Exist.";
            public const string INVALID_LINK = "Invalid Confirmation Link.";
            public const string INVALID_EMAIL = "Invalid EmailId.";
            public const string INVALID = "Invalid Request.";
            public const string EMAIL_ALREADY_REGISTERED = "Email Id {0} is already registered with another account.";
        }
    }
}
