using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts;

public class ArtObject
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("objectNumber")]
    public required string ObjectNumber { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("principalOrFirstMaker")]
    public required string PrincipalOrFirstMaker { get; set; }

    [JsonPropertyName("language")]
    public required string Language { get; set; }
}
