using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameBlogApplication.Startup))]
namespace GameBlogApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
