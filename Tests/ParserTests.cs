using System;
using System.Diagnostics;
using HerokuPGParser;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class ParserTests
    {
        [Fact]
        public void Can_parse_empty_con_string()
        {
            var emptyConStr = string.Empty;

            var conStr = HerokuPGParser.ConnectionHelper.BuildExpectedConnectionString(emptyConStr);
            Assert.Empty(conStr);
        }

        [Fact]
        public void Can_parse_invalid_uri_string()
        {
            var pgConStr = "postgres://";
            var conStr = ConnectionHelper.BuildExpectedConnectionString(pgConStr);

            Assert.Empty(conStr);
        }

        [Fact]
        public void Can_parse_random_string()
        {
            var pgConStr = "here is some invalid connection string";
            var conStr = ConnectionHelper.BuildExpectedConnectionString(pgConStr);

            Assert.Empty(conStr);
        }

        [Fact]
        public void Can_Parse_Valid_PG_Con_String()
        {

            var pgConStr = "postgres://user:password@host:1234/DATABASE";
            var conStr = ConnectionHelper.BuildExpectedConnectionString(pgConStr);

            Assert.NotEmpty(conStr);
            Assert.Contains("host", conStr);
            Assert.Contains("Username", conStr);
            Assert.Contains("Password", conStr);
            Assert.Contains("Database", conStr);
        }

         [Fact]
        public void Can_Parse_NEW_Valid_PG_Con_String()
        {

            var pgConStr = "postgres://user:password@host:1234/DATABASE";
         
            Uri url;
            
            bool isUrl = Uri.TryCreate(pgConStr, UriKind.Absolute, out url);
            
            Debug.Print("is url: " + isUrl);;

            var conStr = ConnectionHelper.BuildExpectedConnectionString(pgConStr);

            Assert.NotEmpty(conStr);
            Assert.Contains("host", conStr,StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains("username", conStr,StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains("password", conStr,StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains("database", conStr,StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains("port", conStr,StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void Can_parse_elephant_sql_conn_str()
        {
            var elephantSqlConnStr = "postgres://usr:something@server.com/db";
            
            var conStr = ConnectionHelper.BuildExpectedConnectionString(elephantSqlConnStr);

            Assert.NotEmpty(conStr);

        }

        [Fact]
        public void Can_parse_elephant_without_port()
        {
            var elephantSqlConnStr = "postgres://usr:something@server.com/db";
            
            var conStr = ConnectionHelper.BuildExpectedConnectionString(elephantSqlConnStr);

            Assert.NotEmpty(conStr);
            
            Assert.DoesNotContain("port",conStr);

        }
    }
}