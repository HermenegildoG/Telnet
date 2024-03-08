using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telnet.Shared.Models;

namespace Telnet.Server.Controller
{
    [Route("api/tienda")]
    public class TiendaController : ControllerBase
    {
        
        private HttpClient _httpClient;
        public TiendaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("listartiendas/")]
        public async Task<Tienda> ObtenerTiendas()
        {
            Tienda tienda = new Tienda();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("https://localhost:7036/servicios/Tienda");
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            tienda = JsonConvert.DeserializeObject<Tienda>(responseBody);
            return tienda;
        }

    }
}
