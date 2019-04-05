using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Microsoft.AspNetCore.Authorization;
using Workie.Web.Admin.Filters;

namespace Workie.Web.Admin.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    [AuthorizeCurrentUser]
    public class ProfileController : CustomController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}