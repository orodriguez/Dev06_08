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
    public Expense Post(Expense expense)
    {
        return _expensesService.RegisterExpense(expense);
    }

    // GET /expenses
    [HttpGet]
    public IEnumerable<Expense> Get() => _expensesService.RetrieveAll();

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var expenseToDelete = _expensesService.RetrieveAll().FirstOrDefault(expense => expense.Id == id);
        if (expenseToDelete == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
