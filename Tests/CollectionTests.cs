using FluentAssertions;
using RijksmuseumApiTest.API;

namespace RijksmuseumApiTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CollectionTests
{
    private static readonly int NumberOfResults = 50;

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
}
