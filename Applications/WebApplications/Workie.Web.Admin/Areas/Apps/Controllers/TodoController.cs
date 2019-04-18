using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Workie.Web.Admin.Areas.Apps.Models.Todo.QuickbarControls;
using Workie.Web.Admin.Filters;

namespace Workie.Web.Admin.Areas.Apps.Controllers
{
    [Area("Apps")]
    [Authorize]
    [AuthorizeCurrentUser]
    public class TodoController : Controller
    {
        [HttpPost]
        public IActionResult AddOrModifyTodoView(QuickbarControlsTodoViewViewModel quickbarControlsTodoViewViewModel)
        {
            try
            {
                return Json(new
                {
                    result = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = false
                });
            }
        }

        public IActionResult DeleteTodo(string id)
        {
            try
            {
                return Json(new
                {
                    result = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    result = false
                });
            }
        }
    }
}