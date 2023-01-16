using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAPI.Models.DTOs;
using MyWebService;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MyWebClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public UserDTO UserDTO { get; set; } = null!;

        public LoginModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
            this._httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var objectoToCreate = JsonSerializer.Serialize(UserDTO);

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "Auth");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Content = new StringContent(objectoToCreate, Encoding.UTF8);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("./Index");

            return RedirectToPage("./Error");
        }
    }
}
