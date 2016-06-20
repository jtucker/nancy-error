using System;
using RestSharp;

namespace NancyError.Infrastructure
{
    public interface IClientFactory
    {
        IRestClient GetClient(string baseUrl);
    }

    public class ClientFactory : IClientFactory
    {
        private readonly string _token; 
        public ClientFactory(string token)
        {
            _token = token;
        }

        public IRestClient GetClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);
            client.AddDefaultHeader("Correlation-Token", _token);
            return client;  
        }
    }
}
