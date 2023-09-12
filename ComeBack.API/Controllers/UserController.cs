using ComeBack.API.DAO;
using ComeBack.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<UserDAO>> InsertNewUser([FromBody] UserDAO userDAO) 
        {
            try
            {
                await _repository.InsertNewUser(userDAO);
                return Ok(new { success = true, message = "Inserido com sucesso" });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        [HttpGet("/User/GetAllUsers")]
        public async Task<ActionResult<List<UserDAO>>> GetAllUsers()
        {
            var data = await _repository.GetAllUsers();
            return Ok(data);
        }
    }
}
