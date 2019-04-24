using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces.Apps.Todo;
using Workie.Core.Entities.Apps.Todo;

namespace Workie.Core.DataAccess.Database.Mongo.Apps.Todo
{
    public class TaskDB : MongoBase, ITaskDB, ISubtask
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
            #region Validations

            if (string.IsNullOrEmpty(taskEntity.Title))
            {
                return string.Empty;
            }

            #endregion

            taskEntity.SubtaskList = new List<SubtaskEntity>();

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

        public List<TaskEntity> SelectAllByTeamId(string teamId)
        {
            var result = collection.Find(x => x._teamId.Equals(teamId)).ToList();

            return result;
        }

        #region --- Subtasks ---

        public void DeleteSubtask(string taskId, string subtaskId)
        {
            var filter = Builders<TaskEntity>.Filter.Where(x => x._id == taskId && x.SubtaskList.Any(i => i._id == subtaskId));
            collection.DeleteOne(filter);
        }

        public string InsertSubtask(string taskId, SubtaskEntity subtaskEntity)
        {
            #region Validations

            if (subtaskEntity == null)
            {
                return string.Empty;
            }

            #endregion

            subtaskEntity._id = ObjectId.GenerateNewId().ToString();

            var filter = Builders<TaskEntity>.Filter.Eq(e => e._id, taskId);

            var update = Builders<TaskEntity>.Update
                    .Push<SubtaskEntity>(e => e.SubtaskList, subtaskEntity);

            collection.FindOneAndUpdateAsync(filter, update);

            return subtaskEntity._id;
        }

        public void UpdateSubtask(string taskId, SubtaskEntity subtaskEntity)
        {
            #region Validations

            if (subtaskEntity == null)
            {
                return;
            }

            #endregion

            var filter = Builders<TaskEntity>.Filter.Where(x => x._id == taskId && x.SubtaskList.Any(i => i._id == subtaskEntity._id));
            var update = Builders<TaskEntity>.Update.Set(x => x.SubtaskList[-1], subtaskEntity);
            var result = collection.UpdateOne(filter, update);
        }

        #endregion
    }
}
