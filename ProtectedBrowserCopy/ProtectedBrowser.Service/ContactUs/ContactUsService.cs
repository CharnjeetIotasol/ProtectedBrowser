using ProtectedBrowser.DBRepository.ContactUs;
using ProtectedBrowser.Domain.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.ContactUs
{
    public class ContactUsService : IContactUsService
    {
        public ContactUsDBService _contactUsDbService;
        public ContactUsService()
        {
            _contactUsDbService = new ContactUsDBService();
        }

        public void ContactUsInsert(ContactUsModel model)
        {
            _contactUsDbService.ContactUsInsert(model);
        }
        public void ContactUsDelete(long? id)
        {
            _contactUsDbService.ContactUsDelete(id);
        }
        public List<ContactUsModel> ContactUsSelect(long? id, int? next = null, int? offset = null)
        {
            return _contactUsDbService.ContactUsSelect(id, next, offset);
        }
    }
}
