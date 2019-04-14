using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Environment;

namespace Workie.Core.DataAccess.Database.Mongo.Environment
{
    public class OSPlatformDB : MongoBase, IOSPlatformDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "OSPlatform";

        private readonly IMongoCollection<OSPlatformEntity> collection;

        #endregion

        #region Constructor

        public OSPlatformDB()
        {
            collection = mongoDatabase.GetCollection<OSPlatformEntity>(collectionName);
        }

        #endregion

        public int Insert(OSPlatformEntity osPlatform)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(osPlatform.Name))
            {
                return 0;
            }

            #endregion

            // Manually set the known variables...
            osPlatform._id = ObjectId.GenerateNewId().Increment;

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(osPlatform);

            return osPlatform._id;
        }

        public OSPlatformEntity Select(int id)
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

        public void Delete(int id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }
    }
}
