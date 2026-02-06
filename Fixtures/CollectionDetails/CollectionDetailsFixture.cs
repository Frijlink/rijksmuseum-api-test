// using RijksmuseumApiTest.API;

// namespace RijksmuseumApiTest.Fixtures.CollectionDetails;

// [TestClass]
// public class CollectionDetailsFixture : BaseFixture
// {
//     [TestMethod]
//     [TestCategory("CollectionDetails")]
//     [DataRow("en", "SK-A-3580", "The Singel Bridge at the Paleisstraat in Amsterdam", "json"), ]
//     [DataRow("nl", "SK-A-3580", "De Singelbrug bij de Paleisstraat in Amsterdam", "json")]
//     [DataRow("en", "SK-A-3580", "The Singel Bridge at the Paleisstraat in Amsterdam", "xml")]
//     [DataRow("nl", "SK-A-3580", "De Singelbrug bij de Paleisstraat in Amsterdam", "xml")]
//     public void UserCanRetrieveCollectionDetailsByObjectNumber(string culture, string objectNumber, string expectedTitle, string format)
//     {
//         var objectId = $"{culture}-{objectNumber}";
//         var objResponse = format.Equals("json")
//             ? RijksMuseumApi.GetCollectionDetails(culture, objectNumber)
//             : RijksMuseumApi.GetCollectionDetailsAsXml(culture, objectNumber);

//         Assert.Multiple(() =>
//         {
//             objResponse.ArtObject.Id.Should().Be(objectId);
//             objResponse.ArtObject.Title.Should().Be(expectedTitle);
//             objResponse.ArtObject.Language.Should().Be(culture);

//             objResponse.ArtObjectPage.Id.Should().Be(objectId);
//             objResponse.ArtObjectPage.ObjectNumber.Should().Be(objectNumber);
//             objResponse.ArtObjectPage.Lang.Should().Be(culture);
//             objResponse.ArtObjectPage.PlaqueDescription.Should().NotBeNullOrEmpty();
//         });
//     }

//     [TestMethod]
//     [TestCategory("CollectionDetails")]
//     [DataRow("nl", "SK-X-358")]
//     public void EmptyResponseIsReturnedWhenObjectNumberIsIncorrect(string culture, string objectNumber)
//     {
//         var objResponse = RijksMuseumApi.GetCollectionDetails(culture, objectNumber);

//         Assert.Multiple(() =>
//         {
//             objResponse.ArtObject.Should().BeNull();
//             objResponse.ArtObjectPage.Should().BeNull();
//         });
//     }
// }
