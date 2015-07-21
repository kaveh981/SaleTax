using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mapi.Startup))]
namespace Mapi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
