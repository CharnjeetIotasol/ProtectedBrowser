using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Framework.ViewModels.Directory
{
   public class DirectoryViewModel
    {
			  	[JsonProperty("id")]
			  	public long? Id { get; set; }
			  	[JsonProperty("createdBy")]
			  	public long? CreatedBy { get; set; }
			  	[JsonProperty("updatedBy")]
			  	public long? UpdatedBy { get; set; }
				[JsonProperty("createdOn")]
			  	public DateTimeOffset?  CreatedOn { get; set; }
				[JsonProperty("updatedOn")]
			  	public DateTimeOffset?  UpdatedOn { get; set; }
				[JsonProperty("isDeleted")]
			  	public bool? IsDeleted { get; set; }
				[JsonProperty("isActive")]
			  	public bool? IsActive { get; set; }
				[JsonProperty("rootPath")]
        		public string RootPath { get; set; }
				[JsonProperty("userName")]
        		public string UserName { get; set; }
				[JsonProperty("password")]
        		public string Password { get; set; }
				[JsonProperty("name")]
        		public string Name { get; set; }
			[JsonProperty("totalCount")]
		  	public int TotalCount  { get; set; }
    }
}

