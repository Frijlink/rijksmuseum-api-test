# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Integration test framework in .NET 10 (MSTest + HttpClient) that tests the live [Rijksmuseum Search API](https://data.rijksmuseum.nl/docs/search). Tests hit the real external API — there is no mocking or in-memory server.

## Commands

```bash
# Run all tests
dotnet test

# Run a single test by name
dotnet test --filter "UserCanRetrieveCollectionWithMaker"

# Run a single category
dotnet test --filter TestCategory=Search

# Build without running tests
dotnet build RijksmuseumApiTest.csproj
```

The CI pipeline (manually triggered via GitHub Actions) runs `dotnet restore`, `dotnet build`, then `dotnet test` against the real API.

## Architecture

```
Fixtures/          # Test classes (MSTest [TestClass])
  BaseFixture.cs   # Shared HttpClient + GetCollection() helper
  Search/          # Test classes per API area
Models/            # DTOs for deserializing API responses (System.Text.Json)
  Search/
  Types/
Utils/
  HttpClientResponseUtil.cs  # CheckStatusCode<T>() assertion + curl debug output
  UrlUtil.cs                 # QueryString() — converts dict to query params
```

**Key pattern:** All fixtures inherit from `BaseFixture`, which provides a static `HttpClient` pointed at the Rijksmuseum Search API base URL and a `GetCollection(IDictionary<string, object> extraParams)` async helper. Tests use `[DataRow]` for parameterized cases and `[TestCategory]` for grouping.

**Response deserialization:** `HttpClientResponseUtil.CheckStatusCode<T>()` asserts the expected HTTP status and deserializes the response body into the given type. It also generates a curl command for debugging failures.

## Adding New Tests

When asked to write tests, use the `api-test-writer` agent (`.claude/agents/api-test-writer.md`) — it knows the project conventions in detail.

New test classes go under `Fixtures/<AreaName>/`, inherit from `BaseFixture`, and follow the naming pattern `UserCan<Action><Subject>` for test methods.

## Open Items (from README)

- `UserCanRetrieveCollectionWithGeneralSearch` — API returns different responses than expected; under investigation
- Tests for UserSets and UserSetDetails endpoints are not yet implemented
