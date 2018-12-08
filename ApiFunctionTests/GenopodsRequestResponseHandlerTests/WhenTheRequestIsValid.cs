using ApiFunction;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace ApiFunctionTests.GenopodsRequestResponseHandlerTests
{
    public class WhenTheRequestIsValid
    {
        [Theory]
        [InlineData("bob ross", "BOB ROSS")]
        [InlineData("BARBRA STREISAND", "BARBRA STREISAND")]
        public async Task TheResponseIsCorrect(string input, string expectation)
        {
            var logger = Substitute.For<ILogger<GenopodsRequestResponseHandler>>();
            var context = Substitute.For<Amazon.Lambda.Core.ILambdaContext>();

            var handler = new GenopodsRequestResponseHandler(logger);
            var result = await handler.HandleAsync(input, context);

            result.Should().Be(expectation);
        }
    }
}
