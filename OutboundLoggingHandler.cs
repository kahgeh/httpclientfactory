using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace httpclientfactory
{
    public class OutboundLoggingHandler : DelegatingHandler
    {
        ILogger<OutboundLoggingHandler> _logger;
        IHttpContextAccessor _contextAccessor;
        public OutboundLoggingHandler(ILogger<OutboundLoggingHandler> logger, IHttpContextAccessor contextAccessor)
        {
            _logger=logger;
            _contextAccessor = contextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            var CorrelationId=System.Guid.NewGuid().ToString();
            if ( !string.IsNullOrEmpty(_contextAccessor.HttpContext.Request.Headers["CorrelationId"] )){
                CorrelationId =_contextAccessor.HttpContext.Request.Headers["CorrelationId"];
            }
            _logger.LogInformation($"[{CorrelationId}]****{request.RequestUri}\t{(int)response.StatusCode}\t{response.Headers.Date}****");

            return response;
        }
    }
}