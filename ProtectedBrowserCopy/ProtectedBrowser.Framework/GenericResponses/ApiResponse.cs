using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.GenericResponse
{
    /// <summary>
    /// It represent the error and success response 
    /// </summary>
    /// <typeparam name="T">Type of data for response</typeparam>
    public class ApiRespone<T>
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        #region Conditional Response
        public bool ShouldSerializeMessage()
        {
            return Message != null;
        }

        public bool ShouldSerializeData()
        {
            return Data != null;
        }
        #endregion
    }
}
