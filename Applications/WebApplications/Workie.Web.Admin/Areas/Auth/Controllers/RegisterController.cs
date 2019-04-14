using Microsoft.AspNetCore.Mvc;
using System;

namespace Workie.Web.Admin.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerifyEmail()
        {
            try
            {     
                return PartialView("UserControls/_UserControls_VerifyEmail");
            }
            catch (Exception ex)
            {
                // TODO: Will better handle this error, but for now this is fine.
                return Content("An error was encountered. Please handle me!");
            }
        }
    }
}
