using RijksmuseumApiTest.Models.Types;

namespace RijksmuseumApiTest.Models.Collection;

// TODO: 'required' on deserialized DTOs makes System.Text.Json throw if any field is absent from the
//       response. That couples every test to the full contract — a partial/edge-case response fails
//       during deserialization rather than at a meaningful assertion. Consider dropping 'required' on
//       non-essential fields (or use a JsonSerializerOptions with a clear error) and asserting presence
//       explicitly where it matters.
// TODO: Namespace is 'Models.Collection' but the file lives under Models/Search — align the folder and
//       namespace to avoid confusion.
// TODO: These DTOs are only used for deserialization; consider making them immutable records with
//       init-only/positional properties instead of mutable classes with get/set.
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
