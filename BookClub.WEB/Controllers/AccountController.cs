using BookClub.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using BookClub.BLL.Interfaces;
using BookClub.BLL.DTO;

namespace BookClub.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
              var user = await _userService.AuthorizationAndRegistration(new UserDTO() { Login = model.Login });

                if (user == null)
                    ModelState.AddModelError("", "Ошибка авторизации");
                else
                {
                    HttpContext.Response.Cookies.Append("UserId", user.Id.ToString());
                    return RedirectToAction("GetAllBooks", "Home");
                }
            }

            return View(model);
        }
    }
}