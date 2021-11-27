using AuthenticationApp.Repository.Helper;
using AuthenticationApp.Repository.Models;
using AuthenticationApp.Web.Helper;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace AuthenticationApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string Email,string Password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email))
                {
                    ViewBag.Error = "Please enter a value.";
                }
                else
                {
                    //For Security Concern We can Implement Server Side validation.
                    //if (Utility.IsValidEmail(Email))
                    //{
                    var httpclient = APIHelper.GetHttpClient(string.Empty);
                    try
                    {
                        APIResponse response = new APIResponse();
                        StringContent content = new StringContent(JsonConvert.SerializeObject(new { username = Email, password = Password }), Encoding.UTF8, "application/json");
                        HttpResponseMessage resMsg = httpclient.PostAsync(AppStatic.AuthenticateUser, content).Result;
                        if (resMsg.IsSuccessStatusCode)
                        {
                            string resStr = resMsg.Content.ReadAsStringAsync().Result;
                            response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(resStr);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    return RedirectToAction("Dashboard", "Home");
                    //}
                    //ViewBag.Error = "Please enter a valid Email.";
                    //ViewBag.Email = Email + " is not a valid one! ";
                }   
            }
            catch (Exception ex)
            {
                LogHelper.writelog("LogIn" + ex.Message);
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
