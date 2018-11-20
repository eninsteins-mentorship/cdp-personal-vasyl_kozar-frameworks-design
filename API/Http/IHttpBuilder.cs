using RestSharp;
using System.Collections.Generic;

namespace API.Http
{
    public interface IHttpBuilder
    {
        IHttpBuilder SetUrl(string url);
        IHttpBuilder SetBody(string bodyItems);
        IHttpBuilder SetBodyAsObject(object BodyItems);
        IHttpBuilder SetUrlSegments(Dictionary<string, string> bodyItem);
        IHttpBuilder SetHeaders(Dictionary<string, string> headers);
        IHttpBuilder SetParameters(Dictionary<string, string> parameters);
        IHttpBuilder SetMethod(Method method);
        HttpClient Build();
    }
}
