using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BudgetApp.Auth.Model;
using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Components;
namespace BudgetApp.Data.Transactions.Models;

public class TransactionModel
{
	public int Id { get; set; }
	public string Type { get; set; } 
	public DateTime Date { get; set; }

	public string? Comment { get; set; }

	public int CategoryId { get; set; }
	public CategoryModel Category { get; set; }

	public int UserId { get; set; }
	public UserModel User { get; set; }
	public decimal Amount { get; set; }
	public TransactionModel MapFromEntity(Transaction entity)
	{
		Id = entity.Id;
		Amount = entity.Amount;
		Date = entity.Date;
		Type=entity.Type;
		User = entity.User is null ? null : new UserModel().MapFromEntity(entity.User);
		UserId = entity.UserId;
		CategoryId = entity.CategoryId;
		Category = entity.Category is null ? null : new CategoryModel().MapFromEntity(entity.Category);
		return this;
	}
}
