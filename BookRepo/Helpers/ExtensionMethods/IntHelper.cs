using System;

namespace BookRepo.Helpers.ExtensionMethods
{
    public static class IntHelper
    {
        public static string ToHourMinuteDisplay(this int value)
        {
            if (value <= 0) return "";

            if (value <= 60)
                return string.Format("{0}m", value);

            TimeSpan span = TimeSpan.FromMinutes(value);

            return string.Format("{1}h {0:mm}m", span, Convert.ToInt32(span.TotalHours));
        }
    }
}