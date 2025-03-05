using BudgetApp.Data.Categories.Models;
using BudgetApp.Data.Categories.Repositories;
using BudgetApp.Data.Exceptions;
using BudgetApp.Data.Pages;

namespace BudgetApp.Data.Categories.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryService(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}
	public async ValueTask<CategoryModel> Get(int id)
	{
		return new CategoryModel().MapFromEntity(await _categoryRepository.Get(id));
	}
	public async ValueTask<CategoryModel> Create(CategoryCreateModel model)
	{
		try
		{
			var newCategory = model.ToEntity();
			await _categoryRepository.Create(newCategory);
			return new CategoryModel().MapFromEntity(newCategory);
		}
		catch (BugalteryAPIException ex)
		{
			throw new BugalteryAPIException(400, $"{ex.Message}");
		}
	}
	public async ValueTask<PagedResult<CategoryModel>> GetAll(CategoryFilterModel filter)
	{
		var count = await _categoryRepository.GetCount(filter);
		var list = await _categoryRepository.GetByFilter(filter);
		return PagedResult.Create(list.Select(x => new CategoryModel().MapFromEntity(x)).ToList(), filter.PageIndex, filter.PageSize, count);
	}
	public async ValueTask<CategoryModel> UpdateModel(CategoryUpdateModel model)
	{
		var updateModel = model.ToEntity();
		await _categoryRepository.Update(updateModel);
		return new CategoryModel().MapFromEntity(updateModel);
	}
	public async ValueTask<bool> Delete(int id)
	{
		await _categoryRepository.Delete(id);
		return true;
	}
}
