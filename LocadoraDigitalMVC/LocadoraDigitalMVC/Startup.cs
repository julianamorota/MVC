using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocadoraDigitalMVC.Startup))]
namespace LocadoraDigitalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
