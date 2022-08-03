namespace practice_api.Models.MoneyExchange;

public class ExchangeLatestDTO
{
  public string Base { get; set; }
  public DateTime Date { get; set; }
  public Dictionary<string, double> Rates { get; set; }
  public bool Success { get; set; }
  public double Timestamp { get; set; }
}