using ComeBack.API.DAO;
using ComeBack.API.Repository.Interface;
using ComeBack.API.Services;
using Microsoft.AspNetCore.Authorization;
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
            return Ok(new { data });
        }

        [HttpPost("/User/Login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginDAO dao)
        {
            var search = await _repository.SearchUser(dao);
            if(search != null)
            {
                if (BCrypt.Net.BCrypt.Verify(dao.password, search.password))
                {
                    var token = TokenService.GenerateToken(dao);
                    return Ok(new { isLogged = true, token = token });
                }
            }

            return BadRequest(new { isLogged = false });
        }
    }
}
