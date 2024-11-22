using RestAssured.Logging;
using RestAssured.Request.Builders;

namespace RijksmuseumApiTest.API;

public class BaseApiConfig
{
    public static RequestSpecification GetRequestSpecifications(){
        var logConfig = new LogConfiguration {
            RequestLogLevel = RequestLogLevel.All,
            ResponseLogLevel = ResponseLogLevel.All,
        };

        return new RequestSpecBuilder()
            .WithBaseUri(BaseUrl)
            .WithBasePath("api")
            .WithTimeout(DefaultTimeOut)
            .WithLogConfiguration(logConfig)
            .Build();
    }
}