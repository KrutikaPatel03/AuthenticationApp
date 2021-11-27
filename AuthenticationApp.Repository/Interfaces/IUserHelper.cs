using AuthenticationApp.Entity;
using System.Threading.Tasks;

namespace AuthenticationApp.Repository.Interfaces
{
    public interface IUserHelper
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<User> AuthenticateUser(string username, string password);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<long> AddUser(User user);

    }
}
