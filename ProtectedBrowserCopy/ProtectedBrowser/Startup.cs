using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProtectedBrowser.Startup))]
namespace ProtectedBrowser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
