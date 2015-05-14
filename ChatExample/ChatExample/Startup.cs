using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatExample.Startup))]
namespace ChatExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
