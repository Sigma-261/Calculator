using Calculator.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Server;

public class ApplicationContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<MathCalculation> MathCalculations { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
    {
        Database.EnsureCreated();
    }
}
