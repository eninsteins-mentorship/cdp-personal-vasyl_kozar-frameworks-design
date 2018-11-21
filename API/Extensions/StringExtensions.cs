using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Extensions
{
    public static class StringExtensions
    {
        private static Dictionary<string, Func<string, string>> _dict = new Dictionary<string, Func<string, string>>
        {
            {@"_TODAY_", (d) => DateTime.UtcNow.ToString("yyyy-MM-dd") },
            {@"_RANDOM_", (d) => DateTime.UtcNow.ToString("ssfff") },
            {@"_(.*)_", (d) => d.ReplaceMacrosToCamelCase() }
        };

        public static string ReplaceMacrosToCamelCase(this string value)
        {
            var groupKey = "key";
            if (value == null)
                throw new ArgumentException("value should not be null");
            return Regex.Match(value, $@"_(?<{groupKey}>.*?)_").Groups[groupKey].Value.CapitalizeWord();
        }

        public static string CapitalizeWord(this string value)
        {
            return string.Concat(value.Select((c, i) => i == 0 ? char.ToUpper(c) : c));
        }

        public static string WithMacroses(this string value)
        {
            foreach (var macros in _dict)
            {
                value = Regex.Replace(value, macros.Key, macros.Value(value), RegexOptions.IgnoreCase);
            }
            return value;
        }
    }
}
