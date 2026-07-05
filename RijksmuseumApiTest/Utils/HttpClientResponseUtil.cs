using HttpClientToCurl.Extensions;

namespace RijksmuseumApiTest.Utils;

public static class HttpClientResponseUtil
{
    // TODO: This method violates SRP — it both asserts the status code AND deserializes the body.
    //       Consider splitting into an assertion helper and a separate ReadAs<T>() so tests can
    //       assert status without forcing a deserialization, and vice versa.
    public static async Task<T> CheckStatusCode<T>(HttpResponseMessage response, HttpStatusCode statusCode)
    {
        // TODO: Arguments are swapped. Assert.AreEqual convention is (expected, actual); here
        //       'statusCode' is the expected value and should come first, otherwise the framework's
        //       default failure message reports expected/actual backwards.
        // TODO: The try/catch-and-rethrow is redundant. Assert.AreEqual has a 'message' overload —
        //       pass the HttpReport there instead of wrapping in an AssertFailedException.
        //       Also: HttpReport is only awaited on failure here, good, but the catch swallows the
        //       original exception type; prefer the message overload to keep the stack intact.
        try
        {
            Assert.AreEqual(response.StatusCode, statusCode);
        }
        catch (Exception)
        {
            throw new AssertFailedException($"response.StatusCode was {response.StatusCode} instead of expected {statusCode}\n{await HttpReport(response)}");
        }

        // TODO: Returns default (null) for non-success responses, but callers dereference the result
        //       (e.g. collection.PartOf) — the CS8603/CS8602 warnings are suppressed in the csproj,
        //       masking a real NullReferenceException risk. Make the return type nullable (T?) or
        //       throw when a body was expected but the response was unsuccessful.
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<T>()
            : default;
    }

    // TODO: Typo in parameter name 'respone' -> 'response'.
    public static async Task<string> HttpReport(HttpResponseMessage respone)
    {
        return $"REQUEST:\n{GenerateCurlInString(respone)}\nRESPONSE:\nSTATUSCODE: {respone.StatusCode}\nCONTENT: {await respone.Content.ReadAsStringAsync()}";
    }

    public static string GenerateCurlInString(HttpResponseMessage response)
    {
        // TODO: BUILD BREAK — 'curlCommand' is undeclared (CS0103). This is a leftover assignment;
        //       just `return tempClient.GenerateCurlInString(...)`. The project currently does not compile.
        // TODO: response.RequestMessage can be null after the response is consumed/disposed;
        //       guard against null to avoid an NRE while generating the debug curl.
        using var tempClient = new HttpClient();
        return tempClient.GenerateCurlInString(
            response.RequestMessage,
            config =>
            {
                config.TurnOn = true;
                config.NeedAddDefaultHeaders = false;
            }
        );
    }
}