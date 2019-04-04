using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Workie.Web.Admin.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Authorize]
    public class LogoutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.Session.Clear();

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errors", new { area = "" });
            }
        }
    }
}
