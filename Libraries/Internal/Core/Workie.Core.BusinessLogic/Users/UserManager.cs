using Workie.Core.DataAccess.Database.Mongo.Users;
using Workie.Core.Entities.Users;

namespace Workie.Core.BusinessLogic.Users
{
    public class UserManager
    {
        public string Insert(UserEntity userEntity)
        {
            userEntity.Attention = new Entities.Login.Attention
            {
                // Since we're inserting for the first time, we will default the IsFirstLogin value to true.
                IsFirstLogin = true,
                VerifyEmail = true
            };

            return new UserDB().Insert(userEntity);
        }

        public UserEntity SelectByEmailAndPassword(string email, string password)
        {
            return new UserDB().SelectByEmailAndPassword(email, password);
        }

        public UserEntity Select(string id)
        {
            return new UserDB().Select(id);
        }

        public void Delete(string id)
        {
            new UserDB().Delete(id);
        }
    }
}