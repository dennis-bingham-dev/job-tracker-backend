namespace practice_api.Entities.MoneyExchange;

public class ExchangeLatest
{
    public DateTime CreatedOn { get; set; }
    public string Base { get; set; }
    public DateTime Date { get; set; }
    public int ID { get; set; }
    public bool Success { get; set; }
    public double Timestamp { get; set; }
    public DateTime? UpdatedOn { get; set; }
    
    public ICollection<ExchangeRate> Rates { get; set; } 
}

public class ExchangeRate
{
    public DateTime CreatedOn { get; set; }
    public int ExchangeLatestID { get; set; }
    public int ID { get; set; }
    public double Rate { get; set; }
    public string Symbol { get; set; }
    
    public ExchangeLatest ExchangeLatest { get; set; }
}