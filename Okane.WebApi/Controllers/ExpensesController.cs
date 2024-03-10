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
    public Expense Post(Expense expense) => 
        _expensesService.RegisterExpense(expense);
        _expenses.Description = "esta es la descripcion xd";
        return _expensesService.RegisterExpense(expense);

    
    // GET /expenses
    [HttpGet]
    public IEnumerable<Expense> Get() => 
        _expensesService.RetrieveAll();
        var expenses = expensesService.RetrieveAll();
        return expenses;
        
    // DELETE /expenses/:id
    [HttpDelete("{id}")]
    public bool Delete(int id) => 
        _expensesService.Delete(id);
}