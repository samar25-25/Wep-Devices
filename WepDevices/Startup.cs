using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WepDevices.Startup))]
namespace WepDevices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
