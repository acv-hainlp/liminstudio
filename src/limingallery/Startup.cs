using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(limingallery.Startup))]
namespace limingallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
