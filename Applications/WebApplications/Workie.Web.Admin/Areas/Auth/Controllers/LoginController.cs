using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Workie.Core.BusinessLogic.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Workie.Web.Admin.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResetPassword(string emailAddress)
        {
            try
            {
                new UserManager().RaiseAttentionForResetPassword(emailAddress);

                return Json(new
                {
                    result = true
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string emailAddress, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
                {
                    //TODO: Sort this out.
                    return Content("Email or password is empty. Cannot proceed with the login.");
                }

                var userManager = new UserManager();

                var userEntity = userManager.SelectByEmailAndPassword(emailAddress, password);

                if (userEntity == null)
                {
                    //TODO: Sort this out.
                    return Content("Login failure, please try again.");
                }

                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(CustomClaimTypes.UserId, userEntity._id),
                    new Claim(CustomClaimTypes.EmailAddress, userEntity.EmailAddress),
                    new Claim(CustomClaimTypes.FirstName, userEntity.FirstName),
                    new Claim(CustomClaimTypes.LastName, userEntity.LastName),
                    new Claim(CustomClaimTypes.SupportPin, string.Empty),
                    new Claim(CustomClaimTypes.IsFirstLogin, userEntity.Attention.IsFirstLogin.ToString())
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
    }
}