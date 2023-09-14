using ComeBack.API.DAO;

namespace ComeBack.API.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserDAO> InsertNewUser(UserDAO userDAO);

        Task<List<UserDAO>> GetAllUsers();

        Task<LoginDAO> SearchUser(LoginDAO user);
    }
}
