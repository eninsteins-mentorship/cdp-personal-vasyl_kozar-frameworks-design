using RestSharp;
using System;
using System.Collections.Generic;

namespace API.Http
{
    public class HttpClient : IClient
    {
        private static readonly RestClient Client = new RestClient();

        internal string Url { private get; set; }
        internal Dictionary<string, string> UrlSegments { private get; set; }
        internal Dictionary<string, string> Parameters { private get; set; }
        internal Dictionary<string, string> Headers { private get; set; }
        internal Method HttpMethod { private get; set; }
        internal string Body { private get; set; }

        internal HttpClient(string baseUrl)
        {
            Client.BaseUrl = new Uri(baseUrl);
        }

        public static IHttpBuilder RestApiBuilder()
        {
            return new RestApiBuilder();
        }

        private static Dictionary<string, string> GetMap(Dictionary<string, string> map) =>
            map ?? new Dictionary<string, string>();

        public IRestResponse Execute()
        {
            var request = new RestRequest(Url, HttpMethod);

            foreach (var entry in GetMap(UrlSegments))
                request.AddUrlSegment(entry.Key, entry.Value);

            foreach (var entry in GetMap(Parameters))
                request.AddParameter(entry.Key, entry.Value);

            foreach (var entry in GetMap(Headers))
                request.AddHeader(entry.Key, entry.Value);

            if (HttpMethod != Method.GET)
                request.AddParameter("application/json; charset=utf-8", Body, ParameterType.RequestBody);

            var response = Client.Execute(request);

            return response;
        }

    }
}
