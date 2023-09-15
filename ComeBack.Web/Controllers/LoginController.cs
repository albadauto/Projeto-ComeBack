using ComeBack.Web.Models;
using ComeBack.Web.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ComeBack.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(User user)
        {
            var response = await _service.LoginUser(user);
            if (response.isLogged)
            {
                HttpContext.Session.SetString("token", response.token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Login ou senha inválido";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("token");
            return RedirectToAction("Index", "Home");

        }
    }
}
