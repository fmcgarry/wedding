# Overview

This repository contains the code for my Wedding website. 
It contains two front-end projects WeddingSite and WeddingApp, and a back-end project Wedding.Api. 

## WeddingSite

The WeddingSite project is a standalone Blazor WebAssembly project. It's the v2 and final version of my wedding website, and is a static site that I've set up to be hosted by Azure at https://freddyandbre.com.

## WeddingApp

The WeddingApp project was a v1 attempt at creating my wedding website. I created it before knowing the exact requirements we needed for our site.
It has RSVP and guest management features, but they aren't entirely finished out. I didn't want to throw away the code when I created the WeddingSite project, so I've kept it so I can refer back to it in the future.

The app itself is a Blazor Web App using the Server hosting model, and it communicates over REST to the Wedding.Api project. 
This code is meant to be exploratory example/demo code, so consistency has been ignored in favor of experimentation. 

The Wedding.Api project is a .NET Minimal API that utilizes a custom Feature registering pattern. Classes which implement the `IFeature` interface
are discovered and registered to the Service Collection automatically during startup through the _FeatureExtensions.RegisterFeatures_ `IServiceCollection`
extension method. The _FeatureExtensions.MapFeatureEndpoints_ `WebApplication` extension method is used to register all Minimal API endpoints in the
feature by calling _IFeature.MapEndpoints_.

The Wedding.Core, Wedding.Infrastucture, and Wedding.UseCases projects are class libraries that contain the domain entities, data access logic, and use cases for the Wedding.Api project. It's intended to be an example of Clean Architecture utilzing MediatR for CQRS.

## Setup

Follow the instructions [here](/tools/database/README.md) to create a new MSSQL docker container for the database.

The following appsettings are required for the Wedding.Api project:

```json
  "ConnectionStrings": {
    "ApplicationDb": "Data Source=localhost;User ID=sa;Password=;Trust Server Certificate=True"
  }
```

- `Password` is the password you used when creating the database.

Alternatively, set `Data Source`, `User ID`, and `Password` in the connection string above to your own MSSQL instance. 
If connecting to your own database, ensure an empty database has been created before running the migrations.

Run the migrations with this command while sitting at the solution root:

```powershell
dotnet ef database update --project "src\Wedding.Infrastructure\" --startup-project "src\Wedding.Api\"
```

## Developing

If modifications are made to the Wedding.Core.Entities namespace, run the following command while sitting at the solution root to generate a new migration:

```powershell
dotnet ef migrations add <Name> --project "src\Wedding.Infrastructure\" --startup-project "src\Wedding.Api\" --output-dir "Data\Migrations"
```

- `Name` is the name of the Migration.

## Architecture

<p align="center">
  <img src="https://github.com/user-attachments/assets/21f28400-3ea9-4f5d-b4a6-c4b9610e0b85" alt="Architecture Diagram" /> 
</p>

I structured the projects using Clean Architecture while incorporating elements of vertical slice architecture for features. 
This approach organizes all code related to a feature in a single location, even when it spans multiple projects. 
The Infrastructure project contains external dependencies, such as the database and the client used to interact with the Google Photos API. 
Dependencies are represented using solid arrows, but at runtime, the API relies solely on the Infrastructure project.
