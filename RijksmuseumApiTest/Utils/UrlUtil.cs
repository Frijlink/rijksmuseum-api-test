namespace RijksmuseumApiTest.Utils;

public static class UrlUtil
{
    // TODO: Values are concatenated raw without URL-encoding. Params containing spaces or
    //       reserved characters (e.g. "George Hendrik Breitner") produce malformed query
    //       strings. Encode both key and value with Uri.EscapeDataString().
    // TODO: IDictionary cannot hold duplicate keys, but the Rijksmuseum API supports repeated
    //       params (technique, material, aboutActor). Consider accepting
    //       IEnumerable<KeyValuePair<string, object>> so multi-value filters can be tested.
    // TODO: Simplify with LINQ: string.Join("&", queryParams.Select(p => $"{Encode(p.Key)}={Encode(p.Value)}")).
    // TODO: null values will render as "key=" — decide whether to skip or reject them.
    public static string QueryString(IDictionary<string, object> queryParams)
    {
        var list = new List<string>();
        foreach (var item in queryParams)
        {
            list.Add(item.Key + "=" + item.Value);
        }
        return string.Join("&", list);
    }
}