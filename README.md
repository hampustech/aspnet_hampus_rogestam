# CoreFitness

En gymportal byggd i ASP.NET Core MVC med Clean Architecture och ASP.NET Core Identity.

## Kom igång

### Krav
- .NET 10
- Docker (för SQL Server)

### Starta databasen
Starta din SQL Server-container i Docker.

### Konfigurera connection string
Lägg till din connection string i `Presentation.WebApp/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "SqlConnection": "Server=localhost,1433;Database=CoreFitness;User Id=sa;Password=DITT_LÖSENORD;TrustServerCertificate=True;"
  }
}
```

### Kör migrations

```bash
dotnet ef database update --project Infrastructure --startup-project Presentation.WebApp
```

### Starta applikationen

```bash
dotnet run --project Presentation.WebApp
```

Öppna sedan `https://localhost:PORT` i webbläsaren. Porten visas i terminalen efter start.
