using AdopcionAnimalesAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdopcionAnimalesAPP.Service
{
    public class ClienteService
    {
        public static string _baseUrl;
        public HttpClient _httpClient; 

        public ClienteService() {
            _baseUrl = "https://apianimalesadopcion.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
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
    }
}
