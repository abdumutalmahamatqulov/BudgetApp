using BudgetApp.Data.Pages;

namespace BudgetApp.Data.Categories.Models;

public class CategoryFilterModel : PaginationParams
{
	public int? Id { get; set; }
	public string? Name { get; set; }
}
