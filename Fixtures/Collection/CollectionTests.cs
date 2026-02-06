using RijksmuseumApiTest.API;

namespace RijksmuseumApiTest.Fixtures.Collection;

[TestClass]
public class CollectionTests : BaseFixture
{
    private static readonly int NumberOfResults = 50;

    // hardcoded the expected count. I don't expect the Rijks to add a new Breitner to their collection soon
    [TestMethod]
    [TestCategory("Collection")]
    [DataRow("George Hendrik Breitner", 5605)]
    [DataRow("Breitner", 0)]
    public async Task UserCanRetrieveCollectionWithMaker(string involvedMaker, int expectedCount)
    {
        var queryParams = new Dictionary<string, object>
        {
            { "creator", involvedMaker }
        };

        var collection = await RijksMuseumApi.GetCollection(queryParams);

        Assert.AreEqual(expectedCount, collection.Count);
    }

    // // Locale might have an influence on the returned results
    // // url encoding has an influence on the returned results
    // // API expects '+' instead of search term in search
    // // While RestAssured.Net encodes this to '%2B'
    // [TestMethod]
    // [TestCategory("Collection")]
    // [DataRow("nl", "Breitner Gele Rijders", "RP-D-2017-40")]
    // [DataRow("en", "Breitner Gele Rijders", "RP-T-1948-604")]
    // [DataRow("en", "Naatje", "RP-T-1950-222(R)")]
    // public void UserCanRetrieveCollectionWithGeneralSearch(string culture, string searchTerm, string firstObjectNumber)
    // {
    //     var queryParams = new List<KeyValuePair<string, object>>
    //     {
    //         new("q", searchTerm.Replace(' ', '+')),
    //         new("s", "artist"),
    //     };

    //     var collection = RijksMuseumApi.GetCollection(culture, queryParams);

    //     collection.ArtObjects.First().ObjectNumber.Should().Be(firstObjectNumber);
    // }

    // // when locale is changed type of object should also change. I.E. painting vs schilderij
    // // also, this is case sensitive
    // [TestMethod]
    // [TestCategory("Collection")]
    // [DataRow("nl", "schilderij", 50)]
    // [DataRow("nl", "painting", 0)]
    // [DataRow("en", "painting", 50)]
    // [DataRow("en", "Painting", 0)]
    // [DataRow("en", "schilderij", 0)]
    // public void UserCanRetrieveCollectionByType(string culture, string searchTerm, int expectedNumber)
    // {
    //     var queryParams = new List<KeyValuePair<string, object>>
    //     {
    //         new("type", searchTerm.Replace(' ', '+')),
    //         new("ps", NumberOfResults),
    //     };

    //     var collection = RijksMuseumApi.GetCollection(culture, queryParams);

    //     collection.ArtObjects.Count.Should().Be(expectedNumber);
    // }

}
