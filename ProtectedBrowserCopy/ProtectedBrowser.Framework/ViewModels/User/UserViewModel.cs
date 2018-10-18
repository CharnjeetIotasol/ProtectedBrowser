using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.User
{
    public class UserViewModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("emailConfirmed")]
        public bool? EmailConfirmed { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("userProfileEmail")]
        public string UserProfileEmail { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("profileImageUrl")]
        public string ProfileImageUrl { get; set; }
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("mobileNo")]
        public string MobileNo { get; set; }
        [JsonProperty("createdBy")]
        public Nullable<long> CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public Nullable<long> UpdatedBy { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("pin")]
        public int? Pin { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("uniqueCode")]
        public string UniqueCode { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("base64String")]
        public string Base64String { get; set; }
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
        [JsonProperty("isFacebookConnected")]
        public bool? IsFacebookConnected { get; set; }
        [JsonProperty("isGoogleConnected")]
        public bool? IsGoogleConnected { get; set; }
        [JsonProperty("facebookId")]
        public string FacebookId { get; set; }
        [JsonProperty("googleId")]
        public string GoogleId { get; set; }

    }
}
