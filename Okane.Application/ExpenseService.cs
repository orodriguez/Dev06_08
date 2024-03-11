using Okane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Okane.Application
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpenseService(IExpensesRepository expensesRepository) => 
            _expensesRepository = expensesRepository;

        public ExpenseResponse RegisterExpense(CreateExpenseRequest request)
        {
            var expense = new Expense
            {
                Amount = request.Amount,
                Description = request.Description,
                Category = request.Category,
                DateCreated = DateTime.UtcNow // Incluir la fecha actual al registrar
            };
        
            _expensesRepository.Add(expense);
        
            return CreateExpenseResponse(expense);
        }

        public ExpenseResponse? ById(int id)
        {
            var expense = _expensesRepository.ById(id);

            return expense == null ? null : CreateExpenseResponse(expense);
        }

        public IEnumerable<ExpenseResponse> Search(string? category = null) => 
            _expensesRepository
                .Search(category)
                .Select(CreateExpenseResponse);

        public bool Delete(int id)
        {
            var expenseToDelete = _expensesRepository.ById(id);

            if (expenseToDelete == null)
                return false;
        
            _expensesRepository.Delete(id);
            return true;
        }

        public ExpenseResponse? UpdateExpense(int id, UpdateExpenseRequest request)
        {
            var existingExpense = _expensesRepository.ById(id);
            if (existingExpense == null)
                return null;  // No se encontró el gasto para actualizar

            // Actualizar la información del gasto
            existingExpense.Amount = request.Amount;
            existingExpense.Category = request.Category;
            existingExpense.Description = request.Description;

            // Guardar los cambios
            _expensesRepository.Update(existingExpense);

            // Devolver la respuesta actualizada
            return CreateExpenseResponse(existingExpense);
        }

        private static ExpenseResponse CreateExpenseResponse(Expense expense) =>
            new()
            {
                Id = expense.Id,
                Category = expense.Category,
                Description = expense.Description,
                Amount = expense.Amount,
                DateCreated = expense.DateCreated // Asegúrate de incluir la fecha al crear la respuesta
            };
    }
}
