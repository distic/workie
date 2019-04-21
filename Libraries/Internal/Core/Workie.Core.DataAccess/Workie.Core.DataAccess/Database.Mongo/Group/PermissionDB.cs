using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Database.Mongo.Group
{
    public class PermissionDB : MongoBase, IPermissionDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Permission";

        private readonly IMongoCollection<PermissionEntity> collection;

        #endregion

        #region Constructor

        public PermissionDB()
        {
            collection = mongoDatabase.GetCollection<PermissionEntity>(collectionName);
        }

        #endregion
        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(PermissionEntity permissionEntity)
        {
            #region --- Validations ---
            if (string.IsNullOrEmpty(permissionEntity.Name))
            {
                return string.Empty;
            }
            #endregion

            // Manually set the known variables...
            permissionEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(permissionEntity);

            return permissionEntity._id;
        }

        public PermissionEntity Select(string id)
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
