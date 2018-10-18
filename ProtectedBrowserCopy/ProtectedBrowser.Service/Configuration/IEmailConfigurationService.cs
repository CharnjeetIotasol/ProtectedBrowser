using ProtectedBrowser.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedBrowser.Service.Configuration
{
    public interface IEmailConfigurationService
    {
        EmailConfigurationModel EmailConfigurationSelect(string configuraionKey);
    }
}
