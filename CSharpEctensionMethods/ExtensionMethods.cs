using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

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
            return string.IsNullOrEmpty(val);
        }

        public static bool IsMaxLength(this string val, int maxCharLength)
        {
            return val != null && val.Length <= maxCharLength;
        }

        public static bool IsMinLength(this string val, int minCharLength)
        {
            return val != null && val.Length >= minCharLength;
        }

        public static int GetWordCount(this string input)
        {
            return input.Trim().Length == 0 ? 0 : Regex.Split(input, @"\W+").Length;
        }

        public static int ToInt32(this string value)
        {
            int.TryParse(value, out var number);
            return number;
        }

        public static bool IsInteger(this string s)
        {
            return !s.IsMatch("[^0-9-]") && s.IsMatch("^-[0-9]+$|^[0-9]+$");
        }

        public static bool IsMatch(this string s, string RegEx)
        {
            return new Regex(RegEx).IsMatch(s);
        }

        public static bool IsEmailAddress(this string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email");
            string pattern =
                "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.Match(email, pattern).Success;
        }

        public static bool IsValidUrl(this string url)
        {
            string strRegex = "^(https?://)"
                + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?"
                + @"(([0-9]{1,3}\.){3}[0-9]{1,3}"
                + "|"
                + @"([0-9a-z_!~*'()-]+\.)*"
                + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]"
                + @"(\.[a-z]{2,6})?)"
                + "(:[0-9]{1,5})?"
                + "((/?)|"
                + "((/?)|"
                + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return new Regex(strRegex).IsMatch(url);
        }

        public static string SwapCase(this string input)
        {
            return new string(input.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
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

        public static bool Between(this DateTime dt, DateTime rangeBeg, DateTime rangeEnd)
        {
            return dt.Ticks >= rangeBeg.Ticks && dt.Ticks <= rangeEnd.Ticks;
        }

        public static bool IsMatchRegex(this string value, string pattern)
        {
            var regex = new Regex(pattern);
            return (regex.IsMatch(value));
        }

        public static bool IsNullOrEmpty(this IList list)
        {
            return list == null || list.Count == 0;
        }

        public static string IfNullElse(this string input, string nullAlternateValue)
        {
            return (!string.IsNullOrWhiteSpace(input)) ? input : nullAlternateValue;
        }

        public static T CloneObject<T>(this T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public static bool Toggle(this bool value)
        {
            return !value;
        }
    }
}