using BCrypt.Net;
using ComeBack.Web.Models;
using ComeBack.Web.Services.Interface;
using Newtonsoft.Json;

namespace ComeBack.Web.Services
{
    public class UserService : IUserService
    {
        private IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private string apiUrl;
        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            apiUrl = $"{_configuration.GetValue<string>("APIURL")}";
        }

        public async Task<bool> InsertNewUser(User user)
        {
            var factory = _httpClientFactory.CreateClient();
            var response = await factory.PostAsJsonAsync(apiUrl + "/api/User", user);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<LoginApiResponse> LoginUser(User user)
        {
            var factory = _httpClientFactory.CreateClient();
            var response = await factory.PostAsJsonAsync(apiUrl + "/User/Login", user);
            var result = await response.Content.ReadAsStringAsync();
            var final = JsonConvert.DeserializeObject<LoginApiResponse>(result);
            return final;
        }
    }
}
