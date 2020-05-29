using Microsoft.Extensions.Configuration;

namespace NHibernate.NodaTime.Tests
{
    public static class TestConfiguration
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                //.SetBasePath(outputPath)
                .AddJsonFile("appsettings.test.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
