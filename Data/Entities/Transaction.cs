using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Data.Components;

public class Transaction: Auditable
{

	[Required]
	public string Type { get; set; } // "Income" yoki "Expense"

	[Required]
	public decimal Amount { get; set; }

	[Required]
	public DateTime Date { get; set; } = DateTime.UtcNow;

	public string? Comment { get; set; }

	[ForeignKey("Category")]
	public int CategoryId { get; set; }
	public Category Category { get; set; }

	[ForeignKey("User")]
	public int UserId { get; set; }
	public User User { get; set; }
}
