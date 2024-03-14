using Okane.Domain;
using System; 
using System.Web.Http;
using System.Web.Mvc;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;

    public ExpenseService(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

   

    public IEnumerable<Expense> RetrieveAll() => 
       
}