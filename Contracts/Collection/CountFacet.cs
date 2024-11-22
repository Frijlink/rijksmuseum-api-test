using System.Text.Json.Serialization;

namespace RijksmuseumApiTest.Contracts.Collection;

public class CountFacet
{
    [JsonPropertyName("hasimage")]
    public required int HasImage { get; set; }

    [JsonPropertyName("ondisplay")]
    public required int OnDisplay { get; set; }

}
