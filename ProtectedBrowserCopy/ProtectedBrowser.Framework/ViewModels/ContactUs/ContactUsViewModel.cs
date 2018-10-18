using Newtonsoft.Json;
using System;

namespace IotasmartBuild.Framework.ViewModels.ContactUs
{
    public class ContactUsViewModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("createdOn")]
        public DateTimeOffset? CreatedOn { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
