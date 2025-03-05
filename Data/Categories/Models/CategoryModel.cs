namespace BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Components;
using BudgetApp.Data.Transactions.Models;

public class CategoryModel
{
	public int Id { get; set; }
	public string Name { get; set; }

	public CategoryModel MapFromEntity(Category entity)
	{
		Id = entity.Id;
		Name = entity.Name;
		return this;
	}
}
