using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Group;

namespace Workie.Core.DataAccess.Database.Mongo.Group
{
    public class RoleDB : MongoBase, IRoleDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Role";

        private readonly IMongoCollection<RoleEntity> collection;

        #endregion

        #region Constructor

        public RoleDB()
        {
            collection = mongoDatabase.GetCollection<RoleEntity>(collectionName);
        }

        #endregion
        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public string Insert(RoleEntity roleEntity)
        {
            #region --- Validations ---
            if (string.IsNullOrEmpty(roleEntity.Name))
            {
                return string.Empty;
            }
            #endregion

            // Manually set the known variables...
            roleEntity._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(roleEntity);

            return roleEntity._id;
        }

        public RoleEntity Select(string id)
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
