# Heroku Postgresql connection parser
Given a valid Heroku potgresql connection string this code will create the acceptable string to be used inside .net core 2.0 applications

## How to use it
In your .net core 2.0 Startup.cs class add :

`
using SpaApiMiddleware;
`

and then in Configure method add:

`
app.UseSpaApiOnly(indexHtmlPage:"index.html", apiPath:"api");
`

Both apiPath and indexHtmlPage are optional parameters.

Have fun,
Daiot
