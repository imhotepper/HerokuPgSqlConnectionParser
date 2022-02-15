using System;
using System.Diagnostics;

namespace HerokuPGParser
{
    public class ConnectionHelper
    {
        public static string BuildExpectedConnectionString(string herokuPGConnectionString)
        {
            Uri uri;
            var connectionUrl = "";
            bool isUrl = Uri.TryCreate(herokuPGConnectionString, UriKind.Absolute, out uri);
            Console.WriteLine("Is URI ? -> "+ isUrl);
            if (isUrl &&
                !string.IsNullOrEmpty(uri.UserInfo) &&
                uri.UserInfo.Split(':').Length > 1)
            {
                // connectionUrl = $"host={url.Host};username={url.UserInfo.Split(':')[0]};password={url.UserInfo.Split(':')[1]};database={url.LocalPath.Substring(1)};pooling=true;";
                var username = uri.UserInfo.Split(':')[0];
                var password = uri.UserInfo.Split(':')[1];
                connectionUrl =
              "host=" + uri.Host +
               "; Database=" + uri.AbsolutePath.Substring(1) +
               "; Username=" + username +
               "; Password=" + password +
              "; SSL Mode=Require; Trust Server Certificate=true;";

                if (uri.Port > 0)
                    connectionUrl += $" ; Port= {uri.Port} ";
            }
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
