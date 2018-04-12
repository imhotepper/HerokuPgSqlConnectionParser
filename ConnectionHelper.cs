using System;

namespace HerokuPGParser
{
    public class ConnectionHelper
    {
        public static string BuildExpectedConnectionString(string herokuPGConnectionString)
        {
            Uri url;
            var connectionUrl = "";
            bool isUrl = Uri.TryCreate(herokuPGConnectionString, UriKind.Absolute, out url);
            if (isUrl)
            {
                connectionUrl = $"host={url.Host};username={url.UserInfo.Split(':')[0]};password={url.UserInfo.Split(':')[1]};database={url.LocalPath.Substring(1)};pooling=true;";               
            }
            return connectionUrl;
        }
    }
}
