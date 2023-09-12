using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebTestController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(new { message = "Sucesso desenvolvedor .net ;)" });
        }
    }
}
