using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartupAttribute(typeof(EpioneWeb.Startup))]
namespace EpioneWeb
{
    public partial class Startup
    {/*
       public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookies",
                LoginPath = new PathString("/auth/login")
            });
                
          
        }*/
    }
}
