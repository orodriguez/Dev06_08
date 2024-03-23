using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Okane.Application;
using Okane.Domain;

namespace Okane.WebApi.Controllers;

[Authorize]
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

    [HttpDelete ("{id}")]
    public bool Delete(int id) => _expensesService.Delete(id);
}
