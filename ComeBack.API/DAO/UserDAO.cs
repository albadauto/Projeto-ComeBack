using System.ComponentModel.DataAnnotations;

namespace ComeBack.API.DAO
{
    public class UserDAO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
