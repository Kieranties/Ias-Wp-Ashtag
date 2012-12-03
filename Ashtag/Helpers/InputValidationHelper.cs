/*
 * Email validation example from: http://msdn.microsoft.com/en-us/library/01escwtf%28v=vs.95%29.aspx
 */

using System.Text.RegularExpressions;

namespace Ashtag.Helpers
{
    public class InputValidationHelper
    {
        public static bool IsValidEmailAddress(string email)
        {
            return Regex.IsMatch(email,
                    @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"); 
        }
    }
}
