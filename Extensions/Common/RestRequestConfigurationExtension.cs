using RestSharp;

namespace practice_api.Extensions.Common;

public static class RestRequestConfigurationExtension
{
    public static RestRequest ConfigureRequest(this RestRequest request, Method method)
    {
        request.Method = method;
        request.AddHeader("apikey", "R7aijdlR8o0H3J2NsoPTfEAQgXRjlhT6");
        
        return request;
    }
}