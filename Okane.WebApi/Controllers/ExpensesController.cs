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

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var expense = _expensesService.DeleteExpense(id);

        if(expense == null) {
            return NotFound("Bueno, manito, eso como que no existe.");
        }
        
        // Aqui queria acceder al expense eliminado, por eso hice la busqueda en DeleteExpense, pero no logre acceder. Recibia un Okane.Domain.Expense
        // por ello lo deje asi.
        return Ok("Listo, se fue borrado.");
    }
}