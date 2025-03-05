using System.ComponentModel.DataAnnotations;
using BudgetApp.Data.Components;

namespace BudgetApp.Auth.Model;

public class LoginModel
{
	[Required]
	public string Email { get; set; }
	[Required]
	public string Password { get; set; }

	public LoginModel MapFromEntity(User model)
	{
		Email = model.Email;
		Password = model.PasswordHash;
		return this;
	}
}
