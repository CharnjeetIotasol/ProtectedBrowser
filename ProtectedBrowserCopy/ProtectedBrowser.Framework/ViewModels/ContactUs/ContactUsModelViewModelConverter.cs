using ProtectedBrowser.Domain.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotasmartBuild.Framework.ViewModels.ContactUs
{
    public static class ContactUsModelViewModelConverter
    {
        public static ContactUsModel ToModel(this ContactUsViewModel x)
        {
            if (x == null) return new ContactUsModel();
            return new ContactUsModel
            {
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                PhoneNumber = x.PhoneNumber,
                Message = x.Message,
                IsDeleted = x.IsDeleted,
                CreatedOn=x.CreatedOn,
                Id=x.Id
            };

        }

        public static ContactUsViewModel ToViewModel(this ContactUsModel x)
        {
            if (x == null) return new ContactUsViewModel();
            return new ContactUsViewModel
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                PhoneNumber = x.PhoneNumber,
                Message = x.Message,
                IsDeleted=x.IsDeleted
            };

        }
    }
}
