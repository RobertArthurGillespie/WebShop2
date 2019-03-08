using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop2.WebUI.Startup))]
namespace WebShop2.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
