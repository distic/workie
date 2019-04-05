using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Filters;
using Workie.Web.Admin.Utilities;

namespace Workie.Web.Admin.Areas.Welcome.Controllers
{
    [Area("Setup")]
    [Authorize]
    [AuthorizeNewUser]
    public class HomeController : CustomController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}