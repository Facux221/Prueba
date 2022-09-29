using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectDaredevil.Models;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectDaredevil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly ILogger<PersonajeController> _logger;

        public PersonajeController(ILogger<PersonajeController> logger)
        {
            _logger = logger;
        }

 

        [HttpGet("Frases")]
        public async Task<string> MostrarFrase()
        {
            var broma = "error";
            using (var httpClient = new HttpClient())
            {
                var api = "https://api.chucknorris.io/jokes/random";
                httpClient.BaseAddress = new Uri(api);
                var responseMessage = await httpClient.GetAsync(api);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);
                    broma = data.value;
                }
            }
            return broma;
        }

        [HttpGet("Categoria")]
        public async Task<string> Categorias(string categoria)
        {
            var broma = "error";
            using (var httpClient = new HttpClient())
            {
                var api = "https://api.chucknorris.io/jokes/categories=" + categoria;
                httpClient.BaseAddress = new Uri(api);

                var responseMessage = await httpClient.GetAsync(api);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);
                    broma = data.value;
                }
            }
            return broma;
        }

        [HttpGet("Category")]
        public async Task<dynamic> Category()
        {
            var broma = "error";
            using (var httpClient = new HttpClient())
            {
                var api = "https://api.chucknorris.io/jokes/categories";
                httpClient.BaseAddress = new Uri(api);

                var responseMessage = await httpClient.GetAsync(api);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = Convert.ToString(JsonConvert.DeserializeObject(jsonContent));
                    //String Categoria = Convert.ToString(data.ToString());
                    broma = data;
                    broma = broma.Replace("Chuck Norris", "Daredevil");
                }
            }
            return broma;
        }

    

        [HttpGet("Querys")]
        public async Task<string> Query(string query)
        {
            var broma = "error";
            using (var httpClient = new HttpClient())
            {
                var api = "https://api.chucknorris.io/jokes/search?query=" + query;
                httpClient.BaseAddress = new Uri(api);

                var responseMessage = await httpClient.GetAsync(api);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);

                     foreach (JProperty lista in data)
                        {
                            String Distribuidor = Convert.ToString(data.ToString());
                            broma = Distribuidor;
                            broma = broma.Replace("Chuck Norris", "Daredevil");
                        }                                                    
                }
            }
            return broma;
        }



    }
}