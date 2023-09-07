using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TTTN_WEB_ASP.Startup))]
namespace TTTN_WEB_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
