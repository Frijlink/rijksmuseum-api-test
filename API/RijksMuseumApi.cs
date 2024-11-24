using Newtonsoft.Json;
using RijksmuseumApiTest.Contracts.Collection;
using RijksmuseumApiTest.Contracts.CollectionDetails;

namespace RijksmuseumApiTest.API;

public class RijksMuseumApi : BaseApiConfig
{
    public static CollectionResponse GetCollection(
        string culture,
        List<KeyValuePair<string, object>>? extraParams = null
    )
    {
        var response = extraParams is null
            ? DefaultRequest(Key, $"{culture}/collection", HttpStatusCode.OK)
            : DefaultRequest(Key, $"{culture}/collection", extraParams, HttpStatusCode.OK);

        return JsonConvert.DeserializeObject<CollectionResponse>(response);
    }

    public static CollectionDetailsResponse GetCollectionDetails(
        string culture,
        string objectNumber,
        List<KeyValuePair<string, object>>? extraParams = null
    )
    {
        var response = extraParams is null
            ? DefaultRequest(Key, $"{culture}/collection/{objectNumber}", HttpStatusCode.OK)
            : DefaultRequest(Key, $"{culture}/collection/{objectNumber}", extraParams, HttpStatusCode.OK);

        return JsonConvert.DeserializeObject<CollectionDetailsResponse>(response);
    }

    public static string GetCollectionDetailsAsXml(
        string culture,
        string objectNumber,
        List<KeyValuePair<string, object>> extraParams
    ) => DefaultRequest(Key, $"{culture}/collection/{objectNumber}", extraParams, HttpStatusCode.OK);
}
