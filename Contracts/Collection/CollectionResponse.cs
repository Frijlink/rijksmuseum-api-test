using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.Collection;

public class CollectionResponse
{
    [JsonPropertyName("elapsedMilliseconds")]
    public required int ElapsedMilliseconds { get; set; }

    [JsonPropertyName("count")]
    public required int Count { get; set; }

    [JsonPropertyName("countFacets")]
    public required CountFacet CountFacets { get; set; }

    [JsonPropertyName("artObjects")]
    public required List<ArtObject> ArtObjects { get; set; }

    // TODO: add facets as well
    // [JsonPropertyName("facets")]
    // public required List<Facets> FacetsList { get; set; }

}
