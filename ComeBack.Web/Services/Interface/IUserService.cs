using ComeBack.Web.Models;

namespace ComeBack.Web.Services.Interface
{
    public interface IUserService
    {
       Task<bool> InsertNewUser(User user);
    }
}
