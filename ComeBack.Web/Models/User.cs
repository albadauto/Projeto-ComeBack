namespace ComeBack.Web.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserApiResponse
    {
        public List<User> data { get; set; }
        public string token { get; set; }
    }
}
