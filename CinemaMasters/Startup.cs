using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaMasters.Startup))]
namespace CinemaMasters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
