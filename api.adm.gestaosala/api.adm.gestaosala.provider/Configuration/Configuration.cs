using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace api.adm.gestaosala.provider
{
    public class Configuration
    {
        public static string Conn()
        {
            var configuration = GetConfiguration(Directory.GetCurrentDirectory());
            var connstring = configuration.GetConnectionString("DefaultConnection");
            return connstring;
        }

        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (string.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
