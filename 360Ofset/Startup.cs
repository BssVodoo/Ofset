using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_360Ofset.Startup))]
namespace _360Ofset
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
