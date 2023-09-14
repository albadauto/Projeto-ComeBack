using ComeBack.Web.Models;
using ComeBack.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ComeBack.Web.Controllers
{
    public class RegisterController : Controller
    {
        private IUserService _service;
        public RegisterController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertNewUser(user);
                TempData["success"] = "Usuário criado com sucesso";
                return RedirectToAction("Index");
            }
            return View("Index", user);
        }
    }
}
