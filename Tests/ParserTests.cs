using System;
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
            Assert.Contains("username", conStr);
            Assert.Contains("password", conStr);
            Assert.Contains("database", conStr);
        }
    }
}