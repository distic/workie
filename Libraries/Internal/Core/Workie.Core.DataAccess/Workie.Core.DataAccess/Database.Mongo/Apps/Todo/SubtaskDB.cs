using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.DataAccess.Database.Mongo.Apps.Todo
{
    public class SubtaskDB : MongoBase, ISubtask
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "SubTask";

        private readonly IMongoCollection<SubtaskEntity> collection;

        #endregion

        #region Constructor

        public SubtaskDB()
        {
            collection = mongoDatabase.GetCollection<SubtaskEntity>(collectionName);
        }

        #endregion

        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(SubtaskEntity subTaskEntity)
        {
            #region --- Validations ---
            if (string.IsNullOrEmpty(subTaskEntity.Name))
            {
                return string.Empty;
            }
            #endregion

            // Manually set the known variables...
            subTaskEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(subTaskEntity);

            return subTaskEntity._id;
        }

        public SubtaskEntity Select(string id)
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
