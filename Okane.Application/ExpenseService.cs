using Okane.Domain;
using System; 
using System.Web.Http;
using System.Web.Mvc;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expenses;

    public ExpenseService(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Expense RegisterExpense(Expense expense)
    {
        expense.Date = DateTime.Now; 
        _expenses.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> RetrieveAll() => 
        _expenses.All();

    public void DeleteExpense(int id)
    {
        _expenses.Delete(id);
    }

    public void UpdateExpense(Expense expense) 
    {
        _expenses.Update(expense);
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

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ExpenseDto expenseDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var expense = _expenseService.RetrieveById(id);
        if (expense == null)
            return NotFound();

        expense = expenseDto.ToExpense();
        _expenseService.UpdateExpense(expense);

        return NoContent();
    }
}
