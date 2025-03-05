using System.ComponentModel.DataAnnotations;
using BudgetApp.Data.Components;

namespace BudgetApp.Auth.Model;

public class UserCreateModel
{
	[Required]
	public string Username { get; set; }
	[Required]
	public string Email { get; set; }
	[Required]
	public string Password { get; set; }
	public User ToEntity()
	{
		var entity = new User()
		{
			FullName = this.Username,
			Email = this.Email,
			PasswordHash = this.Password,
		};
		return entity;

	}
}
