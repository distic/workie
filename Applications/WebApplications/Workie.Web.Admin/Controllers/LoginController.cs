using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Workie.Core.BusinessLogic.Users;

namespace Workie.Web.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string emailAddress, string password)
        {
            try
            {
                //TODO: Sort this out.
                if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
                {
                    return Content("Email or password is empty. Cannot proceed with the login.");
                }

                var userManager = new UserManager();

                var userEntity = userManager.SelectByEmailAndPassword(emailAddress, password);

                //TODO: Sort this out.
                if (userEntity == null)
                {
                    return Content("Login failure, please try again.");
                }

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(CustomClaimTypes.UserId, userEntity._id),
                    new Claim(CustomClaimTypes.EmailAddress, userEntity.EmailAddress),
                    new Claim(CustomClaimTypes.FirstName, userEntity.FirstName),
                    new Claim(CustomClaimTypes.LastName, userEntity.LastName),
                    new Claim(CustomClaimTypes.SupportPin, string.Empty)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IActionResult> Logout()
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