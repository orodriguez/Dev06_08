using Microsoft.EntityFrameworkCore;
using Okane.Domain;

namespace Okane.Storage.EntityFramework;

public class OkaneDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OkaneDev;Username=okane;Password=okane;");
    }
}