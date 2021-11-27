using System.Text.RegularExpressions;

namespace AuthenticationApp.Repository.Helper
{
    public static class Utility
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$");
        }
    }
}
