using System.Web.Mvc;

namespace PruebaEntradaGAP.Web.MvcControllers
{
    public class ArticulosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Crear()
        {
            return View();
        }
    }
}