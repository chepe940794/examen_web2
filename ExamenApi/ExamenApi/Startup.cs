using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenApi.Startup))]
namespace ExamenApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
