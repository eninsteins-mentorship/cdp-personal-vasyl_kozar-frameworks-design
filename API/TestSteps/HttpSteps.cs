using API.Context;
using API.Extensions;
using API.Http;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace API.TestSteps
{
    [Binding]
    public class HttpSteps
    {
        [Given(@"I make '(.*)' request to '(.*)'")]
        public void GivenIMakeRequestTo(Method method, string url, Table table = null)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            context.Client = HttpClient.RestApiBuilder()
                .SetUrl(url)
                .SetUrlSegments(table.ToFormatedDictionaty())
                .SetMethod(method);
            ContextFactory.Set(ApiContext.Http, context);
        }

        [Given(@"request contains headers")]
        public void GivenRequestContainsHeaders(Table table)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            context.Client = context.Client.SetHeaders(table.ToFormatedDictionaty());
            ContextFactory.Set(ApiContext.Http, context);
        }

        [When(@"I send a request")]
        public void WhenISendARequest()
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            context.Response = context.Client.Build().Execute();
            ContextFactory.Set(ApiContext.Http, context);
        }

        [Then(@"response code is '(.*)'")]
        public void ThenResponseCodeIs(int statusCode)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            Assert.AreEqual(statusCode, (int)context.Response.StatusCode, context.Response.Content);
        }

    }
}
