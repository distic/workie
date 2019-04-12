using System;
using Microsoft.AspNetCore.Mvc;

namespace Workie.Web.Admin.Utilities
{
    public class CustomController : Controller
    {
        internal string UserId
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.UserId).Value.ToString();

            }
        }

        internal string UserFirstName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.FirstName).Value;
            }
        }

        internal string UserLastName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.LastName).Value;
            }
        }

        internal string UserEmailAddress
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.EmailAddress).Value;
            }
        }

        internal bool IsFirstLogin
        {
            get
            {
                return Convert.ToBoolean(HttpContext.User.FindFirst(CustomClaimTypes.IsFirstLogin).Value);
            }
        }
    }
}
