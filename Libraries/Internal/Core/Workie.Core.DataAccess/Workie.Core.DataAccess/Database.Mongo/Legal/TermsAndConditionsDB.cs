using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Legal;

namespace Workie.Core.DataAccess.Database.Mongo.Legal
{
    public class TermsAndConditionsDB : MongoBase, ITermsAndConditionsDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "TermsAndConditions";

        private readonly IMongoCollection<TermsAndConditionsEntity> collection;

        #endregion

        #region Constructor

        public TermsAndConditionsDB()
        {
            collection = mongoDatabase.GetCollection<TermsAndConditionsEntity>(collectionName);
        }

        #endregion

        public string Insert(TermsAndConditionsEntity termsAndConditions)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(termsAndConditions.Description))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(termsAndConditions.Name))
            {
                return string.Empty;
            }

            if (termsAndConditions.Version < 1)
            {
                return string.Empty;
            }

            if (termsAndConditions._languageId < 1)
            {
                return string.Empty;
            }

            #endregion

            // Manually set the known variables...
            termsAndConditions._id = ObjectId.GenerateNewId().ToString();

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(termsAndConditions);

            return termsAndConditions._id;
        }

        public TermsAndConditionsEntity Select(string id)
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

        public void Delete(string id)
        {
            collection.DeleteOne(x => x._id.Equals(id));
        }
    }
}