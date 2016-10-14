using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestTaxi.Startup))]
namespace TestTaxi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
