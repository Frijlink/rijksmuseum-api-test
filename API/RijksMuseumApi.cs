using RijksmuseumApiTest.Contracts.Collection;
using RijksmuseumApiTest.Contracts.CollectionDetails;
using RijksmuseumApiTest.Contracts.CollectionDetails.XML;
using static RijksmuseumApiTest.Helpers.XmlHelper;

namespace RijksmuseumApiTest.API;

public class RijksMuseumApi : BaseApiConfig
{
    public static CollectionResponse GetCollection(
        string culture,
        List<KeyValuePair<string, object>>? extraParams = null
    )
    {
        var response = extraParams is null
            ? DefaultRequest(Key, $"{culture}/collection")
            : DefaultRequest(Key, $"{culture}/collection", extraParams);

        return response.FromJson<CollectionResponse>();
    }

    public static CollectionDetailsResponse GetCollectionDetails(
        string culture,
        string objectNumber,
        List<KeyValuePair<string, object>>? extraParams = null
    )
    {
        var response = extraParams is null
            ? DefaultRequest(Key, $"{culture}/collection/{objectNumber}")
            : DefaultRequest(Key, $"{culture}/collection/{objectNumber}", extraParams);

        return response.FromJson<CollectionDetailsResponse>();
    }

    public static CollectionDetailsXmlResponse GetCollectionDetailsAsXml(
        string culture,
        string objectNumber
    )
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("format", "xml"),
        };
        var response = DefaultRequest(Key, $"{culture}/collection/{objectNumber}", queryParams);

        return response.FromXml<CollectionDetailsXmlResponse>();;
    }
}
