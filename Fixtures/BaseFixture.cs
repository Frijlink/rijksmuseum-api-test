namespace RijksmuseumApiTest.Fixtures;

[TestClass]
public class BaseFixture
{
    public static readonly HttpClient RIJKSMUSEUM_CLIENT = new () { BaseAddress = new("https://data.rijksmuseum.nl/search/collection") };

    [AssemblyInitialize]
    public static void AssemblyInitialze(TestContext testContext)
    {
        // magic will come here
    }
}