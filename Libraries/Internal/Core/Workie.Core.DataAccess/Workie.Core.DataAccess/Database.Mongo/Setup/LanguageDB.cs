using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Database.Mongo.Setup
{
    public class LanguageDB : MongoBase, ILanguageDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Language";

        private readonly IMongoCollection<LanguageEntity> collection;

        #endregion

        #region Constructor

        public LanguageDB()
        {
            collection = mongoDatabase.GetCollection<LanguageEntity>(collectionName);
        }

        #endregion

        public void Delete(int id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public int Insert(LanguageEntity languageEntity)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(languageEntity.Name))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(languageEntity.Reference))
            {
                return 0;
            }

            #endregion

            // Manually set the known variables...
            languageEntity._id = ObjectId.GenerateNewId().Increment;

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(languageEntity);

            return languageEntity._id;
        }

        public LanguageEntity Select(int id)
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
