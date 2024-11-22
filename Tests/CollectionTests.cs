using FluentAssertions;
using static RijksmuseumApiTest.API.CollectionApi;

namespace RijksmuseumApiTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CollectionTests
{

    [TestCase("en", "involvedMaker", "George Hendrik Breitner"), Category("Collection")]
    public void UserCanRetrieveCollectionWithSearchParam(string culture, string key, string searchParam)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new(key, searchParam.Replace(' ', '+')),
        };

        var collection = GetCollection(culture, queryParams);

        collection.Should().NotBeNull();
    }
}
