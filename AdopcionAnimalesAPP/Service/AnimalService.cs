using AdopcionAnimalesAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionAnimalesAPP.Service
{
  
    public class AnimalService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;



        public AnimalService()
        {
            _baseUrl = "https://apianimalesadopcion.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<List<Animal>> GetAllAnimales()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
            return response;
        }

        public async Task<Animal> GetAnimal(int Id)
        {
            var response = await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{Id}");
            return response;
        }

        public async Task<Animal> CreateAnimal(Animal animal)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Animal", animal);
            Console.WriteLine(response.Content.ReadAsStringAsync());
            if (response != null) { return await response.Content.ReadFromJsonAsync<Animal>(); }
            return null;

        }

        public async Task<Animal> UpdateAnimal(int Id, Animal animal)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Animal/{Id}", animal);
            return await response.Content.ReadFromJsonAsync<Animal>();
        }

        public async Task DeleteAnimal(int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/Animal/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Animal>> BuscarPorPropietario(string Propietario)
        {
            if (Propietario != null && Propietario != "")
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<List<Animal>>($"api/Animal/GetAnimalesPorCedula/{Propietario}");
                    return response ?? new List<Animal>(); // Si response es null, devuelve una lista vacía
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Manejar el error 404 (Not Found) devolviendo una lista vacía
                    return new List<Animal>();
                }
            }
            else
            {
                throw new ArgumentException("Propietario no válido.");
            }
        }



        public async Task<List<Animal>> Index()
        {
            var animales = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
            var animalesConPropietario = animales.Where(a => a.Propietario == "").ToList();
            return animalesConPropietario;
        }










    }

    
    

}
