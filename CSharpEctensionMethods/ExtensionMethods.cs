using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpEctensionMethods
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this string val)
        {
            return val == null;
        }

        public static string GetEmptyStringIfNull(this string val)
        {
            return (val != null ? val.Trim() : "");
        }

        public static bool IsNullOrEmpty(this string val)
        {
            return String.IsNullOrEmpty(val);
        }

        public static bool IsMaxLength(this string val, int maxCharLength)
        {
            return val != null && val.Length <= maxCharLength;
        }

        public static bool IsMinLength(this string val, int minCharLength)
        {
            return val != null && val.Length >= minCharLength;
        }

        public static int ToInt32(this string value)
        {
            int number;
            Int32.TryParse(value, out number);
            return number;
        }

        public static bool IsEmailAddress(this string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("email");
            }
            string pattern =
                "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.Match(email, pattern).Success;
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value");
            }
            switch (value.ToLower().Trim())
            {
                case "false":
                    return false;
                case "f":
                    return false;
                case "true":
                    return true;
                case "t":
                    return true;
                case "yes":
                    return true;
                case "no":
                    return false;
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Invalid boolean");
            }
        }
    }
}
