using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCodeFirstVidly.Startup))]
namespace MVCCodeFirstVidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
