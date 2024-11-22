using RestAssured.Request.Builders;

namespace RijksmuseumApiTest.Settings;

public class TestVariables
{
    public static string BaseUrl { get; set; } = string.Empty;
    public static string Key { get; set; } = string.Empty;
    public static TimeSpan DefaultTimeOut { get; } = TimeSpan.FromSeconds(30);
}