using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string? value)
            => string.IsNullOrWhiteSpace(value);

        public static string? NullIfEmpty(this string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value;

        public static string ToIsoUtcString(this DateTime dateTime)
            => dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

        public static DateTime StartOfDayUtc(this DateTime dateTime)
            => DateTime.SpecifyKind(dateTime.Date, DateTimeKind.Utc);

        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
            => source is null || !source.Any();
    }
}
