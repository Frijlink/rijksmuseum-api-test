using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails.XML;

[Serializable()]
[XmlRoot(ElementName = "ArtObject")]
public class ArtObject
{
    [XmlElement("Id")]
    public required string Id { get; set; }

    [XmlElement("ObjectNumber")]
    public required string ObjectNumber { get; set; }

    [XmlElement("Title")]
    public required string Title { get; set; }

    [XmlElement("PrincipalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }

    [XmlElement("Language")]
    public required string Language { get; set; }
}