using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PruebaEntradaGAP.Dominio.Entidades;

namespace PruebaEntradaGAP.Datos.Repositorios
{
    public class Articulos
    {
        private readonly SuperZapatosContext _db = new SuperZapatosContext();
        public IEnumerable<Dominio.Entidades.Articulo> ConsultarTodos() => _db.Articulos.Include(S => S.Tienda);
        public IEnumerable<Dominio.Entidades.Articulo> ConsultarTodos(Func<Dominio.Entidades.Articulo, bool> Filtro) => _db.Articulos.Include(S => S.Tienda).Where(Filtro);
        public IEnumerable<Dominio.Entidades.Articulo> ConsultarByIdTienda(int IdTienda) => _db.Articulos.Where(A => A.Tienda.Id == IdTienda);

        public async Task<Articulo> Crear(Articulo Model)
        {
            Model = _db.Articulos.Add(Model);
            await _db.SaveChangesAsync();

            return Model;
        }
    }
}