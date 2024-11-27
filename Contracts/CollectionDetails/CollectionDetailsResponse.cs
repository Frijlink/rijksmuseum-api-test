using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails;

[Serializable()]
[XmlRoot(ElementName = "artObjectGetResponse")]
public class CollectionDetailsResponse
{
    [JsonPropertyName("elapsedMilliseconds")]
    [XmlElement("ElapsedMilliseconds")]
    public required int ElapsedMilliseconds { get; set; }

    [JsonPropertyName("artObject")]
    [XmlElement(typeof(ArtObject))]
    public required ArtObject ArtObject { get; set; }

    [JsonPropertyName("artObjectPage")]
    [XmlElement(typeof(ArtObjectPage))]
    public required ArtObjectPage ArtObjectPage { get; set; }
}
