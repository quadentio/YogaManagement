using Microsoft.VisualBasic;
using System.Buffers.Text;
using System.ComponentModel;
using System.Data.SqlTypes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Utilities.ExtensionMethods
{
    public static class StringExtension
    {
        //Length: Gets the number of characters in the string.
        //IndexOf: Returns the index of the first occurrence of a specified substring.
        //LastIndexOf: Returns the index of the last occurrence of a specified substring.
        //Substring: Retrieves a substring from the original string.
        //ToUpper: Converts the string to uppercase.
        //ToLower: Converts the string to lowercase.
        //Trim: Removes leading and trailing whitespace from the string.
        //Split: Splits the string into an array of substrings based on a specified delimiter.
        //Replace: Replaces all occurrences of a specified substring with another substring.
        //Concat: Concatenates multiple strings into a single string.
        //Contains: Checks if a specified substring is present in the string.
        //StartsWith: Checks if the string starts with a specified substring.
        //EndsWith: Checks if the string ends with a specified substring.
        //Join: Joins an array of strings into a single string with a specified delimiter.
        //Compare: Compares two strings and returns a value indicating their relative order.
        //Equals: Checks if the string is equal to another string.

        /// <summary>
        /// Convert hh:mm/hh:mm:ss to DateTime value (Date will be today)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string time)
        {
            try
            {
                var times = time.Split(":");
                if (!times.Any() || times.All(t => String.IsNullOrEmpty(t)) || !times.All(t => int.TryParse(t, out _)))
                {
                    // string can not split into hour and minute
                    return DateTime.MinValue;
                }

                var hh = int.Parse(times[0]);
                var mm = int.Parse(times[1]);
                var ss = 0;
                if (times.Count() == 3)
                {
                    ss = int.Parse(times[2]);
                }

                // Convert to DateTime
                var now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day, hh, mm, ss);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Check if input string is number and greater than zero
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckValidIntegerAndMoreThanZero(this string input)
        {
            int result = 0;
            int.TryParse(input, out result);
            return (result > 0);
        }

        /// <summary>
        /// Check if input string is number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckValidInteger(this string input)
        {
            return int.TryParse(input, out _);
        }

        /// <summary>
        /// Check if input is a valid phone number format (basic form)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckValidPhoneNumber(this string input)
        {
            return Regex.IsMatch(input, @"^[0-9]*$");
        }

        /// <summary>
        /// Check if input is a valid phone number in Viet Nam
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckValidVietNamPhoneNumber(this string input)
        {
            // 9 to 11 numbers
            // Start with 0
            // Second number must not be 0
            string pattern = @"^0[1-9][0-9]{7,9}$";
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// Split string into multiparts (trimmed Input)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="partLength"></param>
        /// <param name="doTrim"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitInParts2(this string input, int partLength, bool doTrim = false)
        {
            IEnumerable<string> result = new string[] { };
            var preprocessInput = doTrim ? input.Trim() : input;

            var divideTimes = preprocessInput.Length / partLength;
            var cnt = 0;
            for (int i = 0; i < divideTimes; i++)
            {
                result.Append(preprocessInput.Substring(cnt, partLength));
                cnt += partLength;
            }

            if (preprocessInput.Length % partLength > 0)
            {
                result.Append(preprocessInput.Substring(cnt));
            }

            return result;
        }

        /// <summary>
        /// Split string into multiparts (trimmed Input)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="partLength"></param>
        /// <param name="doTrim"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitInParts(this string input, int partLength, bool doTrim = false)
        {
            if (String.IsNullOrEmpty(input))
            {
                yield return string.Empty;
            }
            if (partLength <= 0)
            {
                yield return input;
            }

            var preprocessInput = doTrim ? input.Trim() : input;
            for (var i = 0; i < preprocessInput.Length; i += partLength)
            {
                yield return preprocessInput.Substring(i, Math.Min(partLength, preprocessInput.Length - i));
            }
        }

        /// <summary>
        /// Convert RGB color to Hexadicemal Color
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertColorRGBToHex(this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var parts = input.Split(",");
            if (!parts.Any() || parts.Length != 3 || !parts.All(n => int.TryParse(n, out _)))
            {
                return string.Empty;
            }

            // RGB(255,255,0)
            // RGB(Red,Green,Blue)
            // Core: #255.ToString("X2")255.ToString("X2)0.ToString("X2")
            return $"#{int.Parse(parts[0]).ToString("X2")}{int.Parse(parts[1]).ToString("X2")}{int.Parse(parts[2]).ToString("X2")}";
        }
    }
}