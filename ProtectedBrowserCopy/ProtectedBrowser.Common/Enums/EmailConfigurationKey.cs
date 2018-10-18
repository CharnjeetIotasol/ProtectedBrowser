using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Common.Enums
{
    public enum EmailConfigurationKey
    {
        EmailVerification,
        AccountActivated,
        AccountDeactivated,
        ForgotPassword,
        ContactEnquiry
    }
    public enum UserRegistered
    {
        AlreadyRegister,
        NowRegitered,
        Failed
    }
}
