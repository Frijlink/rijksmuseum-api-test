namespace RijksmuseumApiTest.Utils;

public static class UrlUtil
{
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