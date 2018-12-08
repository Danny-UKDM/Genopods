using Amazon.Lambda.Core;
using ApiFunction;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace ApiFunctionTests.GenopodsRequestResponseHandlerTests
{
    public class WhenTheRequestIsInvalid
    {
        protected readonly ILambdaContext _context;
        protected readonly GenopodsRequestResponseHandler _handler;

        public WhenTheRequestIsInvalid()
        {
            _context = Substitute.For<ILambdaContext>();
            var logger = Substitute.For<ILogger<GenopodsRequestResponseHandler>>();

            _handler = new GenopodsRequestResponseHandler(logger);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        public async Task TheResponseIsNull(string input, string expectation)
        {
            var result = await _handler.HandleAsync(input, _context);
            result.Should().Be(expectation);
        }
    }
}