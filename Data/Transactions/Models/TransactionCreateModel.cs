using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BudgetApp.Data.Components;

namespace BudgetApp.Data.Transactions.Models;

public class TransactionCreateModel
{
	[Required]
	public string Type { get; set; } // "Income" yoki "Expense"

	[Required]
	public decimal Amount { get; set; }
	[AllowNull]
	public string? Comment { get; set; }
	[AllowNull]

	public int? CategoryId { get; set; }
	[AllowNull]
	public string? CategoryName { get; set; }
	[AllowNull]
	public int? UserId { get; set; }
	[AllowNull]
	public string? FullName { get; set; }
	[AllowNull]

	public string? Email { get; set; }
	[AllowNull]

	public string? PasswordHash { get; set; }

	public Transaction ToEntity()
	{
		return new Transaction()
		{
			Type=this.Type,
			Amount = this.Amount,
			Comment = this.Comment,
		};
	}
}
