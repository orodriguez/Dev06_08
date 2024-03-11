using Okane.Application;
using Okane.Storage.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);
builder.Services.AddTransient<IExpensesRepository, ExpensesRepository>();
builder.Services.AddDbContext<OkaneDbContext>();

// builder.Services.AddSingleton<IExpensesRepository, InMemoryExpensesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();