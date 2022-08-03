using Microsoft.AspNetCore.Mvc;
using practice_api.BLL.CurrencyExchange;
using practice_api.Entities.MoneyExchange;

namespace practice_api.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class CurrencyExchangeController : ControllerBase
{
    private readonly CurrencyExchangeBLL _currencyExchangeBll;
    private readonly ILogger<CurrencyExchangeController>  _logger;
  
    public CurrencyExchangeController(CurrencyExchangeBLL currencyExchangeBll, ILogger<CurrencyExchangeController> logger)
    {
        _currencyExchangeBll = currencyExchangeBll;
        _logger = logger;
    }

    [HttpPost()]
    public ActionResult<ExchangeLatest> CurrencyExchangeSync()
    {
        var rates = new ExchangeLatest
        {
            CreatedOn = DateTime.Now,
            Base = "FAKE",
            Date = DateTime.Today,
            ID = 1,
            Success = true,
            Timestamp = 1656822003,
            Rates = new List<ExchangeRate>
            {
                new ExchangeRate
                {
                    CreatedOn = DateTime.Now,
                    ExchangeLatestID = 1,
                    ID = 1,
                    Rate = 1.0400012,
                    Symbol = "USD"
                } 
            }
        };  
        
        return Ok(rates);
    }

    [HttpPost()]
    public async Task<IActionResult> GetLatestCurrencyExchange()
    {
        var response = await _currencyExchangeBll.GetLatestCurrencyExchangeFromExchange();
        return Ok(response);
    }
    
    [HttpPost()]
    public async Task<IActionResult> GetExchangeSymbols()
    {
        var response = await _currencyExchangeBll.GetExchangeSymbolsFromExchange();
        return Ok(response);
    } 
}