using RijksmuseumApiTest.Utils;
using RijksmuseumApiTest.Models.Collection;
using RijksmuseumApiTest.Models.CollectionDetails;

namespace RijksmuseumApiTest.API;

public class RijksMuseumApi
{
    public static readonly HttpClient RIJKSMUSEUM_CLIENT = new () { BaseAddress = new("https://data.rijksmuseum.nl/search/collection") };

    public static async Task<CollectionResponse> GetCollection(IDictionary<string, object> extraParams, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var queryParams = UrlUtil.QueryString(extraParams);
        var response = await RIJKSMUSEUM_CLIENT.GetAsync($"?{queryParams}");
        Console.WriteLine(await HttpClientResponseUtil.HttpReport(response));
        await HttpClientResponseUtil.CheckStatusCode(response, expectedStatusCode);

        return await response.Content.ReadFromJsonAsync<CollectionResponse>();
    }

    // public static CollectionDetailsResponse GetCollectionDetails(
    //     string culture,
    //     string objectNumber,
    //     List<KeyValuePair<string, object>>? extraParams = null
    // )
    // {
    //     var response = extraParams is null
    //         ? DefaultRequest(Key, $"{culture}/collection/{objectNumber}")
    //         : DefaultRequest(Key, $"{culture}/collection/{objectNumber}", extraParams);

    //     return response.FromJson<CollectionDetailsResponse>();
    // }

    // public static CollectionDetailsResponse GetCollectionDetailsAsXml(
    //     string culture,
    //     string objectNumber
    // )
    // {
    //     var queryParams = new List<KeyValuePair<string, object>>
    //     {
    //         new("format", "xml"),
    //     };
    //     var response = DefaultRequest(Key, $"{culture}/collection/{objectNumber}", queryParams);

    //     return response.FromXml<CollectionDetailsResponse>();;
    // }
}
