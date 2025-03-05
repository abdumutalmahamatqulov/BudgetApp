using BudgetApp.Data.Components;
using BudgetApp.Data.Transactions.Models;

namespace BudgetApp.Auth.Model;

public class UserModel
{
	public int Id { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string PasswordHash { get; set; }
	public virtual UserModel MapFromEntity(User entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException(nameof(entity), "User entity cannot be null.");
		}
		Id = entity.Id;
		UserName = entity.FullName;
		Email = entity.Email;
		PasswordHash = entity.PasswordHash;
		return this;
	}

}
