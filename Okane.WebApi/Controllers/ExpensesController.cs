using Microsoft.AspNetCore.Mvc;
using Okane.Application;
using Okane.Domain;

namespace Okane.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expensesService;

    public ExpensesController(IExpenseService expensesService) => 
        _expensesService = expensesService;
    
    // POST /expenses
    [HttpPost]
    public Expense Post(Expense expense) => _expensesService.RegisterExpense(expense);
    
    // GET /expenses
    [HttpGet]
    public IEnumerable<Expense> Get() => _expensesService.RetrieveAll();

    // POST /expenses
    [HttpDelete]
    public Expense Delete(int id) => _expensesService.RemoveExpense(id);
}