using RestSharp;

namespace practice_api.Extensions.Common;

public static class RestClientConfigurationExtension
{
    public static RestClient ConfigureClient(this RestClient client, string url)
    {
        client.Options.BaseUrl = new Uri(url);
        client.Options.MaxTimeout = -1;

        return client;
    }
}