using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels
{
    public class BaseViewEntity
    {
        [JsonProperty("createdUser")]
        public CreatedUserViewModel CreatedUser { get; set; }
        [JsonProperty("updatedUser")]
        public UpdatedUserViewModel UpdatedUser { get; set; }
    }
    /// <summary>
    /// It represent the common auditable field for a record
    /// </summary>
    /// 
    public class CreatedUserViewModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("userId")]
        public long? UserId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
    public class UpdatedUserViewModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("userId")]
        public long? UserId { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
