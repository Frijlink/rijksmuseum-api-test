using HttpClientToCurl.Extensions;

namespace RijksmuseumApiTest.Utils;

public static class HttpClientResponseUtil
{
    public static async Task<T> CheckStatusCode<T>(HttpResponseMessage response, HttpStatusCode statusCode)
    {
        try
        {
            Assert.AreEqual(response.StatusCode, statusCode);
        }
        catch (Exception)
        {
            throw new AssertFailedException($"response.StatusCode was {response.StatusCode} instead of expected {statusCode}\n{await HttpReport(response)}");
        }

        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<T>()
            : default;
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