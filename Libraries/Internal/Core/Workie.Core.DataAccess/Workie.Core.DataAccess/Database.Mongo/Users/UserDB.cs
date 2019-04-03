using Workie.Core.DataAccess.Interfaces;
using Workie.Core.Entities.Users;

namespace Workie.Core.DataAccess.Database.Mongo.Users
{
    public class UserDB : MongoBase, IUserDB
    {
        public string Insert(UserEntity userEntity)
        {
            return string.Empty;
        }

        public UserEntity SelectByEmailAndPassword(string email, string password)
        {
            return null;
        }
    }
}