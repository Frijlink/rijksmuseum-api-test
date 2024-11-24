using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails;

public class ArtObjectPage
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("objectNumber")]
    public required string ObjectNumber { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("lang")]
    public required string Lang { get; set; }

    [JsonPropertyName("plaqueDescription")]
    public required string PlaqueDescription { get; set; }

    [JsonPropertyName("principalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }
}
