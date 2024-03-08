
using System.Collections.Generic;
using Okane.Domain;

namespace Okane.Application
{
    public class InMemoryExpensesRepository : IExpensesRepository
    {
        private readonly List<Expense> _expenses = new List<Expense>();
        private int _nextId = 1;

        public Expense AddExpense(Expense expense)
        {
            expense.Id = _nextId++;
            _expenses.Add(expense);
            return expense;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _expenses;
        }

        public bool DeleteExpense(int expenseId)
        {
            var expense = _expenses.Find(e => e.Id == expenseId);
            if (expense != null)
            {
                _expenses.Remove(expense);
                return true;
            }
            return false;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}