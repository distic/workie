using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Workie.Web.Admin.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class SettingsController : CustomController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}