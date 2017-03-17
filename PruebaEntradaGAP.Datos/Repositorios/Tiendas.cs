using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaEntradaGAP.Dominio.Entidades;

namespace PruebaEntradaGAP.Datos.Repositorios
{
    public class Tiendas
    {
        private readonly SuperZapatosContext _db = new SuperZapatosContext();
        public IEnumerable<Dominio.Entidades.Tienda> ConsultarTodas() => _db.Tiendas.ToList();
        public Dominio.Entidades.Tienda ConsultarById(int Id) => _db.Tiendas.Find(Id);

        public async Task<Tienda> Crear(Tienda Model)
        {
            Model = _db.Tiendas.Add(Model);
            await _db.SaveChangesAsync();
            return Model;
        }

        public async Task<Tienda> Actualizar(Tienda Model)
        {
            _db.Entry(Model).State = System.Data.Entity.EntityState.Modified;
            await _db.SaveChangesAsync();
            return Model;
        }
    }
}