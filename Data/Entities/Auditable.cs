using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Data.Components;

public class Auditable
{
	[Key]
	public int Id { get; set; }
}
