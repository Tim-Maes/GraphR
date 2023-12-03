# Clean Architecture GraphAPI solution template 

## Description

Simple Graph API solution template using Dapper ORM for .NET 8 with clean code, clean architecture and CQRS in mind..
Ideal if you need to set up an Graph API on a existing database. Just install and use the template and start adding queries and mutations.

## Technologies

- [.NET 8](https://github.com/dotnet/core)
- [Dapper](https://github.com/DapperLib/Dapper)
- [HotChocolate](https://github.com/ChilliCream/graphql-platform)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [Bindicate](https://github.com/Tim-Maes/Bindicate)

## Give it a star! :star:
If you have used this template, learned something or like what you see, consider giving it a star!

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

Replace the `connectionString` in `appsettings.json`  with your own and remove the `Seed` folder in the `Infrastructure` project.
Remove the example queries/mutation/repositories etc and implement your own.

## Architecture overview

### WebApi

A .NET 8 WebAPI application, here we have our GraphAPI endpoint. This application depends on the Application layer, and it also has a reference to the Infrastructure layer to wire up the IoC container (dependency injection), so we only use it in the `ServiceCollectionExtensions`.

### Application

This layer contains all application logic and it depends only on the Domain and Core layer. Here we implement the handlers, graphApi input and output types, queries and mutations.

### Domain

This will contain all models, enums, exceptions, interfaces, types and logic specific to the domain layer. This project references no other project.

### Infrastructure

In this layer we implement the data access (repositories, Dapper implementation, EntityMaps..) and possibly classes to access other external resources. These classes should be based on interfaces defined within the application layer. 

### Core

This project holds some core logic that we need in our solution. In the template, we have logic that wires up the custom handler system and the method to register Dapper `IEntityMap<T>` registrations.

## Autowiring

This project uses the `Bindicate` library to autowire dependencies by using attributes, so we don't bloat the `ServiceCollectionExtensions`.


## Test the API

Build and run the project, and navigate to <localhost>/graphql, this will take you to the Banana Cake Pop playground where you can find the graphql schema:

![image](https://github.com/Tim-Maes/GraphR/assets/91606949/5b8bdfb1-74fc-4e54-a8a9-e72cacd4845c)

You can play around in the Banana Cake Pop playground and test out a query.

For example:

![image](https://github.com/Tim-Maes/GraphR/assets/91606949/57b26947-86e0-4c5f-b74a-ea92520b7d31)
