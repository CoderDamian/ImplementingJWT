using MyAPI.Models.DTOs;
using System.Text;
using System.Text.Json;

namespace MyWebService
{
    public class User : IUser
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public User(HttpClient httpClient)
        {
            // Inicializacion y ajustes de configuracion
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5001");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task CreateJWT(UserDTO userDTO)
        {
            var objetToCreate = JsonSerializer.Serialize(userDTO);

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "Auth");

            httpRequest.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            httpRequest.Content = new StringContent(objetToCreate, Encoding.UTF8);

            httpRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(httpRequest);

            response.EnsureSuccessStatusCode();
        }
    }
}