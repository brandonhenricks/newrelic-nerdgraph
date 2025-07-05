# Copilot Project Instructions

## Project Overview

This repository is a C#/.NET client library for NewRelic's NerdGraph API, providing a strongly-typed, fluent interface for querying and mutating data using GraphQL. The project is structured for maintainability, testability, and developer ergonomics, and is intended for integration into .NET applications via dependency injection.

### Key Features

- **GraphQL Client**: [`INerdGraphClient`](../../src/NewRelic.NerdGraph/Interfaces/INerdGraphClient.cs) and [`NerdGraphClient`](../../src/NewRelic.NerdGraph/NerdGraphClient.cs) handle authentication, HTTP communication, and operation execution.
- **Configuration**: [`NerdGraphOptions`](../../src/NewRelic.NerdGraph/Configurations/NerdGraphOptions.cs) supports API keys, endpoint selection (US/EU), and timeout.
- **Dependency Injection**: [`DependencyInjection`](../../src/NewRelic.NerdGraph/DependencyInjection.cs) provides `IServiceCollection` extension methods for easy registration.
- **Fluent Query/Mutation Builders**: Query and mutation construction is done via builder classes (see [`Builders/`](../../src/NewRelic.NerdGraph/Builders/)), supporting a fluent, type-safe API.
- **Strongly-Typed Models**: All GraphQL requests and responses use typed models in [`Models/`](../../src/NewRelic.NerdGraph/Models/).
- **Selector Interfaces**: The [`Interfaces/Selector/`](../../src/NewRelic.NerdGraph/Interfaces/Selector/) folder contains interfaces for selecting fields in queries.
- **Extensible**: Designed for easy addition of new GraphQL operations, types, and selectors.
- **.NET Standard 2.0**: The main library targets netstandard2.0 for broad compatibility, with solution-wide build settings in [Directory.Build.props](../../Directory.Build.props).

## Workspace Structure

- `src/NewRelic.NerdGraph/` — Main library source code
  - `Builders/` — Query/mutation builder classes (fluent, type-safe)
  - `Configurations/` — Configuration models (API keys, endpoints, timeouts)
  - `Extensions/` — Reserved for extension methods
  - `Interfaces/` — Public/internal interfaces, including selectors
  - `Models/` — Typed models for GraphQL requests/responses
  - `DependencyInjection.cs` — DI registration helpers
  - `NerdGraphClient.cs` — Main client implementation
  - `NewRelic.NerdGraph.csproj` — Project file
- `.github/Copilot/` — Copilot configuration and instructions
- Solution/build files: `.sln`, `Directory.Build.props`, `Directory.Packages.props`, `global.json`, `nuget.config`, etc.

## Guidance for Copilot Responses

- **Workspace Awareness**: Reference and link to existing files, types, and methods in your suggestions. Use the established folder and namespace structure.
- **Code Changes**: Prefer minimal, well-structured code changes that preserve the architecture and folder structure. Use the correct subfolder for new files.
- **Authentication**: Always ensure the API key is included in the `Authorization` header for all HTTP requests.
- **Dependency Injection**: Use `IServiceCollection` extension methods for client registration. Follow ASP.NET Core DI patterns.
- **GraphQL Operations**: When adding new operations:
  - Create or extend request/response models in `Models/`.
  - Add or update builder/selector interfaces and implementations in `Builders/` and `Interfaces/Selector/`.
  - Ensure all new operations are strongly-typed and follow the fluent builder pattern.
- **Endpoints**: Validate and document support for both US (`api.newrelic.com`) and EU (`api.eu.newrelic.com`) endpoints.
- **Async Patterns**: Use `async`/`await` for all HTTP and GraphQL operations.
- **Testing**: Use xUnit for tests (prefer `Fact` unless parameterization is needed). Place tests in a separate test project (not present yet).
- **Error Handling**: Prefer returning result types (e.g., `GraphQLResponse<T>`) that include both data and errors, rather than throwing exceptions.
- **Serialization**: Use typed models for GraphQL variables and responses. Ensure compatibility with the GraphQL schema.
- **Backward Compatibility**: When refactoring, ensure public APIs remain backward compatible unless a major version bump is intended.
- **Documentation**: Document new GraphQL operations, models, or schema changes in the README or internal docs.
- **Performance**: Consider connection pooling and efficient HTTP usage for high-throughput scenarios.
- **Logging/Telemetry**: When adding new operations, consider how logging or telemetry could be integrated for observability.
- **Pagination**: When implementing queries that may return large result sets, support pagination according to NewRelic's schema.
- **GraphQL Schema**: Follow NewRelic's schema conventions and naming patterns. Mark deprecated or experimental fields with comments.
- **Extensibility**: When adding new query types (e.g., infrastructure, APM), follow the established builder and selector patterns.
- **Build/Packaging**: Respect solution-wide settings in [Directory.Build.props](../../Directory.Build.props) and [Directory.Packages.props](../../Directory.Packages.props).
- **NuGet Packaging**: Ensure new files and resources are included in the NuGet package as appropriate.

## Example Tasks Copilot Should Be Able to Help With

- Add support for new NerdGraph query types (e.g., infrastructure monitoring, APM data queries).
- Extend the client to handle new mutation operations for managing NewRelic entities.
- Add or update selector interfaces/builders for new GraphQL fields.
- Add a test case for GraphQL error responses and ensure proper error mapping.
- Refactor shared logic in query builders into reusable base classes.
- Implement pagination support for large result sets from NerdGraph queries.
- Add support for GraphQL subscriptions if NewRelic introduces real-time capabilities.
- Create typed models for specific NewRelic data types (applications, alerts, dashboards).
- Add retry logic and exponential backoff for failed GraphQL requests.
- Update dependency injection to support additional configuration scenarios.

---

**Tips for Copilot:**
- Always use the correct namespace and folder for new files.
- Link to relevant files and symbols in your responses.
- When in doubt, follow the patterns established in `src/NewRelic.NerdGraph/`.
- Reference [Directory.Build.props](../../Directory.Build.props) for build and packaging settings.