using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static string ToDateOnlyString(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public static string toFullDateOnlyString(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }

        public static string ToJapanDateString(this DateTime date)
        {
            return date.ToString("yyyy年MM月dd日");
        }

        public static string ToVietNamDateString(this DateTime date)
        {
            return date.ToString("Ngày dd Tháng MM Năm yyyy");
        }

        public static string ToDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ToFullDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToSlashDateString(this DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }

        public static string ToFullSlashDateString(this DateTime date)
        {
            return date.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string ToYearMonthString(this DateTime date)
        {
            return date.ToString("yyyy-MM");
        }

        public static string ToSlashYearMonthString(this DateTime date)
        {
            return date.ToString("yyyy/MM");
        }

        public static string ToHourMinuteSecondString(this DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        public static string ToHourMinuteString(this DateTime date)
        {
            return date.ToString("HH:mm");
        }

        public static string ToMinuteSecondString(this DateTime date)
        {
            return date.ToString("mm:ss");
        }

        public static string ToDayOfWeekEnglishString(this DateTime date)
        {
            String[] _days = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            return _days[(int)date.DayOfWeek];
        }
    }
}
