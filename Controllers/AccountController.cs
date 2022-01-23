using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrintManager.ViewModels;

namespace PrintManager.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            if (returnUrl == "/Account/Login")
                returnUrl = "/";

            if (_signInManager.IsSignedIn(User))
            {
                _logger.LogInformation("User is already logged in.");
                return Redirect(returnUrl);
            }
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var signInResult = (await _signInManager.PasswordSignInAsync(user,
                                         loginModel.Password, false, false));
                    if (signInResult.Succeeded)
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                }
            }
            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}