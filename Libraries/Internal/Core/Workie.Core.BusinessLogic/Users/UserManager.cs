using Workie.Core.Entities.Users;
using Workie.Core.DataAccess.Database.Mongo.Users;

namespace Workie.Core.BusinessLogic.Users
{
    public class UserManager
    {
        public string Insert(UserEntity userEntity)
        {
            return new UserDB().Insert(userEntity);
        }

        public UserEntity SelectByEmailAndPassword(string email, string password)
        {
            return new UserDB().SelectByEmailAndPassword(email, password);
        }
    }
}