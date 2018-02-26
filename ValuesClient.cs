using System.Net.Http;
using System.Threading.Tasks;

namespace httpclientfactory
{
    public class ValuesClient
    {
        private readonly HttpClient _client;

        public ValuesClient(HttpClient client) => _client = client;

        public async Task<string> GetText()
        {
            var x=await _client.GetStringAsync("http://localhost:5000/api/values");
            return x;
        }

    }
}