using Microsoft.AspNetCore.Mvc;
using practice_api.Events.Jobs;
using practice_api.Events.Jobs.Helpers;
using practice_api.Events.Jobs.Models;
using practice_api.Events.Jobs.Subscribers;

namespace practice_api.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class JobsController : ControllerBase
{
    private readonly JobEvent _jobEvent;
    private readonly WebhookService _webhookService;
    private readonly ILogger<JobsController>  _logger;
  
    public JobsController(JobEvent jobEvent, WebhookService webhookService, ILogger<JobsController> logger)
    {
        _jobEvent = jobEvent;
        _webhookService = webhookService;
        _logger = logger;
    }

    [HttpPost()]
    public ActionResult EnqueueJob([FromBody] Job job)
    {
        _webhookService.SubscribeToJob(_jobEvent);
        _jobEvent.RunAsync(job);
        return Ok();
    }
}