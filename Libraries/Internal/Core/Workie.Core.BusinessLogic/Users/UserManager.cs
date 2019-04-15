using Workie.Core.DataAccess.Database.Mongo.Users;
using Workie.Core.Entities.Users;
using Workie.Core.Entities.Login;

namespace Workie.Core.BusinessLogic.Users
{
    public class UserManager
    {
        public string Insert(UserEntity userEntity)
        {
            userEntity.Attention = new Attention
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

        public void Update(UserEntity userEntity)
        {
            new UserDB().Update(userEntity);
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