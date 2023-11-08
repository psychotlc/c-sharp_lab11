namespace Task1.source;

public class Ticker
{
    public int Id { get; set; }
    public string TickerName { get; set; }
}

public class Price
{
    public int ID { get; set; }
    public int TickerID { get; set; }
    public double PriceOnDate { get; set; }
    public DateTimeOffset Date { get; set; }
}

public class TodayCondition
{
    public int ID { get; set; }
    public int TickerID { get; set; }
    public bool State { get; set; }
}