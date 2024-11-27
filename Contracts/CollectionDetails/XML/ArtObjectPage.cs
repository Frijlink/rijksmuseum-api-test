using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails.XML;

[Serializable()]
[XmlRoot(ElementName = "ArtObjectPage")]
public class ArtObjectPage
{
    [XmlElement("Id")]
    public required string Id { get; set; }

    [XmlElement("ObjectNumber")]
    public required string ObjectNumber { get; set; }

    [XmlElement("Title")]
    public required string Title { get; set; }

    [XmlElement("Lang")]
    public required string Lang { get; set; }

    [XmlElement("PlaqueDescription")]
    public required string PlaqueDescription { get; set; }

    [XmlElement("PrincipalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }
}