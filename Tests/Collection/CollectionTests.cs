using FluentAssertions;
using RijksmuseumApiTest.API;

namespace RijksmuseumApiTest.Tests.Collection;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CollectionTests
{
    private static readonly int NumberOfResults = 50;

    // hardcoded the expected count. I don't expect the Rijks to add a new Breitner to their collection soon
    [TestCase("en", "George Hendrik Breitner", 5602), Category("Collection")]
    [TestCase("en", "Breitner", 0), Category("Collection")]
    public void UserCanRetrieveCollectionWithMaker(string culture, string involvedMaker, int expectedCount)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("involvedMaker", involvedMaker),
            new("ps", NumberOfResults),
        };

        var collection = RijksMuseumApi.GetCollection(culture, queryParams);

        Assert.Multiple(() =>
        {
            collection.Count.Should().Be(expectedCount);
            if (expectedCount > 0)
            {
                collection.ArtObjects.Count.Should().Be(NumberOfResults);
                collection.ArtObjects.First().PrincipalOrFirstMaker.Should().Be(involvedMaker);
                collection.ArtObjects.Last().PrincipalOrFirstMaker.Should().Be(involvedMaker);
            };
        });
    }

    // Locale might have an influence on the returned results
    // url encoding has an influence on the returned results
    // API expects '+' instead of search term in search
    // While RestAssured.Net encodes this to '%2B'
    [TestCase("nl", "Breitner Gele Rijders", "RP-D-2017-40"), Category("Collection")]
    [TestCase("en", "Breitner Gele Rijders", "RP-T-1948-602"), Category("Collection")]
    [TestCase("en", "Naatje", "RP-T-1950-222(R)"), Category("Collection")]
    public void UserCanRetrieveCollectionWithGeneralSearch(string culture, string searchTerm, string firstObjectNumber)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("q", searchTerm.Replace(' ', '+')),
            new("s", "artist"),
        };

        var collection = RijksMuseumApi.GetCollection(culture, queryParams);

        collection.ArtObjects.First().ObjectNumber.Should().Be(firstObjectNumber);
    }

    // when locale is changed type of object should also change. I.E. painting vs schilderij
    // also, this is case sensitive
    [TestCase("nl", "schilderij", 50), Category("Collection")]
    [TestCase("nl", "painting", 0), Category("Collection")]
    [TestCase("en", "painting", 50), Category("Collection")]
    [TestCase("en", "Painting", 0), Category("Collection")]
    [TestCase("en", "schilderij", 0), Category("Collection")]
    public void UserCanRetrieveCollectionByType(string culture, string searchTerm, int expectedNumber)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("type", searchTerm.Replace(' ', '+')),
            new("ps", NumberOfResults),
        };

        var collection = RijksMuseumApi.GetCollection(culture, queryParams);

        collection.ArtObjects.Count.Should().Be(expectedNumber);
    }

}
