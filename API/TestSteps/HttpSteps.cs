using API.Context;
using API.Extensions;
using API.Http;
using API.TestSteps.Util;
using Chilkat;
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

        [Given(@"request has body from file '(.*)'")]
        public void GivenRequestHasBodyFromFile(string file, Table table)
        {
            var processTable = table.WithMacroses();
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            JsonObject json = JsonUtil.LoadJsonObjectFromFile(file);
            foreach (var row in processTable.Rows)
                JsonUtil.PerformOperation(row[1], !row[2].StartsWith("$") ? row[2] : context.GlobalProps[row[2]], row[0], ref json);
            context.Client = context.Client.SetBody(context.Body = json.Emit());
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

        [Then(@"response has fallowing attribute:")]
        public void ThenResponseHasFollowingAttribute(Table table)
        {
            var processTable = table.WithMacroses();
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            JsonObject json = JsonUtil.LoadJsonObject(context.Response.Content);
            foreach (var row in processTable.Rows)
                Assert.AreEqual(!row[2].StartsWith("$") ? row[2] : context.GlobalProps[row[2]], json.StringOf(row[0]));
        }

        [Then(@"response has fallowing field:")]
        public void ThenResponseHasFollowingField(Table table)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            JsonObject json = JsonUtil.LoadJsonObject(context.Response.Content);
            foreach (var row in table.Rows)
                Assert.AreNotEqual(json.StringOf(row[0]), null, $"key is not present: {row[0]}");
        }

        [Then(@"response doesn't have fallowing field:")]
        public void ThenResponseDoesntHaveFollowingField(Table table)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            JsonObject json = JsonUtil.LoadJsonObject(context.Response.Content);
            foreach (var row in table.Rows)
                Assert.AreEqual(json.StringOf(row[0]), null, $"key is not present: {row[0]}");
        }

        [Then(@"response contains the fallowing error message:")]
        public void ThenResponseContainsFallowingErrorMessage(Table table)
        {
            var context = ContextFactory.Get<HttpContext>(ApiContext.Http);
            JsonObject json = JsonUtil.LoadJsonObject(context.Response.Content);
            foreach (var row in table.Rows)
            {
                JsonObject propertyError = json.FindRecord("details", "property", row[0], true);
                Assert.IsTrue(propertyError != null, "Error meesage not found " + row[0]);
                Assert.AreEqual(row[1], propertyError.StringOf("messages[0]"));
            }
        }
    }
}
