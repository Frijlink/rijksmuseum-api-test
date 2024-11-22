using static RijksmuseumApiTest.Settings.Configuration;

namespace RijksmuseumApiTest.Tests;

[SetUpFixture]
public class OneTimeSetup
{
    [OneTimeSetUp]
    public void RetrieveEnvironmentVariables()
    {
        BaseUrl = GetEnvironmentVariable("RIJKSMUSEUM_URL");
        Key = GetEnvironmentVariable("RIJKSMUSEUM_KEY");
    }
}