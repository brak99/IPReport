using System;

namespace IPReport.Util
{
	public class DateUtil
	{
		static public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, 1);
		}

		static public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
		{
			DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1, 23, 59, 59);
			return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
		}

        public static string FormatDate(DateTime dateTime)
        {
            string datePart = dateTime.ToString("yyyy-MM-dd");
            string timePart = dateTime.ToString("HH:mm:ss");

            return datePart + "T" + timePart;
        }

        public static DateTime ParseDate(string dateTime)
        {
            DateTime parsedDate = DateTime.Parse(dateTime);
            return parsedDate;
        }

        static public DateTime EndOfDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        static public DateTime StartOfDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        static public DateTime StartOfWeek(DateTime dateTime)
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
            DayOfWeek today = DateTime.Now.DayOfWeek;
            DateTime startOfWeek = dateTime.AddDays(-(today - fdow));

            return startOfWeek;
        }
	}
}
