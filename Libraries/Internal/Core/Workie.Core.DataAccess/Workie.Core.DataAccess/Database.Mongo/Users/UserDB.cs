using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Users;

namespace Workie.Core.DataAccess.Database.Mongo.Users
{
    public class UserDB : MongoBase, IUserDB
    {
        #region Properties

        //
        // Collection Name
        //
        private const string collectionName = "User";

        private readonly IMongoCollection<UserEntity> collection;

        #endregion

        #region Constructor

        public UserDB()
        {
            collection = mongoDatabase.GetCollection<UserEntity>(collectionName);
        }

        #endregion

        public string Insert(UserEntity userEntity)
        {
            #region --- Validations ---

            if (string.IsNullOrEmpty(userEntity.FirstName))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(userEntity.LastName))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(userEntity.EmailAddress))
            {
                return string.Empty;
            }

            if (userEntity._companyId == 0)
            {
                return string.Empty;
            }

            if (userEntity._countryId == 0)
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(userEntity._termsAndConditionId))
            {
                return string.Empty;
            }

            #endregion

            // Manually set the known variables...
            userEntity._id = ObjectId.GenerateNewId().ToString();
            userEntity.Password = string.Empty;

            // Lets keep things simple and avoid await for now..
            collection.InsertOne(userEntity);

            return userEntity._id;
        }

        public UserEntity Select(string id)
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

        public UserEntity SelectByEmailAndPassword(string email, string password)
        {
            // Lets do this without async at the moment...
            // TODO: make sure if async is necessary
            var result = collection.Find(x => x.EmailAddress.Equals(email) && x.Password.Equals(password)).ToList();

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