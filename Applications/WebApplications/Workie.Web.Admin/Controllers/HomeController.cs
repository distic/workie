using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Workie.Core.BusinessLogic.Users;
using Workie.Web.Admin.Filters;
using Workie.Web.Admin.Models;
using Workie.Web.Admin.Utilities;

namespace Workie.Web.Admin.Controllers
{
    [Authorize]
    [AuthorizeCurrentUser]
    public class HomeController : CustomController
    {
        public IActionResult Index()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
