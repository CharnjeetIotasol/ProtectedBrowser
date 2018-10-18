using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.User
{
    public class TokenViewModel
    {
        
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
       
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonIgnore]
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonIgnore]
        [JsonProperty(".issued")]
        public string Issued { get; set; }

        [JsonIgnore]
        [JsonProperty("expires")]
        public DateTimeOffset Expires { get; set; }
        [JsonIgnore]
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonIgnore]
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        
        

        [JsonIgnore]
        [JsonProperty("roles")]
        public IList<string> Role { get; set; }
        [JsonProperty("RoleString")]
        public string RoleString
        {
            get { return _roleString; }
            set
            {
                _roleString = value;
                if (!string.IsNullOrEmpty(_roleString))
                    Role = JsonConvert.DeserializeObject<IList<string>>(_roleString);
            }
        }

        string _roleString;
        public bool ShouldSerializeRoleString()
        {
            return false;
        }

        [JsonProperty("tokenData")]
        public tokenData TokenData { get; set; }

    }
    public class tokenData {
        [JsonProperty("user")]
        public UserViewModel User { get; set; }
        [JsonProperty("token")]
        public tokenObj Token { get; set; }
    }
    public class tokenObj {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("tokenType")]
        public string TokenType { get; set; }
        [JsonProperty("expires")]
        public DateTimeOffset Expires { get; set; }
    }
}
