using Newtonsoft.Json;

namespace practice_api.Extensions.Common;

public static class SerializationExtension
{
    public static T? Deserialize<T>(this string item) => JsonConvert.DeserializeObject<T>(item);
}