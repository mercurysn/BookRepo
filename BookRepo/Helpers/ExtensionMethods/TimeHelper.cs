﻿using System;
using System.Linq;

namespace BookRepo.Helpers.ExtensionMethods
{
    public static class TimeHelper
    {
        public static string ConvertTimeToMinutes(this string value)
        {
            var splitValue = value.Split(':');

            if (splitValue.Count() != 3)
                return "0";

            int hoursInMinutes = ExtractHours(splitValue);;
            int minutes = ExtractMinutes(splitValue);

            return (hoursInMinutes + minutes).ToString();
        }

        private static int ExtractMinutes(string[] splitValue)
        {
            int result;
            if (int.TryParse(splitValue[1], out result))
            {
                return result;
            }

            throw new Exception("Minutes Not Integer");
        }

        private static int ExtractHours(string[] splitValue)
        {
            int result;
            if (int.TryParse(splitValue[0], out result))
            {
                return result*60;
            }

            throw new Exception("Hours Not Integer");
        }
    }
}