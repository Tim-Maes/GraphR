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

![image](https://github.com/Tim-Maes/GraphR/assets/91606949/297e227a-4b55-44e0-ab92-4aa3dc5e7558)


## Setup

Update the `connectionString` in `appsettings.json` and remove the `Seed` folder in the `Infrastructure` project.
Remove the example queries/mutation/repositories and implement your own.

## Architecture overview

**WebApi**

A .NET 8 WebAPI application, here we have our GraphAPI endpoint. This application depends on the Application layer, and it also has a reference to the Infrastructure layer to wire up the IoC container (dependency injection), so we only use it in the `ServiceCollectionExtensions`.

**Application**

This layer contains all application logic and it depends only on the Domain and Core layer. Here we implement the handlers, mappings and GraphAPI queryies and mutations. This project depends on the Domain and the Core project.

**Domain**

This will contain all models, enums, exceptions, interfaces, types and logic specific to the domain layer. This project references no other project.

**Infrastructure**

In this layer we implement the data access (repositories, Dapper implementation,..) and possibly classes to access other external resources. These classes should be based on interfaces defined within the application layer. 

**Core**

This project holds some core logic that we need in our solution. In the template, we have logic that wires up handlers and dapper mappings to the `ServiceCollection`.

