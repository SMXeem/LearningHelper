using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningHelper.Startup))]
namespace LearningHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
