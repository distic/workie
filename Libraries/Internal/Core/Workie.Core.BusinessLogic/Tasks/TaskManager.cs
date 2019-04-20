using MongoDB.Bson;
using Workie.Core.DataAccess.Database.Mongo.Tasks;
using Workie.Core.Entities.SubTask;
using Workie.Core.Entities.Tasks;

namespace Workie.Core.BusinessLogic.Tasks
{
    public class TaskManager
    {
        public string Insert(TaskEntity taskEntity)
        {
            taskEntity.SubTask = new SubtaskEntity
            {
                _id = ObjectId.GenerateNewId().ToString(),

            };

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

    }
}
