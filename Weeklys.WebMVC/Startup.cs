using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Weeklys.WebMVC.Startup))]
namespace Weeklys.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
