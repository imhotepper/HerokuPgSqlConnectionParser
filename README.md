# Heroku PostgreSQL connection string parser
Given a valid Heroku potgresql connection string this code will create the acceptable string to be used inside .net core 2.0 applications.

## How to use it
In your .net core 2.0 Startup.cs class in Configure method add:

`
 var conStr = Configuration.GetConnectionString("DefaultConnection");
            var pgConn = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrWhiteSpace(pgConn))
                conStr = HerokuPGParser.ConnectionHelper.BuildExpectedConnectionString(pgConn);
           
            services.AddDbContext<AppDb>(options => options.UseNpgsql(conStr));
`

Have fun