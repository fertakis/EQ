using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EQ.Startup))]
namespace EQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
