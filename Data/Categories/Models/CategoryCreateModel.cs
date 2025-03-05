using System.ComponentModel.DataAnnotations;
namespace BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Components;

public class CategoryCreateModel
{
	[Required]
	public string Name { get; set; }
	public Category ToEntity()
	{
		var createcategory = new Category();
		createcategory.Name = this.Name;
		return createcategory;
	}
}
