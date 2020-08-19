using System.Text.RegularExpressions;

namespace MusterAg.Monitoring.Client.Helper
{
    public static class RegexHelper
    {
        public static bool MatchUrl(string url)
        {
            string urlPattern = @"(\s*\[+?\s*(\!?)\s*([a-z]*)\s*\|?\s*([a-z0-9\.\-_]*)\s*\]+?)?\s*([^\s]+)\s*";
            Regex rgUrl = new Regex(urlPattern);
            return rgUrl.IsMatch(url);
        }
        
        public static bool MatchEmail(string email)
        {
            // https://emailregex.com/
            string patternEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex rgEmail = new Regex(patternEmail);
            return rgEmail.IsMatch(email);
        }
        
        public static bool MatchCustomerNr(string customerNr)
        {
            string customerNrPattern = @"^CU\d{5}$";
            Regex rgCustomerNr = new Regex(customerNrPattern);
            return rgCustomerNr.IsMatch(customerNr);
        }
        
        public static bool MatchPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{1,8}$";
            Regex rgPassword = new Regex(passwordPattern);
            return rgPassword.IsMatch(password);
        }
        
    }
}