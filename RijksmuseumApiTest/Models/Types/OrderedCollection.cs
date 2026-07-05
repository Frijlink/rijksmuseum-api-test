namespace RijksmuseumApiTest.Models.Types;

public class OrderedCollection
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("totalItems")]
    public required int TotalItems { get; set; }

    [JsonPropertyName("first")]
    public required OrderedItem First { get; set; }

    [JsonPropertyName("last")]
    public required OrderedItem Last { get; set; }
}