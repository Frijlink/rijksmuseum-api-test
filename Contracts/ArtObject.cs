using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts;

[Serializable()]
[XmlRoot(ElementName = "ArtObject")]
public class ArtObject
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

    [JsonPropertyName("principalOrFirstMaker")]
    [XmlElement("PrincipalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }

    [JsonPropertyName("language")]
    [XmlElement("Language")]
    public required string Language { get; set; }
}
