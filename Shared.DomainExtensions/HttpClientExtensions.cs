using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shared.DomainExtensions
{
    public static class HttpClientExtensions
    {
        private static readonly HttpClient Client = new();

        public static async Task<bool> CheckIsAliveEndpointAsync(this string requestUrl) =>
            (await Client.GetAsync(requestUrl)).StatusCode == HttpStatusCode.OK;
    }
}