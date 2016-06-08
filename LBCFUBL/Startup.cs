using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LBCFUBL.Startup))]
namespace LBCFUBL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
