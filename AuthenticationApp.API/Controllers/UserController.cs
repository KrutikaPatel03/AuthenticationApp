using AuthenticationApp.Entity;
using AuthenticationApp.Repository.Helper;
using AuthenticationApp.Repository.Interfaces;
using AuthenticationApp.Repository.Models;
using System;
using System.Web.Http;

namespace AuthenticationApp.API.Controllers
{
    public class UserController : ApiController
    {
        private IUserHelper _userHelper = null;
        public UserController(IUserHelper userHelper) {
            _userHelper = userHelper;
        }
        [HttpPost]
        public User Login(string username,string password)
        {
            APIResponse res = new APIResponse();
            User user = new User();
            try
            {
                res.Data = _userHelper.AuthenticateUser(username,password);
                res.ResultCode = AppStatic.SUCCESS;
            }
            catch (Exception ex)
            {
                LogHelper.writelog("Login Exception : " + ex.Message);
                LogHelper.writelog("Login Inner Exception : " + ex.InnerException);
                res.ResultCode = AppStatic.ERROR;
                res.ResultDescription = ex.Message;
            }
            return user;
        }
    }
}
