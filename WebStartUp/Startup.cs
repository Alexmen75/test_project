using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStartUp.Startup))]
namespace WebStartUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
