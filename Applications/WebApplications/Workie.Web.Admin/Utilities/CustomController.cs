using System;
using Microsoft.AspNetCore.Mvc;

namespace Workie.Web.Admin.Utilities
{
    public class CustomController : Controller
    {
        public Guid CustomerId
        {
            get
            {
                Guid.TryParse(HttpContext.User.FindFirst(CustomClaimTypes.CustomerId).Value, out Guid customerId);

                return customerId;
            }
        }

        public string CustomerFirstName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.FirstName).Value;
            }
        }

        public string CustomerLastName
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.LastName).Value;
            }
        }

        public string CustomerPrimaryEmailAddress
        {
            get
            {
                return HttpContext.User.FindFirst(CustomClaimTypes.PrimaryEmailAddress).Value;
            }
        }
    }
}
