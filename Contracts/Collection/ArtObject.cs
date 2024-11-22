using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.Collection;

public class ArtObject
{
    [JsonPropertyName("objectNumber")]
    public required string ObjectNumber { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("principalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }
}
