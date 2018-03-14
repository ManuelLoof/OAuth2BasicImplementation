using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
    }

    [HttpGet] 
    public async Task<IActionResult> Logout() 
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/index");
    }
}