
using System.Collections.Generic;
using Okane.Domain;

namespace Okane.Application
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpenseService(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public Expense RegisterExpense(Expense expense)
        {
            return _expensesRepository.AddExpense(expense);
        }

        public IEnumerable<Expense> RetrieveAll()
        {
            return _expensesRepository.GetAllExpenses();
        }

        public bool Delete(int expenseId)
        {
            return _expensesRepository.DeleteExpense(expenseId);
        }
    }
}
