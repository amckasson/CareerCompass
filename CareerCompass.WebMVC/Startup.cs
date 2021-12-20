using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareerCompass.WebMVC.Startup))]
namespace CareerCompass.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
