using Microsoft.AspNetCore.Mvc;
using Okane.Application;

namespace Okane.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly ExpenseService _expensesService;

    public ExpensesController(ExpenseService expensesService) => 
        _expensesService = expensesService;
    
    // POST /expenses
    [HttpPost]
    public Expense Post(Expense expense) => _expensesService.RegisterExpense(expense);
    
    // GET /expenses
    [HttpGet]
    public IEnumerable<Expense> Get() => _expensesService.RetrieveAll();
}