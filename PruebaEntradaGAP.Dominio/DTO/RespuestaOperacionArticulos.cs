using System.Collections.Generic;
using PruebaEntradaGAP.Dominio.Interfaces;

namespace PruebaEntradaGAP.Dominio.DTO
{
    public class RespuestaOperacionArticulos : RespuestaOperacion
    {
        public IEnumerable<Entidades.Articulo> Articles { get; set; }
    }
}