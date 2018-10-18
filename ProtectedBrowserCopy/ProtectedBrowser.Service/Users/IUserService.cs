using ProtectedBrowser.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Users
{
    public interface IUserService
    {
        UserModel SelectUserByUniqueCode(string uniqueCode);
    }
}
