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
    /*En esta parte se ha utilizado un "Enlace de modelo" que proporciona ASP.NET CORE, que permite en base a las
     propiedades de un modelo (la clase expense) este deserializa un objeto (el objeto json que le enviemos) toma las propiedades
    y segun el nombre de estas, las asigna a un objeto tipo "expense" */

    /*Otro punto que he logrado entender, es que _expenseService.RegisterExpense(expense), es el metodo que luego de que ese objeto json es transformado, pues con este ultimo metodo, nuestro nuevo objeto tipo Expense, pasa a ser guardado en memoria (InMemoryExpenseRepo...) */
    
    // GET /expenses
    [HttpGet]
    public IEnumerable<Expense> Get() => _expensesService.RetrieveAll();


    //DELETE /expenses/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        bool deleted = this._expensesService.DeleteExpense(id);

        if (deleted)
        {
            return Ok();
        }
        else
        {

            return NotFound();
        }
    }
    
}