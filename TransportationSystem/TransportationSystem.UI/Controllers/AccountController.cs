
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using TransportationSystem.UI.Contracts.Account;
using TransportationSystem.UI.ViewModels.Account;

namespace TransportationSystem.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #region Register
        [HttpGet("/Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegistrationView registerVM, string RegisterType)
        {
            if (RegisterType == "User")
            {
                var result = await _authenticationService.Register(registerVM);
                if (result)
                {
                    return Redirect("/");
                }
            }
            else
            {
                var result = await _authenticationService.Register(registerVM, 5);
                if (result)
                {
                    return Redirect("/");
                }
            }

            ModelState.AddModelError("", "Creation faild ... try again later");
            return View(registerVM);


        }
        #endregion
        #region Login
     
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
     
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.Authenticate(loginVM);
                if (result)
                {
                    return Redirect("/Home/Index");
                }
            }
           
                ModelState.AddModelError("", "Login faild ... try again later");
                return View(loginVM);

            
        }
        #endregion
    }
}
