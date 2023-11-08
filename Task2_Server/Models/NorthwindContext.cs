using Microsoft.EntityFrameworkCore;

namespace Task2.Models;

public class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}