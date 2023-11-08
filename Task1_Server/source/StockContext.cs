using Microsoft.EntityFrameworkCore;

namespace Task1.source;

public class StockContext : DbContext
{
    public DbSet<Ticker> Tickers { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<TodayCondition> TodaysCondition { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=127.0.0.1:3306;user=thematrix;password=password;database=Tickers",
            new MySqlServerVersion(new Version(8, 0, 25)));
    }
}