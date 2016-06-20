using NancyError.Models;
using System.Collections.Generic;

namespace NancyError.Infrastructure
{
    public interface ISearchMessageClient
    {
        List<string> Query(SearchQuery query);
    }

    public class SearchMessageClient : ISearchMessageClient
    {
        private readonly IClientFactory _factory;

        public SearchMessageClient(IClientFactory factory)
        {
            _factory = factory;
        }
        public List<string> Query(SearchQuery query)
        {
            return new List<string>
            {
                "Hello",
                "World",
                "This",
                "Day"
            };
        }
    }
}
