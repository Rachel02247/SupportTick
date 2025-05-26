using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTag.Configuration
{
    using DotNetEnv;
    using System.Data;
    using System.Linq.Expressions;

    public static class EnvConfigLoader
    {
        public static GoogleAuthSettings LoadGoogleAuthSettings()

        {
            Env.Load();

            Console.WriteLine(Environment.GetEnvironmentVariable("CLIENT_ID"));
            Console.WriteLine(Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            Console.WriteLine(Environment.GetEnvironmentVariable("PROJECT_ID"));

            return new GoogleAuthSettings
            {
                ClientId = Environment.GetEnvironmentVariable("CLIENT_ID") ?? throw new ArgumentNullException("Client ID NOT FOUND"),
                ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET") ?? throw new ArgumentNullException("Client secret NOT FOUND"),
                ProjectId = Environment.GetEnvironmentVariable("PROJECT_ID") ?? throw new ArgumentNullException("Project ID NOT FOUND")
            };
        }
    }
}

