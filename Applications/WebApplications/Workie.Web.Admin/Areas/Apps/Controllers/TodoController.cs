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
        /// <summary>
        /// Temporary TeamID. Consider adding Team manipulation feature in the future.
        /// </summary>
        const string teamId = "5cbed3cabadde6192c8f406d";

        #region --- Tasks ---

        [HttpPost]
        public IActionResult RefreshTodoTable()
        {
            try
            {
                var taskList = new TaskManager().SelectAllByTeamId(teamId);

                var quickList = new List<QuickbarControlsTodoViewModel>();

                foreach (var task in taskList)
                {
                    quickList.Add(new QuickbarControlsTodoViewModel
                    {
                        Id = task._id,
                        Title = task.Title,
                        SubtaskList = task.SubtaskList
                    });
                }

                return Json(new
                {
                    result = true,
                    list = quickList
                });

               // return PartialView("QuickbarControls/DataTable/_DataTable_TableFormat", quickList);
            }
            catch (Exception ex)
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
        public IActionResult AddEditTask(QuickbarControlsTodoViewModel quickbarControlsTodoViewModel)
        {
            try
            {
                var taskEntity = new TaskEntity
                {
                    Title = quickbarControlsTodoViewModel.Title,
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

        #endregion

        #region --- Subtasks ---

        public IActionResult AddEditSubtask(string taskId, string subtaskId, string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(taskId))
                {
                    return Json(new { result = false });
                }

                if (string.IsNullOrEmpty(name))
                {
                    return Json(new { result = false });
                }

                var subtaskEntity = new SubtaskEntity
                {
                    _id = subtaskId,
                    Description = name,
                    Owner_userIdsList = null
                };

                // Update...
                if (!string.IsNullOrEmpty(subtaskId))
                {
                    new TaskManager().UpdateSubtask(taskId, subtaskEntity);

                    return Json(new { result = true });
                }

                // Add...
                subtaskEntity._id = new TaskManager().InsertSubtask(taskId, subtaskEntity);

                if (string.IsNullOrEmpty(subtaskEntity._id))
                {
                    return Json(new { result = false });
                }

                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }

        public IActionResult DeleteSubtask(string taskId, string subtaskId)
        {
            try
            {
                new TaskManager().DeleteSubtask(taskId, subtaskId);

                return Json(new { result = true });
            }
            catch (Exception)
            {
                return Json(new { result = false });
            }
        }

        #endregion
    }
}