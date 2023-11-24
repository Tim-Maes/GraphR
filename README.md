# Clean Architecture GraphAPI solution template 

Simple Graph API architecture template using Dapper ORM for .NET 8.
Ideal if you need to set up an Graph API on a existing database. Just install and use the template and start adding queries and mutations.

## Technologies

- [.NET 8](https://github.com/dotnet/core)
- [Dapper](https://github.com/DapperLib/Dapper)
- [HotChocolate](https://github.com/ChilliCream/graphql-platform)
- [Bindicate](https://github.com/Tim-Maes/Bindicate)

## Usage

**Install GraphR**

```bash
dotnet new --install GraphR
```

**Scaffold your solution**


Create a folder, for example 'MyNewSolution' and run this command inside the folder:

```bash
dotnet new graphr -n MyNewSolution
```
The complete solution will be scaffolded inside your folder. Open it in Visual Studio:

![image](https://github.com/Tim-Maes/GraphR/assets/91606949/9f977670-cddb-48c6-8b4c-eb83c496845f)

## Setup

Update the `connectionString` in `appsettings.json` and remove the `Seed` folder in the `Infrastructure` project.
Remove the example queries/mutation/repositories and implement your own.

## Overview

**API**

This layer is a web api application based on ASP.NET 8. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only `program.cs` should reference Infrastructure.

**Application**

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

**Domain**

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

**Infrastructure**

This layer contains classes for accessing external resources. These classes should be based on interfaces defined within the application layer.

**Core**

This layer contains core logic that is not bound to the domain. For example, our own handler implementation is located there.


