using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaEntradaGAP.Datos;
using PruebaEntradaGAP.Dominio.Entidades;
using PruebaEntradaGAP.Dominio.Interfaces;

namespace PruebaEntradaGAP.Core
{
    public class Tiendas : ITiendas
    {
        private readonly Datos.Repositorios.Tiendas _db = new Datos.Repositorios.Tiendas();

        /// <inheritdoc />
        public IEnumerable<Dominio.Entidades.Tienda> Consultar()
        {
            return _db.ConsultarTodas();
        }

        /// <inheritdoc />
        public Dominio.Entidades.Tienda Consultar(int Id)
        {
             return _db.ConsultarById(Id);
        }

        /// <inheritdoc />
        public async Task<Tienda> Crear(Tienda Model)
        {
            return await _db.Crear(Model);
        }

        /// <inheritdoc />
        public async Task<Tienda> Actualizar(Tienda Model)
        {
            return await _db.Actualizar(Model);
        }
    }
}
