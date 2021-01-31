using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Filmellato.Startup))]
namespace Filmellato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
