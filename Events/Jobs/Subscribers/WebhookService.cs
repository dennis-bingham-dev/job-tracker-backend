using Newtonsoft.Json;
using practice_api.Events.Jobs.Args;
using practice_api.Events.Jobs.Subscribers.Interfaces;
using RestSharp;

namespace practice_api.Events.Jobs.Subscribers;

public class WebhookService : IJobSubscriber
{
    private const string url = "https://webhook.site/6418efd5-da8d-4b02-a32d-2e80c93bd7b8";
    private RestClient _restClient;
    private readonly ILogger<WebhookService> _logger;

    public WebhookService(RestClient restClient, ILogger<WebhookService> logger)
    {
        _restClient = restClient;
        _logger = logger;

        _restClient.Options.BaseUrl = new Uri(url);
    }
    
    public Task OnJobEnqueued(object source, JobEnqueueEventArgs args)
    {
        Console.WriteLine($"WebhookService enqueued: {JsonConvert.SerializeObject(args)}\n\n");
        var request = new RestRequest();
        request.AddJsonBody(args);
        _restClient.PostAsync(request).GetAwaiter();
        return Task.CompletedTask;
    }
    
    public Task OnJobPreExecute(object source, JobEnqueueEventArgs args)
    {
        Console.WriteLine($"WebhookService pre-execute: {JsonConvert.SerializeObject(args)}\n\n");
        var request = new RestRequest();
        request.AddJsonBody(args);
        _restClient.PostAsync(request).GetAwaiter();
        return Task.CompletedTask;
    }
    
    public Task OnJobExecute(object source, JobEnqueueEventArgs args)
    {
        Console.WriteLine($"WebhookService execute: {JsonConvert.SerializeObject(args)}\n\n");
        var request = new RestRequest();
        request.AddJsonBody(args);
        _restClient.PostAsync(request).GetAwaiter();
        return Task.CompletedTask;
    }
    
    public Task OnJobPostExecute(object source, JobEnqueueEventArgs args)
    {
        Console.WriteLine($"WebhookService post-execute: {JsonConvert.SerializeObject(args)}\n\n");
        var request = new RestRequest();
        request.AddJsonBody(args);
        _restClient.PostAsync(request).GetAwaiter();
        return Task.CompletedTask;
    }
    
    public Task OnJobExecuted(object source, JobEnqueueEventArgs args)
    {
        Console.WriteLine($"WebhookService executed: {JsonConvert.SerializeObject(args)}\n\n");
        var request = new RestRequest();
        request.AddJsonBody(args);
        _restClient.PostAsync(request).GetAwaiter();
        return Task.CompletedTask;
    }
}