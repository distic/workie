using System;
using Microsoft.AspNetCore.Mvc;

namespace Workie.Web.Admin.Utilities
{
    public class CustomController : Controller
    {
        public Guid UserId
        {
            get
            {
                Guid.TryParse(HttpContext.User.FindFirst(CustomClaimTypes.UserId).Value, out Guid customerId);

                return customerId;
            }
        }

        public string UserFirstName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.FirstName).Value;
            }
        }

        public string UserLastName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.LastName).Value;
            }
        }

        public string UserEmailAddress
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.EmailAddress).Value;
            }
        }
    }
}
