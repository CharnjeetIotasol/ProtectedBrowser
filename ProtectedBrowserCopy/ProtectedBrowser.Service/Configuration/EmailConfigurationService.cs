using ProtectedBrowser.DBRepository.Configuration;
using ProtectedBrowser.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Configuration
{
    public class EmailConfigurationService: IEmailConfigurationService
    {
        public EmailConfigurationDBService _emailConfigurationDBServicee;
        public EmailConfigurationService()
        {
            _emailConfigurationDBServicee = new EmailConfigurationDBService();
        }
        public EmailConfigurationModel EmailConfigurationSelect(string configuraionKey)
        {
            return _emailConfigurationDBServicee.EmailConfigurationSelect(configuraionKey);
        }
    }
}
