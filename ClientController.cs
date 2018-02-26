using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace httpclientfactory
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        ValuesClient _sampleClient;
        public ClientController(ValuesClient sampleClient, IHttpClientFactory httpClientFactory)
        {
            _sampleClient=sampleClient;
        }

        public async Task<ActionResult> Get()
        {
            // request handlers 
            return Ok( await _sampleClient.GetText());        
               
        }

    }
}