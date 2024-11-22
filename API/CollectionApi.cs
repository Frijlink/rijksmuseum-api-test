using RijksmuseumApiTest.Contracts.Collection;

namespace RijksmuseumApiTest.API;

public class CollectionApi : BaseApiConfig
{
    public static CollectionResponse GetCollection(
        string culture,
        List<KeyValuePair<string, object>>? extraParams
    )
    {
        var defaultParams = new List<KeyValuePair<string, object>> { new("key", Key) };
        if (extraParams is not null)
        {
            defaultParams.AddRange(extraParams);
        }

        return (CollectionResponse)Given()
            .Spec(GetRequestSpecifications())
            .QueryParams(defaultParams)
            .When()
            .Get($"{culture}/collection")
            .Then()
            .StatusCode(HttpStatusCode.OK)
            .DeserializeTo(typeof(CollectionResponse));
    }
}
