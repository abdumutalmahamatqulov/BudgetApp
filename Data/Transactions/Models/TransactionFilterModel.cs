using System.ComponentModel.DataAnnotations;
using BudgetApp.Data.Pages;

namespace BudgetApp.Data.Transactions.Models;

public class TransactionFilterModel : PaginationParams
{
	public int? Id { get; set; }
	public int? CategoryId { get; set; }
	public string? Type { get; set; } // "Income" yoki "Expense"

	public decimal? Amount { get; set; }
}
