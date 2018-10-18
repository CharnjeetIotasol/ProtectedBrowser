using ProtectedBrowser.Domain.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.ContactUs
{
   public class ContactUsDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public void ContactUsInsert(ContactUsModel model)
        {
            using (var dbctx = DbContext)
            {
                dbctx.ContactUsInsert(model.Name, model.PhoneNumber, model.EmailAddress, model.Message);
            }
        }
        public void ContactUsDelete(long? id)
        {
            using (var dbctx = DbContext)
            {
                dbctx.ContactUsDelete(id);
            }
        }

        public List<ContactUsModel> ContactUsSelect(long? id, int? next = null, int? offset = null)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.ContactUsSelect(id, next, offset).Select(x => new ContactUsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    PhoneNumber = x.PhoneNumber,
                    EmailAddress = x.EmailAddress,
                    Message = x.Message
                }).ToList();
            }
        }
    }
}
