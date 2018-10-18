using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProtectedBrowser.Core.Infrastructure;
using ProtectedBrowser.Service.Upload;
using ProtectedBrowser.Service.Users;
using ProtectedBrowser.Service.Xml;
using ProtectedBrowser.Service.FileGroup;
using ProtectedBrowser.Service.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtectedBrowser.Service.Configuration;

namespace ProtectedBrowser.Framework
{
    public class DependancyRegisterar : IDependencyRegistrar
    {
        public int Order
        {
            get
            {
                return 0;
            }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            var assemblyArr = typeFinder.GetAssemblies().ToArray();
            builder.RegisterControllers(assemblyArr);
            builder.RegisterApiControllers(assemblyArr);

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<FileUploadService>().As<IFileUploadService>().InstancePerLifetimeScope();
            builder.RegisterType<XmlService>().As<IXmlService>().InstancePerLifetimeScope();
            builder.RegisterType<EmailConfigurationService>().As<IEmailConfigurationService>().InstancePerLifetimeScope();
            builder.RegisterType<FileGroupService>().As<IFileGroupService>().InstancePerLifetimeScope();
            builder.RegisterType<DirectoryService>().As<IDirectoryService>().InstancePerLifetimeScope();
        }
    }
}
