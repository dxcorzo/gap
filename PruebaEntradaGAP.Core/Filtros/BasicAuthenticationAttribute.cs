using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace PruebaEntradaGAP.Core.Filtros
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            string
                    usuario = string.Empty,
                    clave = string.Empty,
                    authToken = actionContext.Request.Headers.Authorization?.Parameter ?? "";

            if (authToken != "")
            {
                usuario = authToken.Substring(0, authToken.IndexOf(":"));
                clave = authToken.Substring(authToken.IndexOf(":") + 1);

                if (usuario == "my_user" && clave == "my_password")
                {
                    base.OnActionExecuting(actionContext);
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent
                    (
                        typeof(Dominio.DTO.RespuestaOperacionError),
                        new Dominio.DTO.RespuestaOperacionError { ErrorCode = (int)HttpStatusCode.OK, ErrorMessage = Core.Recursos.MensajesError.NoAutorizado },
                        new JsonMediaTypeFormatter()
                    )
                };
            }
        }
    }
}