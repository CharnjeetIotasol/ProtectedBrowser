using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Users
{
    public class UserModel
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserProfileEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string MobileNo { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Pin { get; set; }
        public string Address { get; set; }
        public string UniqueCode { get; set; }

        public string Password { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public string Base64String { get; set; }
        public string OldPassword { get; set; }
        public IList<string> Roles { get; set; }
        public bool? IsFacebookConnected { get; set; }
        public bool? IsGoogleConnected { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
    }
}
