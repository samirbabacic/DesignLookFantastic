using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lookFantastic.Startup))]
namespace lookFantastic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
