using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Common.Success
{
   public class SuccessMessage
    {
        public class AccountSuccess
        {
            public const string USER_REGISTERED = "Account Registered Successfully";
            public const string PASSWORD_CHANGED = "Password Changed Successfully. Please login";
            public const string EMAIL_CONFIRM = "Your email confirm";
            public const string ACTIVATED = "User Activated Successfully";
            public const string DEACTIVATED = "User DeActivated Successfully";
            public const string DELETED = "User Deleted SuccessFully";
            public const string FORGOT_PASSWORD_LINK = "We have sent password change link to your email";
            public const string PROFILE_UPDATE = "Profile Updated Successfully";
        }
    }
}
