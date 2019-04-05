using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Workie.Web.Admin.Utilities;

namespace Workie.Web.Admin.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AuthorizeCurrentUserAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Used for filtering current users of the system.
        /// </summary>
        /// <param name="filterContext">Passed by default, no action needed.</param>
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var isFirstLoginClaim = filterContext.HttpContext.User.FindFirst(CustomClaimTypes.IsFirstLogin);

            if (isFirstLoginClaim == null)
            {
                return;
            }

            var isFirstLogin = Convert.ToBoolean(isFirstLoginClaim.Value);

            if (isFirstLogin)
            {
                filterContext.Result = new RedirectToActionResult("", "home", new { area = "setup" });
            }
        }
    }
}