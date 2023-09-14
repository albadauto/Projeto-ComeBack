using System.ComponentModel.DataAnnotations;

namespace ComeBack.Web.Models
{
    public class User
    {
        [Required(ErrorMessage = "O campo de nome é de preenchimento obrigatório")]
        public string name { get; set; }
        [Required(ErrorMessage = "O campo de email é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "O email é inválido")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo de senha é obrigatório é de preenchimento obrigatório")]
        public string password { get; set; }
    }
    public class UserApiResponse
    {
        public List<User> data { get; set; }
        public string token { get; set; }
    }

    public class LoginApiResponse
    {
        public bool isLogged { get; set; }
        public string token { get; set; }  
    }
}
