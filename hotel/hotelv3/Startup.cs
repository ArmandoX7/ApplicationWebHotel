using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hotelv3.Startup))]
namespace hotelv3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
