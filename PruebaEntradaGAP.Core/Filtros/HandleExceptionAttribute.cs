using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace PruebaEntradaGAP.Core.Filtros
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent
                (
                    typeof(Dominio.DTO.RespuestaOperacionError),
                    new Dominio.DTO.RespuestaOperacionError { ErrorCode = (int)HttpStatusCode.InternalServerError, ErrorMessage = Core.Recursos.MensajesError.ErrorServidor },
                    new JsonMediaTypeFormatter()
                )
            };
        }
    }
}