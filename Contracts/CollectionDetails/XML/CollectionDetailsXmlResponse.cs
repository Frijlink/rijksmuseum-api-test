using System.Xml.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails.XML;

[Serializable()]
[XmlRoot(ElementName = "artObjectGetResponse")]
public class CollectionDetailsXmlResponse
{
    [XmlElement("ElapsedMilliseconds")]
    public required int ElapsedMilliseconds { get; set; }

    [XmlElement(typeof(ArtObject))]
    public required ArtObject ArtObject { get; set; }

    [XmlElement(typeof(ArtObjectPage))]
    public required ArtObjectPage ArtObjectPage { get; set; }
}
