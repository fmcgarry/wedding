# Overview

This repository contains the code for my Wedding website. It tries to follow Clean Architecture and utilizes Mediatr to implement the CQRS pattern. 
This code is meant to be exploratory example/demo code, so consistency has been ignored in favor of experimentation. 

The Wedding.Api project is a .NET Minimal API that utilizes a custom Feature registering pattern. Classes which implement the `IFeature` interface
are discovered and registered to the Service Collection automatically during startup through the _FeatureExtensions.RegisterFeatures_ `IServiceCollection`
extension method. The _FeatureExtensions.MapFeatureEndpoints_ `WebApplication` extension method is used to register all Minimal API endpoints in the
feature by calling _IFeature.MapEndpoints_.

# Setup

Follow the instructions [here](/tools/database/README.md) to create a new MSSQL docker container for the database.

The following appsettings are required for the Wedding.Api project:

```json
  "ConnectionStrings": {
    "ApplicationDb": "Data Source=localhost;User ID=sa;Password=;Trust Server Certificate=True"
  }
```

- `Password` is the password you used when creating the database.

Alternatively, set `Data Source`, `User ID`, and `Password` in the connection string above to your own MSSQL instance. If connecting to your own database, ensure an empty database has been created before running the migrations.

Run the migrations with this command while sitting at the solution root:

```powershell
dotnet ef database update --project "src\Wedding.Infrastructure\" --startup-project "src\Wedding.Api\"
```

# Developing

If modifications are made to the Wedding.Core.Entities namespace, run the following command while sitting at the solution root to generate a new migration:

```powershell
dotnet ef migrations add <Name> --project "src\Wedding.Infrastructure\" --startup-project "src\Wedding.Api\" --output-dir "Data\Migrations"
```

- `Name` is the name of the Migration.
