using RijksmuseumApiTest.Models.Types;

namespace RijksmuseumApiTest.Models.Collection;

public class SearchResponse
{
    [JsonPropertyName("@context")]
    public required string Context { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("partOf")]
    public required OrderedCollection PartOf { get; set; }

    [JsonPropertyName("next")]
    public OrderedItem? Next { get; set; }

    [JsonPropertyName("orderedItems")]
    public required List<OrderedItem> OrderedItems { get; set; }
}
