# AspDotNetCoreWebApi
Getting started web Api in asp .net core 3.1

In this project I want to test and implement most of useful NuGet packages about asp .net core web api 
but right now I just implementing :

* simple CRUD api with entity framework core.
* using XUnit test (Integration testing) 

## What is ASP.NET Core?

ASP.NET is a popular web-development framework for building web apps on the .NET platform.
ASP.NET Core is the open-source version of ASP.NET, that runs on macOS, Linux, and Windows. ASP.NET Core was first released in 2016 and is a re-design of earlier Windows-only versions of ASP.NET.

for more information check [this](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core)

## NuGet packages

I have used these NuGet packages since first commite date :

These 3 packages for creating migration and connecting database 

* [Microsoft Entity framework design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/ "package page link") 
* [Microsoft Entity framework sqlserver](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/ "package page link") 
* [Microsoft Entity framework tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/ "package page link")

These 3 packages for xunit and intgration test

* [Microsoft Entity framework core In memory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/ "package page link") 
* [FluentAssertions](https://www.nuget.org/packages/FluentAssertions/, "package page link")
* [Microsoft AspNetCore mvc testing ](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing "package page link") 

These pakages are used in CQRS + mediatR :

* [MediatR](https://www.nuget.org/packages/MediatR/ "package page link") 
* [MediatR.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/MediatR.Extensions.Microsoft.DependencyInjection/ "package page link") 

These pakages are usesd for fluent and pipline validation :
* [FluentValidation](https://www.nuget.org/packages/FluentValidation/ "package page link") 
* [FluentValidation.DependencyInjectionExtensions](https://www.nuget.org/packages/FluentValidation.DependencyInjectionExtensions/ "package page link") 


## what is CQRS ?

The Command and Query Responsibility Segregation (CQRS) pattern separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.

![CQRS pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/_images/command-and-query-responsibility-segregation-cqrs-basic.png)

### The Problem :
In traditional architectures, the same data model is used to query and update a database. That's simple and works well for basic CRUD operations. In more complex applications, however, this approach can become unwieldy .

### Solution :
CQRS separates reads and writes into different models, using commands to update data, and queries to read data.

### Benefits of CQRS include:

- Independent scaling
- Optimized data schemas
- Security
- Separation of concerns
- Simpler queries

for more information about CQRS check * [this](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs "CQRS") 

### Validation 
In this pattern you can implement validation for every command and query . 
I use fluent validatian and pipleline validation in behavior directory (it's better to use flunet validation NOT data annotation !!).
If something goes wrong pipeline validation throw exception and validation filter return error as a json to front (I add validation filer to catch exceptions ).

## What is MediatR ?
MediatR is essentially a library that allows in process messaging – which in turn allows you to follow the Mediator Pattern!
according to Jason Taylor CQRS + MediatR = LOVE . 

he use CQRS and MediatR in clean code architecture for more info click [this](https://github.com/jasontaylordev "Jason Taylor") 
also you can watch this [video](https://www.youtube.com/watch?v=dK4Yb6-LxAk&t=43s) about clean code architecture . 

I use CQRS + mediatR + Repository patern for customer controller check it out . 

