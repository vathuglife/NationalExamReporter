using System.IO;
using Microsoft.Extensions.Configuration;
using NationalExamReporter.Constants;

namespace NationalExamReporter.Utils
{
    public class ConfigurationUtils
    {        
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(ConfigPaths.AppSettings);

            return builder.Build();
        }
    }
}
