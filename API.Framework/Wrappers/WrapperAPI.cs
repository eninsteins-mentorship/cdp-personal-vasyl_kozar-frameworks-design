using RestSharp;
using System.Configuration;

namespace API.Framework
{
    public class WrapperAPI
    {
        string ApiUrl = ConfigurationManager.AppSettings.Get("URL");

        /// <summary>
        /// Method implements GET request
        /// </summary>
        /// <param name="resource">Resource requested</param>
        /// <returns>IRestResponse Type</returns>
        public IRestResponse GetRequest(string resource)
        {
            // Create client
            var client = new RestClient(ApiUrl);

            // Create GET request
            var request = new RestRequest(resource, Method.GET);

            // Execute the request
            return client.Execute(request);
        }

        /// <summary>
        /// Method implements POST request
        /// </summary>
        /// <param name="resource">Resource requested</param>
        /// <param name="objectToPost">Post object</param>
        /// <returns>IRestResponse Type</returns>
        public IRestResponse PostRequest(string resource, object objectToPost)
        {
            // Create client
            var client = new RestClient(ApiUrl);

            // Create POST request
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Content-type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(objectToPost);

            // Execute the request
            return client.Execute(request);
        }

        /// <summary>
        /// Method implements DELETE request
        /// </summary>
        /// <param name="resource">Resource requested</param>
        /// <returns>IRestResponse Type</returns>
        public IRestResponse DeleteRequest(string resource)
        {
            // Create client
            var client = new RestClient(ApiUrl);

            // Create DELETE request
            var request = new RestRequest(resource, Method.DELETE);

            // Cxecute the request
            return client.Execute(request);
        }
    }
}
