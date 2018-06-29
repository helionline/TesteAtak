using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proj270618_TesteAtak_AP.Startup))]
namespace Proj270618_TesteAtak_AP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
