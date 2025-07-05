# NewRelic.NerdGraph

A modern, strongly-typed .NET client library for New Relic's NerdGraph API. This library provides a fluent, type-safe interface for querying and mutating data using GraphQL, designed for easy integration into .NET applications with full support for dependency injection, configuration, and extensibility.

---

## Features

- **Fluent Query/Mutation Builders**: Compose GraphQL queries and mutations using a fluent, discoverable API.
- **Strongly-Typed Models**: All requests and responses use C# models for safety and IntelliSense.
- **Dependency Injection Ready**: Register and configure the client via `IServiceCollection` for ASP.NET Core and other DI containers.
- **Configurable**: Easily set API keys, endpoints (US/EU), and timeouts.
- **Async/Await**: All operations are asynchronous for scalability.
- **Extensible**: Add new operations, models, or extend builders as New Relic's schema evolves.

---

## Getting Started

### 1. Install the Package

```sh
dotnet add package NewRelic.NerdGraph
```

### 2. Configure the Client

```csharp
using Microsoft.Extensions.DependencyInjection;
using NewRelic.NerdGraph;

var services = new ServiceCollection();

services.AddNerdGraphClient(options =>
{
    options.ApiKey = "<YOUR_NEW_RELIC_API_KEY>";
    options.Endpoint = NerdGraphEndpoint.US; // or NerdGraphEndpoint.EU
    options.Timeout = TimeSpan.FromSeconds(30);
});
```

### 3. Example Usage

```csharp
using NewRelic.NerdGraph;
using NewRelic.NerdGraph.Builders;
using NewRelic.NerdGraph.Models.Entities;

public class Example
{
    private readonly INerdGraphClient _client;

    public Example(INerdGraphClient client)
    {
        _client = client;
    }

    public async Task<EntitySearchResults?> SearchEntitiesAsync(string name)
    {
        var query = new EntityBuilder()
            .WithName(name)
            .Build();

        var response = await _client.ExecuteAsync<EntitySearchResults>(query);
        return response.Data;
    }
}
```

### 4. Configuration File Example

You can also configure the client using a configuration file (e.g., `appsettings.json`):

```json
{
  "NerdGraph": {
    "ApiKey": "<YOUR_NEW_RELIC_API_KEY>",
    "Endpoint": "US",
    "Timeout": 30
  }
}
```

In your `Startup.cs` or wherever you configure services:

```csharp
services.AddNerdGraphClient(Configuration.GetSection("NerdGraph"));
```

### 5. Extending the Library

- Add new queries/mutations by creating builder classes in src/NewRelic.NerdGraph/Builders/.
- Define request/response models in src/NewRelic.NerdGraph/Models/.
- Register new operations in the client as needed.
- See CONTRIBUTING.md for more details.

### 6. Testing

Tests are written using xUnit and live in tests/NewRelic.NerdGraph.Tests/.
Run tests with:

```sh
dotnet test
```

### 7. Documentation

See inline XML docs and src/NewRelic.NerdGraph/ for API details.
For advanced usage, refer to the .github/Copilot/copilot-instructions.md.

### 8. License

MIT © Brandon Henricks

### 9. Links

- New Relic NerdGraph API Docs
- NuGet Package
- Issues
