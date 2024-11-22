using static RijksmuseumApiTest.API.BaseApiConfig;

namespace RijksmuseumApiTest.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BadRequestTests
{
    [TestCase("collection"), Category("Collection")]
    [TestCase("collection/SK-A-1328"), Category("CollectionDetails")]
    [TestCase("collection/SK-A-1328/tiles"), Category("CollectionImage")]
    [TestCase("usersets"), Category("UserSets")]
    [TestCase("usersets/2525118-mijn-producten"), Category("UserSetsDetails")]
    public void ErrorIsReturnedWhenCultureIsMissing(string path)
    {
        DefaultRequest(Key, path, HttpStatusCode.NotFound);
    }

    [TestCase("en/collection"), Category("Collection")]
    [TestCase("en/collection/SK-A-1328"), Category("CollectionDetails")]
    [TestCase("en/collection/SK-A-1328/tiles"), Category("CollectionImage")]
    [TestCase("en/usersets"), Category("UserSets")]
    [TestCase("en/usersets/2525118-mijn-producten"), Category("UserSetsDetails")]
    public void ErrorIsReturnedWhenKeyIsMissing(string path)
    {
        Given()
            .Spec(GetRequestSpecifications())
            .When()
            .Get(path)
            .Then()
            .StatusCode(HttpStatusCode.Unauthorized);
    }

    [TestCase("en/collection"), Category("Collection")]
    [TestCase("en/collection/SK-A-1328"), Category("CollectionDetails")]
    [TestCase("en/collection/SK-A-1328/tiles"), Category("CollectionImage")]
    [TestCase("en/usersets"), Category("UserSets")]
    [TestCase("en/usersets/2525118-mijn-producten"), Category("UserSetsDetails")]
    public void ErrorIsReturnedWhenKeyIsWrong(string path)
    {
        DefaultRequest("WRONG_KEY", path, HttpStatusCode.Unauthorized);
    }
}
