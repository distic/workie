using Workie.Core.Entities.Users;

namespace Workie.Core.DataAccess.Interfaces
{
    internal interface IUserDB
    {
        /// <summary>
        /// Inserts a user.
        /// </summary>
        /// <param name="userEntity">UserEntity object. This must be filled.</param>
        /// <returns></returns>
        string Insert(UserEntity userEntity);

        /// <summary>
        /// Gets user information by Email and Password.
        /// </summary>
        /// <param name="email">Email address of the authenticating user.</param>
        /// <param name="password">Password of the authenticating user.</param>
        /// <returns></returns>
        UserEntity SelectByEmailAndPassword(string email, string password);
    }
}