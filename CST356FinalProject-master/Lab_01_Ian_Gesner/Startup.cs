using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_01_Ian_Gesner.Startup))]
namespace Lab_01_Ian_Gesner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
