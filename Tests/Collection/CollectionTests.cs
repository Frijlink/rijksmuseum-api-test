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

        var collection = CollectionApi.GetCollection(culture, queryParams);

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

    // Locale has an influence on the returned results
    // On POSTMAN with locale 'nl' the main painting of the Gele Rijders is returned
    // While for locale 'en' a preliminary study of the painting is returned
    // [TestCase("nl", "Breitner Gele Rijders", "SK-A-1328"), Category("Collection")]
    [TestCase("en", "Breitner Gele Rijders", "RP-P-1882-A-6064"), Category("Collection")]
    public void UserCanRetrieveCollectionWithGeneralSearch(string culture, string searchTerm, string objectNumber)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("q", searchTerm.Replace(' ', '+')),
        };

        var collection = CollectionApi.GetCollection(culture, queryParams);

        collection.ArtObjects.First().ObjectNumber.Should().Be(objectNumber);
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

        var collection = CollectionApi.GetCollection(culture, queryParams);

        collection.ArtObjects.Count.Should().Be(expectedNumber);
    }

}
