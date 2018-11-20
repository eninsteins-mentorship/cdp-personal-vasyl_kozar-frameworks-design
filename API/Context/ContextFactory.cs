using System.Collections.Generic;
using System.Threading;

namespace API.Context
{
    public static class ContextFactory
    {
        private static readonly Dictionary<ApiContext, ThreadLocal<object>> ContextMap =
            new Dictionary<ApiContext, ThreadLocal<object>>
        {
                { ApiContext.Http, new ThreadLocal<object> { Value = new HttpContext() } }
        };

        public static T Get<T>(ApiContext apiContext) => (T)ContextMap[apiContext].Value;
        public static void Set(ApiContext apiContext, object context) => ContextMap[apiContext].Value = context;
    }
}
