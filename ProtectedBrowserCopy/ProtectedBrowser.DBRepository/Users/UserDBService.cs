using ProtectedBrowser.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Users
{
    public class UserDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
       
        public UserModel UserProfileByUniqueCode(string uniqueCode)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.SelectUserProfileByUniqueCode(uniqueCode).Select(x => new UserModel
                {
                    Email = x.Email,
                    FirstName = x.firstName,
                    FullName = x.firstName + " " + x.lastName,
                    LastName = x.lastName,
                    IsActive = x.IsActive,
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber,
                    ProfileImageUrl = x.ProfilePic,
                    UniqueCode = x.UniqueCode
                 }).FirstOrDefault();
            }
        }
    }


}
