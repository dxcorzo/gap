using Newtonsoft.Json;

namespace PruebaEntradaGAP.Dominio.Interfaces
{
    public abstract class RespuestaOperacion
    {
        public bool Success { get; set; } = false;

        [JsonProperty("total_elements")]
        public int TotalElements { get; set; }
    }
}