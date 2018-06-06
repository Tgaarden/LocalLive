using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LokalLive.Startup))]
namespace LokalLive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
