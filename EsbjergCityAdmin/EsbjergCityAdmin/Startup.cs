using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsbjergCityAdmin.Startup))]
namespace EsbjergCityAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
