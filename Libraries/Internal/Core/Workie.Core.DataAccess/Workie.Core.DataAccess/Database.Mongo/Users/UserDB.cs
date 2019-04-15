using MongoDB.Bson;
using MongoDB.Driver;
using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Users;
using Workie.Core.Entities.Login.AttentionDetails;
using Workie.Core.Entities.Login;

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

        public void Update(UserEntity userEntity)
        {
            var update = Builders<UserEntity>.Update
                .Set(a => a.FirstName, userEntity.FirstName)
                .Set(a => a.LastName, userEntity.LastName)
                .Set(a => a.EmailAddress, userEntity.EmailAddress);

            var result = collection.UpdateOne(model => model._id == userEntity._id, update);
        }

        public UserEntity SelectByEmail(string email)
        {
            // Lets do this without async at the moment...
            // TODO: make sure if async is necessary
            var result = collection.Find(x => x.EmailAddress.Equals(email)).ToList();

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

        public void RaiseAttentionForResetPassword(string email)
        {
            var userEntity = SelectByEmail(email);

            #region --- Validations ---

            if (userEntity == null)
            {
                return;
            }

            if (userEntity.Attention == null)
            {
                userEntity.Attention = new Attention();
            }

            #endregion

            var resetPasswordAttention = new ResetPasswordAttention
            {
                IPAddress = "127.0.0.1",
                Location = "Beirut, Lebanon",
                Time = 45354,
                _osPlatformId = 1,
                _webBrowswerPlatformId = 1
            };

            userEntity.Attention.ResetPassword = resetPasswordAttention;

            var reset = Builders<UserEntity>.Update 
                .Set(a => a.Attention.ResetPassword, resetPasswordAttention);

            var result = collection.UpdateOne(model => model._id == userEntity._id , reset);
        }

        //TODO: change name of the function and change the parameteer to  to id
        public void RaiseAttentionForChangePassword(string id)  
        {
            var userEntity =  Select(id);                 

            #region --- Validations ---

            if (userEntity == null)
            {
                return;
            }

            if (userEntity.Attention == null)
            {
                userEntity.Attention = new Attention();
            }

            #endregion

            var changePasswordAttention =  new ChangePasswordAttention
            {
                LastChangedDate = 11.19 ,
                DayThreshold = 50 ,
            };

            userEntity.Attention.ChangePassword = changePasswordAttention;

            var change = Builders<UserEntity>.Update
                .Set(a => a.Attention.ChangePassword , changePasswordAttention);

            var result = collection.UpdateOne(model => model._id == userEntity._id , change);
        }



    }
}