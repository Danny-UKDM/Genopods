using Amazon.Lambda.Core;
using Kralizek.Lambda;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ApiFunction
{
    public class Function : RequestResponseFunction<string, string>
    {
        protected override void Configure(IConfigurationBuilder builder)
        {
            Console.WriteLine("Starting Configure");

            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();
        }

        protected override void ConfigureLogging(ILoggerFactory loggerFactory, IExecutionEnvironment executionEnvironment)
        {
            Console.WriteLine("Starting ConfigureLogging");

            loggerFactory.AddLambdaLogger(new LambdaLoggerOptions
            {
                IncludeCategory = true,
                IncludeLogLevel = true,
                IncludeNewline = true,
                Filter = (categoryName, logLevel) =>
                {
                    return logLevel >= LogLevel.Information;
                }
            });
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Starting ConfigureServices");

            RegisterHandler<GenopodsRequestResponseHandler>(services);
        }
    }
}
