using Microsoft.Extensions.DependencyInjection;
using Okane.Application;

namespace Okane.Tests;

public class DependencyInjectionTests
{
    [Fact]
    public void ManualInjection()
    {
        DateTime GetCurrentTime() => DateTime.Now;
        var service = new ExpenseService(new InMemoryExpensesRepository(GetCurrentTime), GetCurrentTime);
    }

    [Fact]
    public void DependencyInjectionContainer()
    {
        var services = new ServiceCollection();
        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);
        services.AddSingleton<IExpensesRepository, InMemoryExpensesRepository>();

        var provider = services.BuildServiceProvider();

        var expensesService = provider.GetRequiredService<IExpenseService>();
        
        Assert.Empty(expensesService.Search());
    }
    
    [Fact]
    public void UnableToResolve()
    {
        var services = new ServiceCollection();
        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);

        var provider = services.BuildServiceProvider();

        var exception = Assert.Throws<InvalidOperationException>(() => 
            provider.GetRequiredService<IExpenseService>());

        Assert.Contains("Unable to resolve service", 
            exception.Message);
    }

    [Fact]
    public void Transient()
    {
        var services = new ServiceCollection();
        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);
        services.AddTransient<IExpensesRepository, InMemoryExpensesRepository>();
        var provider = services.BuildServiceProvider();

        var expenseService1 = provider.GetRequiredService<IExpenseService>();
        var expenseService2 = provider.GetRequiredService<IExpenseService>();

        Assert.NotEqual(expenseService1.GetHashCode(),
            expenseService2.GetHashCode());
    }
    
    [Fact]
    public void Singleton()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IExpensesRepository, InMemoryExpensesRepository>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);
        var provider = services.BuildServiceProvider();

        var repository1 = provider.GetRequiredService<IExpensesRepository>();
        var repository2 = provider.GetRequiredService<IExpensesRepository>();

        Assert.Equal(repository1.GetHashCode(),
            repository2.GetHashCode());
    }
}