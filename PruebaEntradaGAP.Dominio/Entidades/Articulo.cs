using Newtonsoft.Json;

namespace PruebaEntradaGAP.Dominio.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("description")]
        public string Descripcion { get; set; }

        [JsonProperty("price")]
        public decimal Precio { get; set; }

        [JsonProperty("total_in_shelf")]
        public int TotalEnVitrina { get; set; }

        [JsonProperty("total_in_vault")]
        public int TotalEnBodega { get; set; }

        [JsonProperty("store_id")]
        public int IdTienda { get; set; }

        [JsonProperty("store")]
        public virtual Entidades.Tienda Tienda { get; set; }
    }
}