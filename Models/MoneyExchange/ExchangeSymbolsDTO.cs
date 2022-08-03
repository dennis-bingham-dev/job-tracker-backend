namespace practice_api.Models.MoneyExchange;

public class ExchangeSymbolsDTO
{
    public bool Success { get; set; }
    public Dictionary<string, string>? Symbols { get; set; }
}