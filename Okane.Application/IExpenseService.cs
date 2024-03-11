using Okane.Application;
namespace Okane.Application
{
    public interface IExpenseService
    {
        ExpenseResponse RegisterExpense(CreateExpenseRequest request);
        ExpenseResponse? ById(int id);
        IEnumerable<ExpenseResponse> Search(string? category = null);
        bool Delete(int id);
        ExpenseResponse? UpdateExpense(int id, UpdateExpenseRequest request); 
        
    }

    public class UpdateExpenseRequest

    {
        [Required]
        [Range(1, 1_000_000, ErrorMessage = "Amount is out of range")]
        public int Amount { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Category is too long")]
        public string Category { get; set; }

        [MaxLength(250, ErrorMessage = "Description is too long")]
        public string? Description { get; set; }
    }
}

