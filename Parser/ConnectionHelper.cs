using System;
using System.Diagnostics;

namespace HerokuPGParser
{
    public class ConnectionHelper
    {
        public static string BuildExpectedConnectionString(string herokuPGConnectionString)
        {
            Uri url;
            var connectionUrl = "";
            bool isUrl = Uri.TryCreate(herokuPGConnectionString, UriKind.Absolute, out url);
            if (isUrl && 
                !string.IsNullOrEmpty( url.UserInfo) &&
                url.UserInfo.Split(':').Length > 1)
                connectionUrl = $"host={url.Host};username={url.UserInfo.Split(':')[0]};password={url.UserInfo.Split(':')[1]};database={url.LocalPath.Substring(1)};pooling=true;";
            else
            {
                var msg = $"ERROR: Invalid PG Connection string : '<<{herokuPGConnectionString}>>'";
                Trace.TraceWarning(msg);
                Console.WriteLine(msg);
            }
            
            return connectionUrl;
        }
    }
}
