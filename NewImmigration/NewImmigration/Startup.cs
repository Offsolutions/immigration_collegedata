using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewImmigration.Startup))]
namespace NewImmigration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
