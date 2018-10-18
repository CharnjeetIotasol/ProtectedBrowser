using ProtectedBrowser.Domain.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.ContactUs
{
    public interface IContactUsService
    {
        void ContactUsInsert(ContactUsModel model);
        void ContactUsDelete(long? id);
        List<ContactUsModel> ContactUsSelect(long? id, int? next = null, int? offset = null);
    }
}
