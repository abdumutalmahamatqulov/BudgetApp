using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Data.Components;

public class User: Auditable
{

	[Required]
	public string FullName { get; set; }

	[Required]
	public string Email { get; set; }

	[Required]
	public string PasswordHash { get; set; }
}
