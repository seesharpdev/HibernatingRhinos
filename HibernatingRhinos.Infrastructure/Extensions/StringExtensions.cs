using System;
using System.Globalization;

namespace HibernatingRhinos.Infrastructure.Extensions
{
    public static class String
    {
        public static string ToInvariantFormat(this string text)
        {
            return text.ToString(CultureInfo.InvariantCulture);
        }
    }
}
