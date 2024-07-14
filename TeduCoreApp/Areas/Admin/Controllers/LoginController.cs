using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using TeduCoreApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Areas.Admin.Controllers;

[Area("Admin")]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ILogger _logger;


    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
        , ILogger<LoginController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Authen(LoginViewModel model)
    {
        if (!ModelState.IsValid) return new ObjectResult(new GenericResult(false, model));

        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        var result =
            await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                lockoutOnFailure: false);
        if (result.Succeeded)
        {
            _logger.LogInformation("User logged in");
            return new OkObjectResult(new GenericResult());
        }

        if (!result.IsLockedOut) return new ObjectResult(new GenericResult(false, "Invalid login attempt"));

        _logger.LogWarning("User account locked out");
        return new ObjectResult(new GenericResult(false, "User account locked out"));

        // If we got this far, something failed, redisplay form
    }
}