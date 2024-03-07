using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expenses;

    public ExpenseService(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Expense RegisterExpense(Expense expense)
    {
        _expenses.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> RetrieveAll() => 
        _expenses.All();

    public void DeleteExpense(int id)
    {
        _expenses.Delete(id);
    }
}

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService) =>
        _expenseService = expenseService;

    [HttpPost]
    public IActionResult Post([FromBody] ExpenseDto expenseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var expense = expenseDto.ToExpense();
        _expenseService.RegisterExpense(expense);

        return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var expenses = _expenseService.RetrieveAll();
        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var expense = _expenseService.RetrieveById(id);
        if (expense == null)
            return NotFound();

        return Ok(expense);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var expense = _expenseService.RetrieveById(id);
        if (expense == null)
            return NotFound();

        _expenseService.DeleteExpense(id);

        return NoContent();
    }
}
