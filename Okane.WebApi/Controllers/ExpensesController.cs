using Microsoft.AspNetCore.Mvc;
using Okane.Application;
using Okane.Domain;

namespace Okane.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public ActionResult<Expense> AddExpense([FromBody] Expense expense)
        {
            var registeredExpense = _expenseService.RegisterExpense(expense);
            return Ok(registeredExpense);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses()
        {
            var expenses = _expenseService.RetrieveAll();
            return Ok(expenses);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var success = _expenseService.Delete(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}