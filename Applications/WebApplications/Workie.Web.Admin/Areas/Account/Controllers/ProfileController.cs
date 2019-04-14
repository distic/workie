using Microsoft.AspNetCore.Mvc;
using Workie.Web.Admin.Utilities;
using Microsoft.AspNetCore.Authorization;
using Workie.Web.Admin.Filters;
using System;
using Workie.Web.Admin.Areas.Account.Models.Profile;

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

        #region --- Edit Profile ---

        public IActionResult EditProfile()
        {
            try
            {
                var editProfileViewModel = new EditProfileViewModel
                {
                    FirstName = UserFirstName,
                    LastName = UserLastName,
                    EmailAddress = UserEmailAddress
                };

                //TODO: Get the data from the database and fill the editProfileViewModel variable.
                return PartialView("UserControls/_UserControls_EditProfile", editProfileViewModel);
            }
            catch (Exception ex)
            {
                // TODO: Will better handle this error, but for now this is fine.
                return Content("An error was encountered. Please handle me!");
            }
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editProfileViewModel)
        {
            try
            {
                // TODO: Will handle this procedure better, but for now this is fine as a starter.
                return Json(new
                {
                    result = true,
                    title = "Profile Update Success",
                    message = "The profile was successfully updated."
                });
            }
            catch (Exception ex)
            {
                // TODO: Will better handle this error, but for now this is fine.
                return Json(new
                {
                    result = false,
                    title = "Profile Update Failure",
                    message = "The profile update failed because of an internal problem, please try again later."
                });
            }
        }

        #endregion

        #region --- View Profile ---

        public IActionResult ViewProfile()
        {
            //TODO: This should retrieve data from the cookies or from a server.

            var viewProfileViewModel = new ViewProfileViewModel
            {
                FullName = $"{UserFirstName} {UserLastName}",
                Email = UserEmailAddress
            };

            return PartialView("UserControls/_UserControls_ViewProfile", viewProfileViewModel);
        }

        #endregion
    }
}