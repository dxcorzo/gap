using System.Data.Entity;

namespace PruebaEntradaGAP.Datos
{
    public class SuperZapatosContext : DbContext
    {
        private DbSet<Dominio.Entidades.Articulo> _articulos;
        private DbSet<Dominio.Entidades.Tienda> _tiendas;

        public SuperZapatosContext() : base("name=Conexion")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Dominio.Entidades.Articulo> Articulos => _articulos ?? (_articulos = Set<Dominio.Entidades.Articulo>());
        public DbSet<Dominio.Entidades.Tienda> Tiendas => _tiendas ?? (_tiendas = Set<Dominio.Entidades.Tienda>());

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
            ModelBuilder.Configurations.Add(new Mapeos.Articulos());
            ModelBuilder.Configurations.Add(new Mapeos.Tiendas());
        }
    }
}