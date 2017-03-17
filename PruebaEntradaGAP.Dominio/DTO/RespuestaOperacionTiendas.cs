using System.Collections.Generic;
using PruebaEntradaGAP.Dominio.Interfaces;

namespace PruebaEntradaGAP.Dominio.DTO
{
    public class RespuestaOperacionTiendas : RespuestaOperacion
    {
        public IEnumerable<Entidades.Tienda> Stores { get; set; }
    }
}