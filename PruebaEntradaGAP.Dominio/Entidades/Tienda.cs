using System.Collections.Generic;
using Newtonsoft.Json;

namespace PruebaEntradaGAP.Dominio.Entidades
{
    public class Tienda
    {
        public Tienda()
        {
            Articulos = new List<Articulo>();
        }

        public int Id { get; set; }
        [JsonProperty("name")]
        public string Nombre { get; set; }
        [JsonProperty("address")]
        public string Direccion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}