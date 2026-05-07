# ContactList - TDD with RDBMS Demo

A simple ASP.NET Core MVC app for managing contacts, backed by SQL Server via Entity Framework Core. Used in CS 367 to demonstrate TDD with a relational database.

## Prerequisites

- .NET 8 SDK
- A running SQL Server instance (Docker is easiest - see below)
- The EF Core CLI tools: `dotnet tool install --global dotnet-ef`

## Run SQL Server in Docker

```bash
docker run -e "ACCEPT_EULA=Y" \
           -e "MSSQL_SA_PASSWORD=YourStrong@Passw0rd" \
           -p 1433:1433 \
           --name cs367-mssql \
           -d mcr.microsoft.com/mssql/server:2022-latest
```

(Use `docker start cs367-mssql` to bring it back up after a reboot.)

## Configure the connection string

The connection string is **not** stored in `appsettings.json` because it contains a password. Use [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) instead - secrets are stored in your home directory, outside the repo.

From the project root:

```bash
dotnet user-secrets set "ConnectionStrings:ContactList" \
  "Server=localhost,1433;Database=ContactList;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;"
```

Adjust the connection string if your SQL Server isn't on `localhost:1433` or you used a different `sa` password.

To inspect or remove what you've set:

```bash
dotnet user-secrets list
dotnet user-secrets remove "ConnectionStrings:ContactList"
```

User Secrets only apply in the **Development** environment - so they won't accidentally leak into a production deployment.

## First run

```bash
dotnet run
```

On startup the app:

1. Applies any pending EF migrations (creates the `ContactList` database and `Contacts` table on first run).
2. Seeds the table with three sample contacts if it's empty.

Then browse to the URL shown in the console (typically `http://localhost:5273`).

## Working with migrations

```bash
dotnet ef migrations add <Name>     # add a new migration after changing the model
dotnet ef database update            # apply pending migrations manually
dotnet ef database drop --force      # nuke the database (handy when iterating)
```
