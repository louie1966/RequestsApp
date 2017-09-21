using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aanvragen.Web.Startup))]
namespace Aanvragen.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
