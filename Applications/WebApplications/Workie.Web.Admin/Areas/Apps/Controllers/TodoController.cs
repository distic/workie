using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Workie.Core.BusinessLogic.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;
using Workie.Web.Admin.Areas.Apps.Models.Todo.QuickbarControls;
using Workie.Web.Admin.Filters;

namespace Workie.Web.Admin.Areas.Apps.Controllers
{
    [Area("Apps")]
    [Authorize]
    [AuthorizeCurrentUser]
    public class TodoController : Controller
    {
        const string teamId = "5cbed3cabadde6192c8f406d";

        [HttpPost]
        public IActionResult RefreshTodoTable()
        {
            try
            {
                var taskList = new TaskManager().SelectAllByTeamId(teamId);

                var quickList = new List<QuickbarControlsTodoViewViewModel>();

                foreach (var task in taskList)
                {
                    quickList.Add(new QuickbarControlsTodoViewViewModel
                    {
                        Id = task._id,
                        Title = task.Title
                    });
                }

                return PartialView("QuickbarControls/DataTable/_DataTable_TableFormat", quickList);
            }
            catch
            {
                return Json(new
                {
                    result = false
                });
            }
        }

        public IActionResult DeleteTodoById(string id)
        {
            try
            {
                new TaskManager().Delete(id);

                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }

        [HttpPost]
        public IActionResult AddOrModifyTodoView(QuickbarControlsTodoViewViewModel quickbarControlsTodoViewViewModel)
        {
            try
            {
                var taskEntity = new TaskEntity
                {
                    Title = quickbarControlsTodoViewViewModel.Title,
                    _teamId = teamId
                };

                taskEntity._id = new TaskManager().Insert(taskEntity);

                if (string.IsNullOrEmpty(taskEntity._id))
                {
                    return Json(new { result = false });
                }

                return Json(new { id = taskEntity._id, result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }
    }
}