using ProtectedBrowser.DBRepository.Users;
using ProtectedBrowser.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Users
{
    public class UserService : IUserService
    {

        public UserDBService _userDBService;

        public UserService()
        {
            _userDBService = new UserDBService();
        }
        public UserModel SelectUserByUniqueCode(string uniqueCode)
        {
            return _userDBService.UserProfileByUniqueCode(uniqueCode);
        }
    }
}
