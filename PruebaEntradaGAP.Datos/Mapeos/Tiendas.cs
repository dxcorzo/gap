using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaEntradaGAP.Datos.Mapeos
{
    public class Tiendas : EntityTypeConfiguration<Dominio.Entidades.Tienda>
    {
        public Tiendas()
        {
            ToTable("Stores");

            Property(P => P.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(P => P.Nombre).HasColumnName("name");
            Property(P => P.Direccion).HasColumnName("address").IsOptional();

            HasKey(P => P.Id);
        }
    }
}