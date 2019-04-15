using Microsoft.AspNetCore.Mvc;
using System;
using Workie.Core.BusinessLogic.Users;
using Workie.Core.Entities.Users;
using Workie.Web.Admin.Areas.Auth.Models.Register;

namespace Workie.Web.Admin.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            try
            {
                //TODO: Fix wrong values.
                var userEntity = new UserEntity
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    EmailAddress = registerViewModel.EmailAddress,
                    _companyId = 1,
                    _countryId = 1,
                    _languageId = 1,
                    _termsAndConditionId = "12345"
                };

                var userId = new UserManager().Insert(userEntity);

                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new
                    {
                        result = false,
                        title = "Failure",
                        message = "Failed to add a new user."
                    });
                }

                return PartialView("UserControls/_UserControls_VerifyEmail");
            }
            catch (Exception ex)
            {
                return null;
            }
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
