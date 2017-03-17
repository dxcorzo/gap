using Newtonsoft.Json;

namespace PruebaEntradaGAP.Dominio.DTO
{
    public class RespuestaOperacion<T> where T : class
    {
        [JsonProperty("result")]
        public T Resultado { get; set; }
        public bool Success { get; set; }
    }
}