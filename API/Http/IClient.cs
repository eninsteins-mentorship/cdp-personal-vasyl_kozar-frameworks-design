using RestSharp;

namespace API.Http
{
    interface IClient
    {
        IRestResponse Execute();
    }
}
