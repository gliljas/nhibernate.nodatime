using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
