using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comessa6.Startup))]
namespace Comessa6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
