# Rijksmuseum API Test

Framework in .NET using NUnit and [RestAssured.Net](https://github.com/basdijkstra/rest-assured-net) to test the [Rijksmuseum Data Services](https://data.rijksmuseum.nl/docs/).

## How to run the tests ##

### Environment Variables ###

| key             | value                        |
|-----------------|------------------------------|
| RIJKSMUSEUM_URL |"https://www.rijksmuseum.nl/" |
| RIJKSMUSEUM_KEY |                              |

### Locally ###

Set the Environment Variables on your machine and run the tests with the following commands:

* Run all the tests with `dotnet test`
* Run a single test with `dotnet test --filter "UserCanRetrieveCollectionWithMaker"`
* Run a single category with `dotnet test --filter TestCategory=Collection`

### CI/CD ###

Navigate to https://github.com/Frijlink/rijksmuseum-api-test/actions/workflows/rijksmuseum-pipeline.yml and trigger the pipeline by clicking `Run workflow -> Run workflow`

## TODO LIST ##

- Investigate behaviour on UserCanRetrieveCollectionWithGeneralSearch where the api does not return the same response on RestAssured as it does on Postman
- Add tests for UserSets and UserSetDetails
