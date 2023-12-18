# Clean Architecture GraphAPI solution template :sunny:

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

## Installation and Usage :wrench:

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

## Setup :hammer_and_wrench:

Replace the `connectionString` in `appsettings.json`  with your own and remove the `Seed` folder in the `Infrastructure` project.
Remove the example queries/mutation/repositories etc and implement your own.

## Implementing Mutation & Query

In the core layer we have a custom lightweight handler implementation. These are `Handler<TOutput>` for querying data without parameters,
and `Handler<TInput, TOutput>` for querying or mutating data with parameters.
Handler is a abstract class so we can leverage the validation method leveraging FluentValidation. You still need to define a interface for DI purpose.

Since we don't use `AutoMapper` to map input types to output types, we just write an extension method `ToOutput()` that maps `TInput` to `ToOutput()`.

`FluentValidation` is used to validate input parameter properties.

### Example

```csharp
internal sealed class GetBookByIdQueryHandler : Handler<GetBookByIdParameters, BookDto>, IGetBookByIdHandler
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    protected override void DefineRules()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }

    protected override async Task<BookDto> HandleValidatedRequest(GetBookByIdParameters request)
        => (await _bookRepository.GetById(request.Id)).ToOutput();
}

public interface IGetBookByIdHandler : IHandler<GetBookByIdParameters, BookDto> { }
```

Inject the `IGetBookByIdQueryHandler` in your GraphApi query using the HotChocolate `[Service]` attribute, do the same for Mutations.

```csharp
public sealed class BooksQuery
{
    public async Task<BookDto> Book([Service] IGetBookByIdHandler handler, GetBookByIdParameters parameters)
        => await handler.Handle(parameters);
}
```

This is an example of how your GraphApi application layer could be structured
![image](https://github.com/Tim-Maes/GraphR/assets/91606949/3384b79a-0b3e-4587-82a5-ffe579731715)


## Database :file_cabinet:

Currently supports a `DbConnectionProvider` for a single SQL database connection. Inject the `IDbConnectionProvider` in your repositories.

### Transactions

In the domain folder there is a abstraction of the `DbTransaction` implementation. You can inject the `ITransaction` interface in a `MutationHandler` in your Application layer if you need to mutate data over multiple repositories.

```csharp
internal class ExampleMutationHandler : Handler<ExampleMutationParameters, Result>,
    IExampleMutationHandler
{
    private readonly IRepository _repository;
    private readonly ISecondRepository _secondRepository;
    private readonly ITransaction _transaction;

    public ExampleMutationHandler(
        IRepository secondRepository,
        ISecondRepository secondRepository,
        ITransaction transaction)
    {
        _repository = repository;
        _secondRepository = secondRepository;
        _transaction = transaction;
    }

    protected override void DefineRules()
    {
        // FluentValidation RuleSet for your input
    }

    protected override async Task<Result> HandleValidatedRequest(ExampleMutationParameters input)
    {
        _transaction.Begin()
        try
        {
            await _repository.Create(...);

            await _secondRepository.UpdateSomething( ... );

            _transaction.Commit();
        }
        catch
        {
            _transaction.RollBack();
            throw;
        }

        return new Result(...);
    }
}

public interface IExampleMutationHandler : IHandler<ExampleMutationParameters, Result> { }
```

## Architecture overview :spiral_notepad:

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
