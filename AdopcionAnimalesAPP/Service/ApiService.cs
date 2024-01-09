using AdopcionAnimalesAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionAnimalesAPP.Service
{
    public class ApiService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public ApiService()
        {
            _baseUrl = "https://apianimalesetsotikos20240108205054.azurewebsites.net/";
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





        public async Task<bool> DeleteCliente(string Cedula)
        {
            var response = await _httpClient.DeleteAsync($"/api/Cliente/{Cedula}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Cliente> GetCliente(string Cedula)
        {
            var response = await _httpClient.GetAsync($"/api/Cliente/{Cedula}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(json_response);
                return cliente;
            }
            return new Cliente();
        }


        public async Task<List<Cliente>> GetClientes()
        {
            var response = await _httpClient.GetAsync("/api/Cliente");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Cliente> cliente = JsonConvert.DeserializeObject<List<Cliente>>(json_response);
                return cliente;
            }
            return new List<Cliente>();

        }

        public async Task<Cliente> PostCliente(Cliente cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Cliente/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Cliente cliente2 = JsonConvert.DeserializeObject<Cliente>(json_response);
                return cliente2;
            }
            return new Cliente();
        }

        public async Task<Cliente> PutCliente(string Cedula, Cliente cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Producto/{Cedula}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Cliente cliente2 = JsonConvert.DeserializeObject<Cliente>(json_response);
                return cliente2;
            }
            return new Cliente();
        }



        public async Task<List<Veterinario>> GetAllVeterinarios()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Veterinario>>("api/Veterinario");
            return response;
        }
    }
}
