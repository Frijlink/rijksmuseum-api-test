using Newtonsoft.Json;
using RijksmuseumApiTest.Contracts.Collection;

namespace RijksmuseumApiTest.API;

public class CollectionApi : BaseApiConfig
{
    public static CollectionResponse GetCollection(
        string culture,
        List<KeyValuePair<string, object>>? extraParams
    )
    {
        var response = extraParams is null
            ? DefaultRequest(Key, $"{culture}/collection", HttpStatusCode.OK)
            : DefaultRequest(Key, $"{culture}/collection", extraParams, HttpStatusCode.OK);

        return JsonConvert.DeserializeObject<CollectionResponse>(response);
    }
}
