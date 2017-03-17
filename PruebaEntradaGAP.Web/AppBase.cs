using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PruebaEntradaGAP.Web.Startup;

namespace PruebaEntradaGAP.Web
{
    public class AppBase : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}