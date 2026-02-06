using HttpClientToCurl.Extensions;

namespace RijksmuseumApiTest.Utils;

public static class HttpClientResponseUtil
{
    public static async Task CheckStatusCode(HttpResponseMessage response, HttpStatusCode statusCode)
    {
        Assert.AreEqual(response.StatusCode, statusCode, await HttpReport(response));
    }

    public static async Task<string> HttpReport(HttpResponseMessage respone)
    {
        return $"REQUEST:\n{GenerateCurlInString(respone)}\nRESPONSE:\nSTATUSCODE: {respone.StatusCode}\nCONTENT: {await respone.Content.ReadAsStringAsync()}";
    }

    public static string GenerateCurlInString(HttpResponseMessage response)
    {
        var tempClient = new HttpClient();
        var curlCommand = tempClient.GenerateCurlInString(
            response.RequestMessage,
            config =>
            {
                config.TurnOn = true;
                config.NeedAddDefaultHeaders = false;
            }
        );

        return curlCommand;
    }
}