using System.Net;
using Newtonsoft.Json;

namespace PruebaEntradaGAP.Dominio.DTO
{
    public class RespuestaOperacionError
    {
        public bool Success { get; } = false;

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}