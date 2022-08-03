using practice_api.Extensions.Common;
using practice_api.Models.MoneyExchange;
using RestSharp;

namespace practice_api.BLL.CurrencyExchange;

public class CurrencyExchangeBLL
{
    private RestClient _client;

    public CurrencyExchangeBLL(RestClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Requests Exchange Latest Details from exchange API to update local database.
    /// </summary>
    /// <returns>Task of type ExchangeLatestDTO</returns>
    public async Task<ExchangeLatestDTO> GetLatestCurrencyExchangeFromExchange()
    {
        var request = new RestRequest().ConfigureRequest(Method.Get);

        var response = await _client
            .ConfigureClient("https://api.apilayer.com/exchangerates_data/latest?base=USD")
            .ExecuteAsync(request);

        return response == null ? new ExchangeLatestDTO() : response.Content!.Deserialize<ExchangeLatestDTO>();
    }

    /// <summary>
    /// Requests Exchange Symbols from exchange API to update local database.
    /// </summary>
    /// <returns>Task of type ExchangeSymbolsDTO</returns>
    public async Task<ExchangeSymbolsDTO?> GetExchangeSymbolsFromExchange()
    {
        var request = new RestRequest().ConfigureRequest(Method.Get);
        
        var response = await _client
            .ConfigureClient("https://api.apilayer.com/exchangerates_data/symbols")
            .ExecuteAsync(request);

        return response == null ? new ExchangeSymbolsDTO() : response.Content!.Deserialize<ExchangeSymbolsDTO>();
    }
}