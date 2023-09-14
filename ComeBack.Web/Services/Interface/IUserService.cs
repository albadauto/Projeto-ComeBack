using ComeBack.Web.Models;

namespace ComeBack.Web.Services.Interface
{
    public interface IUserService
    {
       Task<bool> InsertNewUser(User user);

       Task<LoginApiResponse> LoginUser(User user);
    }
}
