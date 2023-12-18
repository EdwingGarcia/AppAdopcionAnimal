using AdopcionAnimalesAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionAnimalesAPP.Service
{
    public class VeterinarioService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;



        public VeterinarioService()
        {
            _baseUrl = "https://apianimalesadopcion.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }


        public async Task<List<Veterinario>> GetAllVeterinarios()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Veterinario>>("api/Veterinario");
            return response;
        }

    }
}
