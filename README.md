# Heroku PostgreSQL connection string parser

Given a valid Heroku potgresql connection string this code will create the expected connection string to be used inside .net core 2.0 applications.

## How to use it
Install the package from here: https://www.nuget.org/packages/HerokuPGParser/

Inside your .net core 2.0 Startup.cs class in ConfigureServices method add:

```
var conStr = Configuration.GetConnectionString("DefaultConnection");
var pgConn = Environment.GetEnvironmentVariable("DATABASE_URL");

if (!string.IsNullOrWhiteSpace(pgConn))
    conStr = HerokuPGParser.ConnectionHelper.BuildExpectedConnectionString(pgConn);

services.AddDbContext<AppDb>(options => options.UseNpgsql(conStr));
```
Where AppDb is your EF Code DbContext.

Have fun!
