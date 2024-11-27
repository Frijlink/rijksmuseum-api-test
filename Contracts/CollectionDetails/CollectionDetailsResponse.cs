using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.CollectionDetails;

public class CollectionDetailsResponse
{
    [JsonPropertyName("elapsedMilliseconds")]
    public required int ElapsedMilliseconds { get; set; }

    [JsonPropertyName("artObject")]
    public required ArtObject ArtObject { get; set; }

    [JsonPropertyName("artObjectPage")]
    public required ArtObjectPage ArtObjectPage { get; set; }
}
