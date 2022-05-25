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
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
              var user = _userService.AuthorizationAndRegistration(new UserDTO() { Login = model.Login });

                if (user == null)
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                else
                {
                    HttpContext.Response.Cookies.Append("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
    }
}