using RestAssured.Logging;
using RestAssured.Request.Builders;
using static System.Net.HttpStatusCode;

namespace RijksmuseumApiTest.API;

public class BaseApiConfig
{
    public static RequestSpecification GetRequestSpecifications(){
        var logConfig = new LogConfiguration {
            RequestLogLevel = RequestLogLevel.All,
            ResponseLogLevel = ResponseLogLevel.OnVerificationFailure,
        };

        return new RequestSpecBuilder()
            .WithBaseUri(BaseUrl)
            .WithBasePath("api")
            .WithTimeout(DefaultTimeOut)
            .WithLogConfiguration(logConfig)
            .Build();
    }

    public static string DefaultRequest(string key, string path, HttpStatusCode expectedHttpResponse = OK) =>
        Given()
            .Spec(GetRequestSpecifications())
            .QueryParam("key", key)
            .When()
            .Get(path)
            .Then()
            .StatusCode(expectedHttpResponse)
            .Extract().Body();

    public static string DefaultRequest(string key, string path, List<KeyValuePair<string, object>> extraParams, HttpStatusCode expectedHttpResponse = OK) =>
        Given()
            .Spec(GetRequestSpecifications())
            .QueryParam("key", key)
            .QueryParams(extraParams)
            .When()
            .Get(path)
            .Then()
            .StatusCode(expectedHttpResponse)
            .Extract().Body();
}