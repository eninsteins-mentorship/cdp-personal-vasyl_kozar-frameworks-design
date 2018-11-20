using API.Http;
using RestSharp;
using System.Collections.Generic;

namespace API.Context
{
    public class HttpContext
    {
        public IHttpBuilder Client { get; set; }
        public IRestResponse Response { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> GlobalProps = new Dictionary<string, string>();
    }
}
