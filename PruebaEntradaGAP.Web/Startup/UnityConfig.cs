using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PruebaEntradaGAP.Web.Startup
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<Dominio.Interfaces.ITiendas, Core.Tiendas>();
            container.RegisterType<Dominio.Interfaces.IArticulos, Core.Articulos>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}