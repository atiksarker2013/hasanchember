using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cornia.web.app.Startup))]
namespace cornia.web.app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
