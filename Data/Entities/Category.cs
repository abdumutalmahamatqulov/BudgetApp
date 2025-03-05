using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Data.Components;

public class Category: Auditable
{

	[Required]
	public string Name { get; set; }
}
