using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Filters;

namespace Workie.Web.Admin.Areas.Apps.Controllers
{
    [Area("Apps")]
    [Authorize]
    [AuthorizeCurrentUser]
    public class ReminderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
