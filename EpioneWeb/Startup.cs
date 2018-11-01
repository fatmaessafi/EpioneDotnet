using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(EpioneWeb.Startup))]
namespace EpioneWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
    }
}
