using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RijksmuseumApiTest.Helpers;

public static class XmlHelper
{
    public static T FromJson<T>(this string value) =>
        JsonConvert.DeserializeObject<T>(value);

    public static T FromXml<T>(this string value)
    {
        using TextReader reader = new StringReader(value);
        return (T) new XmlSerializer(typeof(T)).Deserialize(reader);
    }
}