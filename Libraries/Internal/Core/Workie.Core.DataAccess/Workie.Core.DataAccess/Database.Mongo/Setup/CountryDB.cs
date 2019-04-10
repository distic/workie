using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Setup;

namespace Workie.Core.DataAccess.Database.Mongo.Setup
{
    public class CountryDB : MongoBase, ICountryDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "Country";

        private readonly IMongoCollection<CountryEntity> collection;

        #endregion

        #region Constructor

        public CountryDB()
        {
            collection = mongoDatabase.GetCollection<CountryEntity>(collectionName);
        }

        #endregion

        public void Delete(int id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }

        public int Insert(CountryEntity countryEntity)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(countryEntity.Name))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(countryEntity.Abbreviation))
            {
                return 0;
            }

            if (countryEntity._defaultLanguageId == 0)
            {
                return 0;
            }

            #endregion

            // Manually set the known variables...
            countryEntity._id = ObjectId.GenerateNewId().Increment;

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(countryEntity);

            return countryEntity._id;
        }

        public CountryEntity Select(int id)
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
