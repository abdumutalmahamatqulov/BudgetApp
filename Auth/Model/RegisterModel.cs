﻿using System.ComponentModel.DataAnnotations;
using BudgetApp.Data.Components;

namespace BudgetApp.Auth.Model;

public class RegisterModel
{
	[Required]
	public string Username { get; set; }
	[Required]
	public string Email { get; set; }
	[Required]
	public string Password { get; set; }

	public  RegisterModel MapFromEntity(User model)
	{

		Username = model.FullName;
		Email = model.Email;
		Password = model.PasswordHash;
		return this;
	}
}
