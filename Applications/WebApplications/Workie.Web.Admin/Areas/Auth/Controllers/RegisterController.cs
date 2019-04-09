using Microsoft.AspNetCore.Mvc;

namespace Workie.Web.Admin.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
