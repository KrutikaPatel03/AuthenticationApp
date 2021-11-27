using AuthenticationApp.Entity;
using AuthenticationApp.Repository.Helper;
using AuthenticationApp.Repository.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApp.Repository
{
    public class UserHelper : IUserHelper
    {
        private ProductsEntities _dbContext = null;
        public UserHelper() {
            _dbContext = new ProductsEntities();
        }
        /// <summary>
        /// This method will authenticate user based on email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<User> AuthenticateUser(string email, string password)
        {
            try
            {
                var encryptedPwd = EncryptDecrypt.Encrypt(password);
                return _dbContext.Users.Where(x => x.Email.ToLower().Trim() == email.ToLower().Trim() && x.Password == encryptedPwd).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                LogHelper.writelog("UserHelper -> AuthenticateUser -> Exception " + ex.Message + "\n" + ex.InnerException);
            }
            return null;
        }

        public Task<long> AddUser(User user)
        {
            try
            {
                user.Password = EncryptDecrypt.Encrypt(user.Password);
                _dbContext.Users.Add(user);
            }
            catch (Exception ex)
            {
                LogHelper.writelog("UserHelper -> AddUser -> Exception " + ex.Message + "\n" + ex.InnerException);
            }
            return null;
        }
    }
}
