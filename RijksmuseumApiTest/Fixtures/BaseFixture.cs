using Microsoft.Extensions.Configuration;
using RijksmuseumApiTest.Utils;

namespace RijksmuseumApiTest.Fixtures;

[TestClass]
public class BaseFixture
{
    // TODO: BaseAddress ".../search/collection" has no trailing slash. Relative resolution only works
    //       because every call starts with "?"; a relative path segment would be dropped. Be explicit.
    public static HttpClient RijksmuseumClient { get; private set; } = new();

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.local.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var baseUrl = config["RijksmuseumApi:BaseUrl"]
            ?? throw new InvalidOperationException("RijksmuseumApi:BaseUrl is not configured.");

        var timeoutSeconds = config.GetValue("RijksmuseumApi:TimeoutSeconds", 30);

        RijksmuseumClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(timeoutSeconds)
        };
    }

    // TODO: Add an overload accepting a CancellationToken (from TestContext.CancellationTokenSource)
    //       so tests honour run cancellation/timeouts.
    public static async Task<HttpResponseMessage> GetCollection(IDictionary<string, object> extraParams)
    {
        var queryParams = UrlUtil.QueryString(extraParams);
        return await RijksmuseumClient.GetAsync($"?{queryParams}");
    }
}
