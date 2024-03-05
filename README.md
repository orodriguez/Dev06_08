# Dev06_08
Live coding application for Alterna Dev06 Back-end Fundamentals

## Setup

Download and install [.net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

```bash
dotnet --version 
```

## Build
```bash
donet build
```

## Run Test
```bash
dotnet test
```

## Run Web App
```bash
dotnet run --project Okane.WebApi/Okane.WebApi.csproj
```

## How to create a solution using CLI

Read this [article](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

## Development Environment

Download [VS Code](https://code.visualstudio.com/download)

Install the following extensions:

* [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
* [.NET Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)

## Architecture

### Okane.Domain

Contain business rules for the application.

* Entities
* Domain Services

### Okane.Application

Contains coordination logic between entities and gateways.

* Services
* Repository Interfaces

### Okane.WebApi

Http interface for the application.

* Controllers
* Dependency Injection Configuration

### Okane.Tests

* Unit tests
* Sample test data

## [Class Notes](https://workflowy.com/s/alterna-dev06-08/S5PTSCJX0RKDHBXS)