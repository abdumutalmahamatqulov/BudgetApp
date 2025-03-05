using BudgetApp.Auth.Model;
using BudgetApp.Auth.Services.Interface;
using BudgetApp.Data.Components;
using BudgetApp.Auth.Repositories.Interface;
using BudgetApp.Data.Exceptions;
using Microsoft.AspNetCore.Identity;
using BudgetApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Auth.Services;

public class AuthService : IAuthService
{
	private readonly AppDbContext _userManager;
	readonly ITokenRepository _tokenGenerator;
	public AuthService(AppDbContext userManager, ITokenRepository tokenGenerator)
	{
		_userManager = userManager;
		_tokenGenerator = tokenGenerator;
	}

	public async ValueTask<TokenModel> Login(LoginModel model)
	{
		var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.Email.ToLower()==model.Email.ToLower());
		if (user == null)
		{
			throw new BugalteryAPIException(400, "User not found");
		}

		if (user.PasswordHash != model.Password) // Parol hashing ishlatilmasa
		{
			throw new BugalteryAPIException(401, "Email or password is incorrect");
		}

		var token = _tokenGenerator.CreateToken(user, new List<string>());

		return new TokenModel()
		{
			Token = token,
			User = new UserModel().MapFromEntity(user)
		};

	}

	public async ValueTask<UserModel> Registration(RegisterModel user)
	{
		User newUser = new User()
		{
			FullName = user.Username,
			Email = user.Email,
			PasswordHash = user.Password
		};
		 await _userManager.Users.AddAsync(newUser);
		await _userManager.SaveChangesAsync();

		return new UserModel().MapFromEntity(newUser);
	}
}
