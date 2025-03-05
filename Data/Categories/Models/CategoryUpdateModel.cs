using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Components;

public class CategoryUpdateModel
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
	public Category ToEntity()
	{
		var addCategory = new Category();
		addCategory.Id = this.Id;
		addCategory.Name = this.Name;
		return addCategory;
	}
}
