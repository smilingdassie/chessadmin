using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChessAdminWebMVC.Startup))]
namespace ChessAdminWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
