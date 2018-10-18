using ProtectedBrowser.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.DBRepository.Configuration
{
    public class EmailConfigurationDBService
    {
        ProtectedBrowserEntities DbContext { get { return new ProtectedBrowserEntities(); } }
        public EmailConfigurationModel EmailConfigurationSelect(string configurationKey)
        {
            using (var dbctx = DbContext)
            {
                return dbctx.EmailConfigurationSelect(configurationKey).Select(x => new EmailConfigurationModel
                {
                    ConfigurationKey = x.ConfigurationKey,
                    ConfigurationValue = x.ConfigurationValue,
                    EmailSubject = x.EmailSubject,
                    Id = x.Id
                }).FirstOrDefault();
            }
        }
    }
}
