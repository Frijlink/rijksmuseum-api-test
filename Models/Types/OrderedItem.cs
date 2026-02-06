namespace RijksmuseumApiTest.Models.Types;

public class OrderedItem
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }
}