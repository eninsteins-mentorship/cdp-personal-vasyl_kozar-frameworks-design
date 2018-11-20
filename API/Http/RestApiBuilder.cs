using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;

namespace API.Http
{
    class RestApiBuilder : IHttpBuilder
    {
        private readonly HttpClient _httpClient = new HttpClient(ConfigurationManager.AppSettings["apiUrl"]);

        public IHttpBuilder SetUrl(string url)
        {
            _httpClient.Url = url;
            return this;
        }

        public IHttpBuilder SetBody(string bodyItems)
        {
            _httpClient.Body = bodyItems;
            return this;
        }

        public IHttpBuilder SetBodyAsObject(object bodyItems)
        {
            _httpClient.Body = JsonConvert.SerializeObject(bodyItems);
            return this;
        }

        public IHttpBuilder SetUrlSegments(Dictionary<string, string> urls)
        {
            _httpClient.UrlSegments = urls;
            return this;
        }

        public IHttpBuilder SetHeaders(Dictionary<string, string> headers)
        {
            _httpClient.Headers = headers;
            return this;
        }

        public IHttpBuilder SetParameters(Dictionary<string, string> parameters)
        {
            _httpClient.Parameters = parameters;
            return this;
        }

        public IHttpBuilder SetMethod(Method method)
        {
            _httpClient.HttpMethod = method;
            return this;
        }

        public HttpClient Build()
        {
            return _httpClient;
        }
    }
}
