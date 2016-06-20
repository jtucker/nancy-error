using Nancy;
using Nancy.ModelBinding;
using NancyError.Infrastructure;
using NancyError.Models;

namespace NancyError.Modules
{
    public class SearchMessagesModule : NancyModule
    {
        public SearchMessagesModule(ISearchMessageClient searchMessageClient)
        {

            Get["/"] = (_) =>
            {
                var query = this.Bind<SearchQuery>();

                var messages = searchMessageClient.Query(query);

                return Response.AsJson(messages);
            };
        }
    }
}