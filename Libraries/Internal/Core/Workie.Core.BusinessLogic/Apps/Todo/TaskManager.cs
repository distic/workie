using MongoDB.Bson;
using System.Collections.Generic;
using Workie.Core.DataAccess.Database.Mongo.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.BusinessLogic.Apps.Todo
{
    public class TaskManager
    {
        public string Insert(TaskEntity taskEntity)
        {
            return new TaskDB().Insert(taskEntity);
        }

        public void Delete(string id)
        {
            new TaskDB().Delete(id);
        }

        public TaskEntity SelectById(string id)
        {
            return new TaskDB().Select(id);
        }

        public List<TaskEntity> SelectAllByTeamId(string teamId)
        {
            return new TaskDB().SelectAllByTeamId(teamId);
        }

        public string InsertSubtask(string taskId, SubtaskEntity subTaskEntity)
        {
            return new TaskDB().InsertSubtask(taskId, subTaskEntity);
        }

        public void UpdateSubtask(string taskId, SubtaskEntity subtaskEntity)
        {
            new TaskDB().UpdateSubtask(taskId, subtaskEntity);
        }

        public void DeleteSubtask(string taskId, string subtaskId)
        {
            new TaskDB().DeleteSubtask(taskId, subtaskId);
        }
    }
}
