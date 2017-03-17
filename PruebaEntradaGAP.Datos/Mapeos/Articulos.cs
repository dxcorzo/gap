using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PruebaEntradaGAP.Datos.Mapeos
{
    public class Articulos : EntityTypeConfiguration<Dominio.Entidades.Articulo>
    {
        public Articulos()
        {
            ToTable("Articles");

            Property(P => P.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(P => P.Nombre).HasColumnName("name");
            Property(P => P.Descripcion).HasColumnName("description").IsOptional();
            Property(P => P.Precio).HasColumnName("price");
            Property(P => P.TotalEnBodega).HasColumnName("total_in_vault");
            Property(P => P.TotalEnVitrina).HasColumnName("total_in_shelf");
            Property(P => P.IdTienda).HasColumnName("store_id");

            HasKey(P => P.Id);

            HasRequired(A => A.Tienda).WithMany(T => T.Articulos).HasForeignKey(A => A.IdTienda);
        }
    }
}