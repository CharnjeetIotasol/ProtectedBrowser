using ProtectedBrowser.Domain;
using ProtectedBrowser.Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework
{
    public static class BasicEntityToBasicViewEntity
    {
        public static CreatedUserViewModel ToViewModel(this CreatedUserModel x)
        {
            if (x == null) return new CreatedUserViewModel();
            return new CreatedUserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                FullName = x.FirstName + " " + x.LastName

            };
        }
        public static UpdatedUserViewModel ToViewModel(this UpdatedUserModel x)
        {
            if (x == null) return new UpdatedUserViewModel();
            return new UpdatedUserViewModel
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                FullName = x.FirstName + " " + x.LastName

            };
        }
    }
}
