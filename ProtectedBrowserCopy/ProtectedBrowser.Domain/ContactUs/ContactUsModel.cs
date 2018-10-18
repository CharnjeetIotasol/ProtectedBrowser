using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Domain.ContactUs
{
    public class ContactUsModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string Message { get; set; }

    }
}
