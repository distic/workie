using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Tasks;

namespace Workie.Core.DataAccess.Database.Mongo.Tasks
{
    public class TaskDB : MongoBase, ITaskDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Task";

        private readonly IMongoCollection<TaskEntity> collection;

        #endregion

        #region Constructor

        public TaskDB()
        {
            collection = mongoDatabase.GetCollection<TaskEntity>(collectionName);
        }

        #endregion

        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(TaskEntity taskEntity)
        {
            #region --- Validations ---
            if (string.IsNullOrEmpty(taskEntity.Title))
            {
                return string.Empty;
            }
            #endregion

            // Manually set the known variables...
            taskEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(taskEntity);

            return taskEntity._id;
        }

        public TaskEntity Select(string id)
        {
            // Lets do this without async at the moment...
            // TODO: make sure if async is necessary
            var result = collection.Find(x => x._id.Equals(id)).ToList();

            #region --- Validations ---

            if (result == null)
            {
                return null;
            }

            if (result.Count < 1)
            {
                return null;
            }

            #endregion

            return result[0];
        }

    }
}
