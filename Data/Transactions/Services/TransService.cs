using System.Security.Claims;
using BudgetApp.Auth.Model;
using BudgetApp.Auth.Repositories.Interface;
using BudgetApp.Auth.Services.Interface;
using BudgetApp.Data.Categories.Repositories;
using BudgetApp.Data.Components;
using BudgetApp.Data.Exceptions;
using BudgetApp.Data.Pages;
using BudgetApp.Data.Transactions.Models;
using BudgetApp.Data.Transactions.Repositories;

namespace BudgetApp.Data.Transactions.Services;

public class TransService : ITransService
{
	private readonly ITransRepository _repository;
	private readonly ICategoryRepository _category;
	private readonly IAuthService _user;
	public TransService(ITransRepository repository, ICategoryRepository category, IAuthService user)
	{
		_repository = repository;
		_category = category;
		_user = user;
	}

	public async ValueTask<TransactionModel> Create(TransactionCreateModel model)
	{
		try
		{
			User newUser = new();
			if (!model.UserId.HasValue)
			{
				var user = new User
				{
					FullName = model.FullName,
					Email = model.Email,
					PasswordHash = model.PasswordHash
				};
				var registerModel = _user.Registration(new RegisterModel().MapFromEntity(user));
			}
			Category newCategory = new();
			if (!model.CategoryId.HasValue)
			{
				var category = new Category
				{
					Name = model.CategoryName
				};
				newCategory = await _category.Create(category);
			}
			var newTrans = model.ToEntity();
			newTrans.UserId = model.UserId.HasValue ? model.UserId.Value : newUser.Id;
			newTrans.CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : newCategory.Id;
			await _repository.Create(newTrans);
			return new TransactionModel().MapFromEntity(newTrans);
		}
		catch (BugalteryAPIException ex)
		{
			throw new BugalteryAPIException(400, $"{ex.Message}");
		}
	}

	public async ValueTask<bool> Delete(int Id)
	{
		await _repository.Delete(Id);
		return true;
	}

	public async ValueTask<TransactionModel> Get(int Id)
	{
		return new TransactionModel().MapFromEntity(await _repository.Get(Id));
	}

	public async ValueTask<PagedResult<TransactionModel>> GetAll(TransactionFilterModel filter)
	{
		var count = await _repository.GetCount(filter);
		var list = await _repository.GetByFilter(filter);
		return PagedResult.Create(list.Select(x => new TransactionModel().MapFromEntity(x)).ToList(), filter.PageIndex, filter.PageSize, count);
	}

	public async ValueTask<TransactionModel> Update(TransactionUpdateModel model)
	{
		User newUser = new();
		if (!model.UserId.HasValue)
		{
			var user = new User
			{
				FullName = model.FullName,
				Email = model.Email,
				PasswordHash = model.PasswordHash
			};
			var registerModel = _user.Login(new LoginModel().MapFromEntity(user));
		}
		Category newCategory = new();
		if (!model.CategoryId.HasValue)
		{
			var category = new Category
			{
				Name = model.CategoryName
			};
			newCategory = await _category.Update(category);
		}
		var edit = model.ToEntity();
		edit.UserId = model.UserId.HasValue ? model.UserId.Value : newUser.Id;
		edit.CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : newCategory.Id;
		await _repository.Update(edit);
		return new TransactionModel().MapFromEntity(edit);
	}
}
