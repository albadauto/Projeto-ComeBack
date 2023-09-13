using BCrypt.Net;
using ComeBack.Web.Models;
using ComeBack.Web.Services.Interface;

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
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            var factory = _httpClientFactory.CreateClient();
            var response = await factory.PostAsJsonAsync(apiUrl + "/api/User", user);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
