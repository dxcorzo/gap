using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaEntradaGAP.Dominio.Entidades;
using PruebaEntradaGAP.Dominio.Interfaces;

namespace PruebaEntradaGAP.Core
{
    public class Articulos : IArticulos
    {
        private readonly Datos.Repositorios.Articulos _db = new Datos.Repositorios.Articulos();

        /// <inheritdoc />
        public async Task<Articulo> Crear(Articulo Model)
        {
            return await _db.Crear(Model);
        }

        /// <inheritdoc />
        public IEnumerable<Articulo> Consultar()
        {
            return _db.ConsultarTodos();
        }

        /// <inheritdoc />
        public IEnumerable<Articulo> Consultar(Func<Articulo, bool> Filtro)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Articulo Consultar(int Id)
        {
            return _db.ConsultarTodos(A => A.Id == Id).FirstOrDefault();
        }

        /// <inheritdoc />
        public IEnumerable<Articulo> ConsultarByIdTienda(int IdTienda)
        {
            return _db.ConsultarByIdTienda(IdTienda);
        }

        /// <inheritdoc />
        public Task<Articulo> Actualizar(Articulo Model)
        {
            throw new NotImplementedException();
        }
    }
}