namespace practice_api.Entities.MoneyExchange;

public class ExchangeSymbol
{
    public int ID { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public DateTime? UpdatedOn { get; set; }
}