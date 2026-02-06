using RijksmuseumApiTest.Models.Collection;
using RijksmuseumApiTest.Utils;

namespace RijksmuseumApiTest.Fixtures.Search;

[TestClass]
public class SearchFixture : BaseFixture
{
    /*
    type            str     Search for types of objects, such as painting.
    technique       str     Search for objects created with a technique, such as embroidering. Can be duplicated to search for multiple techniques used on the same objects.
    material        str     Search for objects that consist of a material, such as canvas. Can be duplicated to search for objects that consist of multiple materials.
    aboutActor      str     Search for objects that depict or are about a person or group, by name. Can be duplicated to search for objects about multiple persons/groups.
    imageAvailable  bool    Search for objects with or without an available digital reproduction
    */

    // hardcoded the expected count. I don't expect the Rijks to add a new Breitner to their collection soon
    [TestMethod]
    [TestCategory("Search")]
    [DataRow("creator", "George Hendrik Breitner", 5008, 100)]
    [DataRow("creator", "Breitner", 5009, 100)]
    [DataRow("creator", "asdfghj", 0, 0)]
    [DataRow("title", "De Gele Rijders", 4, 4)]
    [DataRow("objectNumber", "SK-A-1328", 1, 1)]
    [DataRow("objectNumber", "SK-A-132*", 11, 11)] // with wildcard
    [DataRow("creationDate", "1885", 8349, 100)]
    [DataRow("creationDate", "188?", 7388, 100)] // with wildcard
    [DataRow("description", "In vliegende vaart rijdt het elitekorps van De Gele Rijders van het duin af.", 1, 1)]
    public async Task UserCanSearchCollectionWithSingleQueryParam(string queryParam, string value, int expectedItems, int expectedPageResults)
    {
        var queryParams = new Dictionary<string, object>
        {
            { queryParam, value }
        };

        var response = await GetCollection(queryParams);
        var collection = await HttpClientResponseUtil.CheckStatusCode<SearchResponse>(response, HttpStatusCode.OK);

        Assert.AreEqual(expectedItems, collection.PartOf.TotalItems);
        Assert.HasCount(expectedPageResults, collection.OrderedItems);

        if (expectedItems > expectedPageResults)
        {
            Assert.IsNotNull(collection.Next);
        }
    }

    [TestMethod]
    [TestCategory("Search")]

    [TestMethod]
    [TestCategory("Search")]
    public async Task UserCannotSearchWithIncorrectQueryParam()
    {
        var queryParams = new Dictionary<string, object>
        {
            { "test", "test" }
        };

        var response = await GetCollection(queryParams);
        await HttpClientResponseUtil.CheckStatusCode<SearchResponse>(response, HttpStatusCode.BadRequest);
    }


}
