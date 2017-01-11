using System;
using System.Configuration;
using System.Web.Mvc;
using MyBlog.Core.Objects;

namespace MyBlog
{
    public static class Extensions
    {
        public static string ToConfigLocalTime(this DateTime utcDT)
        {
            var istTZ = TimeZoneInfo.FindSystemTimeZoneById(ConfigurationManager.AppSettings["Timezone"]);
            return string.Format("{0} ({1})", TimeZoneInfo.ConvertTimeFromUtc(utcDT, istTZ).ToShortDateString(), ConfigurationManager.AppSettings["TimezoneAbbr"]);
        }
    }
}