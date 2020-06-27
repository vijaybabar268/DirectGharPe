using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DirectGharPe.Startup))]
namespace DirectGharPe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
