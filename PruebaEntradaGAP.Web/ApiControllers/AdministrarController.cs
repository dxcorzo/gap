using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using PruebaEntradaGAP.Dominio.DTO;
using PruebaEntradaGAP.Dominio.Interfaces;
using PruebaEntradaGAP.Core.Filtros;

namespace PruebaEntradaGAP.Web.ApiControllers
{
    [HandleException]
    [BasicAuthentication]
    public class AdministrarController : ApiController
    {
        private readonly ITiendas _tiendas;
        private readonly IArticulos _articulos;

        public AdministrarController(ITiendas Zapatos, IArticulos Articulos)
        {
            _tiendas = Zapatos;
            _articulos = Articulos;
        }

        /// <summary>
        /// Genera un error intencionado, para ver el response para manejo de excepciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("services/raise-error")]
        public IHttpActionResult GenerarError()
        {
            throw new Exception();
        }

        /// <summary>
        /// Consultar las tiendas registradas en el sistema
        /// </summary>
        [HttpGet]
        [Route("services/stores")]
        public IHttpActionResult ConsultarTiendas()
        {
            var lista = _tiendas.Consultar();

            var retorno = new RespuestaOperacionTiendas
            {
                Stores = lista,
                Success = true,
                TotalElements = lista.Count()
            };

            return Ok(retorno);
        }

        /// <summary>
        /// Consultar los articulos registrados en el sistema
        /// </summary>
        [HttpGet]
        [Route("services/articles")]
        public IHttpActionResult ConsultarArticulos()
        {
            var lista = _articulos.Consultar();

            var retorno = new RespuestaOperacionArticulos
            {
                Articles = lista,
                Success = true,
                TotalElements = lista.Count()
            };

            return Ok(retorno);
        }

        /// <summary>
        /// Consultar un articulo de la tienda
        /// </summary>
        /// <param name="IdTienda"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("services/articles/stores/{idTienda:int}")]
        public IHttpActionResult ConsultarArticuloByIdTienda(int IdTienda)
        {
            // verificar la existencia de la tienda
            var tienda = _tiendas.Consultar(IdTienda);

            if (tienda == null)
            {
                var retornoNoData = new Dominio.DTO.RespuestaOperacionError
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ErrorMessage = Core.Recursos.MensajesError.RegistroNoEncontrado
                };

                return Ok(retornoNoData);
            }

            // Consultar articulos asociados a la tienda
            var lista = _articulos.ConsultarByIdTienda(IdTienda);

            var retorno = new RespuestaOperacionArticulos
            {
                Articles = lista,
                Success = true,
                TotalElements = lista.Count()
            };

            return Ok(retorno);
        }

        [HttpGet]
        [Route("services/articles/{IdArticulo:int}")]
        public IHttpActionResult ConsultarArticuloById(int IdArticulo)
        {
            var item = _articulos.Consultar(IdArticulo);

            if (item == null)
            {
                var retornoNoData = new Dominio.DTO.RespuestaOperacionError
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ErrorMessage = Core.Recursos.MensajesError.RegistroNoEncontrado
                };

                return Ok(retornoNoData);
            }

            var retorno = new RespuestaOperacion<Dominio.Entidades.Articulo>
            {
                Resultado = item,
                Success = true
            };

            return Ok(retorno);
        }

        [HttpPost]
        [Route("services/articles/create")]
        public async Task<IHttpActionResult> CrearArticuloAsync(Dominio.Entidades.Articulo Model)
        {
            Model = await _articulos.Crear(Model);

            return Ok(Model);
        }

        [HttpPost]
        [Route("services/stores/create")]
        public async Task<IHttpActionResult> CrearTiendaAsync(Dominio.Entidades.Tienda Model)
        {
            var retorno = new RespuestaOperacion<Dominio.Entidades.Tienda>
            {
                Resultado = await _tiendas.Crear(Model),
                Success = true
            };

            return Ok(retorno);
        }

        [HttpPost]
        [Route("services/stores/update")]
        public async Task<IHttpActionResult> ActualizarTiendaAsync(Dominio.Entidades.Tienda Model)
        {
            var retorno = new RespuestaOperacion<Dominio.Entidades.Tienda>
            {
                Resultado = await _tiendas.Actualizar(Model),
                Success = true
            };

            return Ok(retorno);
        }
    }
}