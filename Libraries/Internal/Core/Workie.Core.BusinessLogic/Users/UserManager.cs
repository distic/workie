using Workie.Core.Entities.Users;
using Workie.Core.DataAccess.Database.Mongo.Users;
using System;

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