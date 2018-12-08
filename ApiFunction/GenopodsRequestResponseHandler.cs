using Amazon.Lambda.Core;
using Kralizek.Lambda;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ApiFunction
{
    public class GenopodsRequestResponseHandler : IRequestResponseHandler<string, string>
    {
        private readonly ILogger<GenopodsRequestResponseHandler> _logger;

        public GenopodsRequestResponseHandler(ILogger<GenopodsRequestResponseHandler> logger)
        {
            _logger = logger;
        }

        public async Task<string> HandleAsync(string input, ILambdaContext context)
        {
            if (input == null)
                _logger.LogError("Input is null");

            return input?.ToUpper();
        }
    }
}