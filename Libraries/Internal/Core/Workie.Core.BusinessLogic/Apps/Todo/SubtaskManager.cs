using Workie.Core.DataAccess.Database.Mongo.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.BusinessLogic.Apps.Todo
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
