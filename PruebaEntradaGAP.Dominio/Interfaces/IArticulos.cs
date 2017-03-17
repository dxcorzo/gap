using System.Collections.Generic;
using PruebaEntradaGAP.Dominio.Entidades;

namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public interface IArticulos : IRepositorio<Entidades.Articulo>
    {
        IEnumerable<Articulo> ConsultarByIdTienda(int IdTienda);
    }
}