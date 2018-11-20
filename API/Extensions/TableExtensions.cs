using API.Context;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace API.Extensions
{
    public static class TableExtensions
    {
        public static Dictionary<string, string> ToFormatedDictionaty(this Table table)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            var dictionary = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], !row[1].StartsWith("$") ? row[1] : context.GlobalProps[row[1]]);
            }

            return dictionary;
        }
    }
}
