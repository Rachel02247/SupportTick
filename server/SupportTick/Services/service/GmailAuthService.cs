using DotNetEnv;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MailTag.Configuration;
using SupportTick.Models;
using System.Net.Mail;

namespace SupportTick.Services.service
{
    public class GmailAuthService
    {
        static string[] Scopes = { GmailService.Scope.MailGoogleCom };
        public static GmailService GetGmailService()
        {
            var setting = EnvConfigLoader.LoadGoogleAuthSettings();
            Console.WriteLine(setting.ClientId);

            var clientSecrets = new ClientSecrets()
            {
                ClientId = setting.ClientId,
                ClientSecret = setting.ClientSecret,
            };

            var credPath = "token.json";

            if (File.Exists(credPath))
            {
                File.Delete(credPath);
            }

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Console.WriteLine("Credential file saved to: " + credPath);


            return new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "SupportTick"
            });


        }

    }
}
