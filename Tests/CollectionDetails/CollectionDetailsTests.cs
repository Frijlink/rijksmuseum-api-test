using FluentAssertions;
using RijksmuseumApiTest.API;

namespace RijksmuseumApiTest.Tests.CollectionDetails;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CollectionDetailsTests
{
    [TestCase("en", "SK-A-3580", "The Singel Bridge at the Paleisstraat in Amsterdam"), Category("CollectionDetails")]
    [TestCase("nl", "SK-A-3580", "De Singelbrug bij de Paleisstraat in Amsterdam"), Category("CollectionDetails")]
    public void UserCanRetrieveCollectionDetailsByObjectNumber(string culture, string objectNumber, string expectedTitle)
    {
        var objectId = $"{culture}-{objectNumber}";
        var objResponse = RijksMuseumApi.GetCollectionDetails(culture, objectNumber);

        Assert.Multiple(() =>
        {
            objResponse.ArtObject.Id.Should().Be(objectId);
            objResponse.ArtObject.Title.Should().Be(expectedTitle);
            objResponse.ArtObject.Language.Should().Be(culture);

            objResponse.ArtObjectPage.Id.Should().Be(objectId);
            objResponse.ArtObjectPage.ObjectNumber.Should().Be(objectNumber);
            objResponse.ArtObjectPage.Lang.Should().Be(culture);
            objResponse.ArtObjectPage.PlaqueDescription.Should().NotBeNullOrEmpty();
        });
    }

    [TestCase("nl", "SK-X-358"), Category("CollectionDetails")]
    public void UserCanRetrieveCollectionDetailsAsXml(string culture, string objectNumber)
    {
        var queryParams = new List<KeyValuePair<string, object>>
        {
            new("format", "xml"),
        };
        var objResponse = RijksMuseumApi.GetCollectionDetailsAsXml(culture, objectNumber, queryParams);

        objResponse.Should().StartWith("<artObjectGetResponse>");
    }

    [TestCase("nl", "SK-X-358"), Category("CollectionDetails")]
    public void EmptyResponseIsReturnedWhenObjectNumberIsIncorrect(string culture, string objectNumber)
    {
        var objResponse = RijksMuseumApi.GetCollectionDetails(culture, objectNumber);

        Assert.Multiple(() =>
        {
            objResponse.ArtObject.Should().BeNull();
            objResponse.ArtObjectPage.Should().BeNull();
        });
    }
}
