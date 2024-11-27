using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails;

[Serializable()]
[XmlRoot(ElementName = "ArtObjectPage")]
public class ArtObjectPage
{
    [JsonPropertyName("id")]
    [XmlElement("Id")]
    public required string Id { get; set; }

    [JsonPropertyName("objectNumber")]
    [XmlElement("ObjectNumber")]
    public required string ObjectNumber { get; set; }

    [JsonPropertyName("title")]
    [XmlElement("Title")]
    public required string Title { get; set; }

    [JsonPropertyName("lang")]
    [XmlElement("Lang")]
    public required string Lang { get; set; }

    [JsonPropertyName("plaqueDescription")]
    [XmlElement("PlaqueDescription")]
    public required string PlaqueDescription { get; set; }

    [JsonPropertyName("principalOrFirstMaker")]
    [XmlElement("PrincipalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }
}
