using Microsoft.AspNetCore.Mvc;

namespace practice_api.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class TestSyncController : ControllerBase
{
  private readonly ILogger<TestSyncController>  _logger;
  
  public TestSyncController(ILogger<TestSyncController> logger)
  {
    _logger = logger;
  }

  [HttpPost()]
  public IActionResult CurrencyExchangeSync()
  {
    return Ok("I was a success");
  }
}
