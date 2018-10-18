using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.Configuration
{
    public class EmailConfigurationModel
    {
        public int Id { get; set; }
        public string ConfigurationKey { get; set; }
        public string ConfigurationValue { get; set; }
        public string EmailSubject { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
