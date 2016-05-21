using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyBankP2p.Startup))]
namespace SkyBankP2p
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
