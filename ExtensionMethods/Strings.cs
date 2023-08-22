using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ModernWestern
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes both diacritic marks and white spaces from a given string.
        /// </summary>
        public static string RemoveAccentsAndWhiteSpaces(this string str)
        {
            return str.RemoveAccents().RemoveWhiteSpaces();
        }

        /// <summary>
        /// Removes all white spaces, including spaces, tabs, and line breaks, from a given string.
        /// </summary>
        public static string RemoveWhiteSpaces(this string str)
        {
            return str.ToCharArray().Where(c => !char.IsWhiteSpace(c)).Select(c => c.ToString()).Aggregate((a, b) => a + b);
        }

        /// <summary>
        /// Removes diacritic marks from a string.
        /// </summary>
        public static string RemoveAccents(this string str)
        {
            var sb = new StringBuilder();

            var charArray = str.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (var c in charArray)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Transforms a given string in camel case to a human-readable format by adding spaces before each uppercase letter that is preceded by a lowercase letter or a non-letter character
        /// </summary>
        /// /// <example>
        /// <code>
        /// "camelCaseString".DeconstructCamelCase(); // deconstructed will be "camel Case String"
        /// </code>
        /// </example>
        public static string DeconstructCamelCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        /// <summary>
        /// Checks whether the given string contains any of the specified keywords, ignoring case.
        /// </summary>
        /// <example>
        /// <code>
        /// "The quick brown fox jumps over the lazy dog.".ContainsAny("quick", "lazy"); // Returns true
        /// "The quick brown fox jumps over the lazy dog.".ContainsAny("quickly", "lazy"); // Returns true (partial match)
        /// "The quick brown fox jumps over the lazy dog.".ContainsAny("cat", "roll"); // Returns false
        /// </code>
        /// </example>
        public static bool ContainsAny(this string str, params string[] keywords)
        {
            return keywords.Any(keyword => str.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        /// <summary>
        /// Checks whether the given string contains any of the specified keywords, ignoring case.
        /// </summary>
        public static bool Contains(this string str, params string[] keywords)
        {
            const char space = ' ';

            return keywords.Any(keyword => str.Split(space).Contains(keyword, StringComparer.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Capitalizes the first letter of a given string.
        /// </summary>
        public static string ToFirstUpper(this string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}