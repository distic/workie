using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Workie.Web.Admin.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class ProfileController : CustomController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}