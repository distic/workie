using Workie.Core.DataAccess.Database.Mongo.SubTask;
using Workie.Core.Entities.SubTask;

namespace Workie.Core.BusinessLogic.SubTask
{
    public class SubtaskManager
    {
        public string Insert(SubtaskEntity subTaskEntity)
        {

            return new SubtaskDB().Insert(subTaskEntity);
        }

        public void Delete(string id)
        {
            new SubtaskDB().Delete(id);
        }

        public SubtaskEntity SelectById(string id)
        {
            return new SubtaskDB().Select(id);
        }

    }
}
